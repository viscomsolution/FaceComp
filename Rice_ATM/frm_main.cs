using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;
using System.Data.SQLite;
using System.Threading;

namespace Checkin
{
    public partial class frm_findPerson : Form
    {
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        float g_scaleX = 1;
        float g_scaleY = 1;

        string g_dir = "images";
        int g_personID = 0;
        TGMTarduino m_arduino;
        bool m_formClosed = false;
        TGMTsqlite m_sqlite;
        bool m_detecting = false;
        DateTime m_lastTimeDetect = DateTime.Now;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public frm_findPerson()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopLoading()
        {
            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;
            progressBar1.Visible = false;
            lblMessage.Text = "";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                PrintError("Can not find camera");
            }

            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitArduino()
        {
            m_arduino = new TGMTarduino();
            //m_arduino.onMessageReceived += OnArduinoMessage;
            m_arduino.onBoardDisconnectedHandler += OnBoardDisconnedted;

            if (m_arduino.Connected)
            {
                lblBoard.Text = "Board: Đã kết nối";
                lblBoard.ForeColor = Color.Green;
                btn_connectBoard.Visible = false;
                btn_trigger.Enabled = true;
            }
            else
            {
                lblBoard.Text = "Board: Chưa kết nối";
                lblBoard.ForeColor = Color.Red;
                btn_trigger.Enabled = false;
                btn_connectBoard.Visible = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnBoardDisconnedted(object sender, ArduinoEventArgs args)
        {
            if (m_formClosed)
                return;

            this.lblBoard.Invoke((MethodInvoker)delegate
            {
                lblBoard.Text = "Board: Chưa kết nối";
                lblBoard.ForeColor = Color.Red;
            });

            this.btn_connectBoard.Invoke((MethodInvoker)delegate
            {
                btn_connectBoard.Visible = true;                
            });

            this.btn_trigger.Invoke((MethodInvoker)delegate
            {
                btn_trigger.Enabled = false;
            });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!Directory.Exists(g_dir))
            {
                Directory.CreateDirectory(g_dir);
            }

            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }


            InitCamera();
            InitArduino();
            TGMTregistry.GetInstance().Init("FaceComp");
            g_personID = TGMTregistry.GetInstance().ReadInt("personID");
            numDay.Value = TGMTregistry.GetInstance().ReadInt("numDay");

            m_sqlite = new TGMTsqlite("db.sqlite3");

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            timerProgressbar.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.g_facecomp = new FaceComp();            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //LoadImageInDir();
            this.Text += Program.g_facecomp.HasLicense ? " (License is valid)" : " (Invalid license)";

            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;

            danhSáchKhuônMặtToolStripMenuItem.Enabled = true;
            btn_capture.Enabled = true;

            if(cbCamera.Items.Count == 1)
            {
                cbCamera.SelectedIndex = 0;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_formClosed = true;

            StopAllCamera();

            if (m_arduino != null)
            {
                m_arduino.Disconnect();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera()
        {
            if (cbCamera.Items.Count == 0 || cbCamera.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbCamera.SelectedIndex].MonikerString);
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp != null)
                g_bmp.Dispose();

            g_scaleX = (float)eventArgs.Frame.Width / picWebcam.Width;
            g_scaleY = (float)eventArgs.Frame.Height / picWebcam.Height;

            g_bmp = (Bitmap)eventArgs.Frame.Clone();        

            picWebcam.Image = g_bmp;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopAllCamera()
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            picWebcam.Image = null;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void btn_capture_Click(object sender, EventArgs e)
        {
            DetectFace();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DetectFace()
        {
            if (Program.g_facecomp == null)
                return;
            if (m_detecting)
                return;

            if(rdAuto.Checked)
            {
                int second = (DateTime.Now - m_lastTimeDetect).Seconds;
                if (second < 5)
                {
                    PrintMessage("Chờ " + (5 - second) + " giây đến lượt tiếp theo");
                    return;
                }
            }


            m_detecting = true;
            PrintMessage("Đang nhận diện....");
            btn_capture.Enabled = false;
            

            Bitmap bmp = (Bitmap)g_bmp.Clone();
            string filePath = Directory.GetCurrentDirectory() + "\\temp\\" + GenerateRandomFileName();
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            string landmarkPath = filePath.Remove(filePath.Length - 4) + ".bin";
            string newFilePath = "";
            string newLandmarkPath = "";

            FacialRecognized result = Program.g_facecomp.FindMostSimilarInDir(filePath, Directory.GetCurrentDirectory() + "\\" + g_dir, true);
            m_lastTimeDetect = DateTime.Now;

            if (result.error != "")
            {
                MessageBox.Show(result.error);
            }
            if (result.isMatch)
            {
                lbl_percent.ForeColor = Color.Red;
                lbl_percent.Text = "Đã xuất hiện";


                newFilePath = result.imageDir + "\\" + Path.GetFileName(filePath);
                newLandmarkPath = result.imageDir + "\\" + Path.GetFileName(landmarkPath);

                string dirName = Path.GetFileName(result.imageDir);

                pic_result.ImageLocation = result.mostSimilarImagePath;
                txt_personID.Text = Path.GetFileName(result.imageDir);

                GetLastTimeAppear(dirName);
                UpdatePerson(dirName);
            }
            else
            {
                if (result.error.Contains("Trial ended"))
                {
                    MessageBox.Show("Phần mềm hết hạn sử dụng");
                    return;
                }


                if (result.percent > 0 || result.errorCode == 204)
                {
                    lbl_percent.ForeColor = Color.Green;
                    lbl_percent.Text = "Chưa xuất hiện";

                    g_personID++;
                    string personID = "P" + String.Format("{0:00000}", g_personID);
                    string newDir = Directory.GetCurrentDirectory() + "\\" + g_dir + "\\" + personID;
                    Directory.CreateDirectory(newDir);
                    TGMTregistry.GetInstance().SaveValue("personID", g_personID);



                    newFilePath = newDir + "\\" + Path.GetFileName(filePath);
                    newLandmarkPath = newDir + "\\" + Path.GetFileName(landmarkPath);

                    AddPerson(personID);
                    txt_personID.Text = personID;

                    m_arduino.Send("O");
                }
                else
                {
                    if(result.errorCode == 404)
                    {
                        lbl_percent.Text = "Không có khuôn mặt";
                    }
                }
            }


            if (result.errorCode == 404)
            {
                new Task(() => { File.Delete(filePath); }).Start();
                new Task(() => {
                    if (File.Exists(landmarkPath))
                    {
                        File.Delete(landmarkPath);
                    }}).Start();
            }
            else
            {
                //move image file to person dir
                new Task(() => { MoveFile(filePath, newFilePath); }).Start();
                new Task(() => { MoveFile(landmarkPath, newLandmarkPath); }).Start();
            }


            picTaken.Image = bmp;

            

            if(rdTrigger.Checked)
            {
                btn_capture.Enabled = true;
            }

            PrintMessage(" ");

            m_detecting = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void MoveFile(string oldPath, string newPath)
        {
            Thread.Sleep(3000);
            try
            {
                File.Move(oldPath, newPath);
            }
            catch(Exception ex)
            {

            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void danhSáchKhuônMặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbCamera.SelectedIndex = -1;
            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //LoadImageInDir();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdAuto_CheckedChanged(object sender, EventArgs e)
        {
            btn_capture.Enabled = rdTrigger.Checked;
            timerAuto.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdTrigger_CheckedChanged(object sender, EventArgs e)
        {
            btn_capture.Enabled = rdTrigger.Checked;
            timerAuto.Stop();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SaveImageAndLandmarkAsync()
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SaveImageAndLandmark(Bitmap bmp, string filePath)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string GenerateRandomFileName()
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss_");
            fileName += RandomString(4) + ".jpg";
            return fileName;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_trigger_Click(object sender, EventArgs e)
        {
            m_arduino.Send("O");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AddPerson(string personID)
        {
            string sql = string.Format("INSERT INTO Person(personID, timeUpdate) VALUES('{0}','{1}')", personID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_sqlite.ExecuteNonQuery(sql);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void UpdatePerson(string personID)
        {
            string sql = string.Format("UPDATE Person set timeUpdate='{0}' where personID='{1}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), personID);
            m_sqlite.ExecuteNonQuery(sql);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GetLastTimeAppear(string personID)
        {
            string sql = string.Format("select timeUpdate from Person where personID='{0}'",  personID);
            DataSet ds = m_sqlite.LoadData(sql);

            DataTable tbl = ds.Tables[0];
            if (tbl.Rows.Count == 0)
            {
                AddPerson(personID);
                m_arduino.Send("O");
                return;
            }
                

            DataRow row = tbl.Rows[0];
            
            txt_time.Text = row[0].ToString();// time.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime timeAppear = DateTime.Parse(row[0].ToString());
            int numHours = (int)(DateTime.Now - timeAppear).TotalHours;
            int numDays = (int)(DateTime.Now - timeAppear).TotalDays;
            txt_numDay.Text = numDays.ToString();
            label4.Text = "Lần gần nhất: " + numHours.ToString() + " giờ";

            int hourEaryAllow = 3;

            if(numHours > (this.numDay.Value * 24 - hourEaryAllow))
            {
                m_arduino.Send("O");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_connectBoard_Click(object sender, EventArgs e)
        {
            InitArduino();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            DetectFace();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void numDay_ValueChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("numDay", numDay.Value);
        }
    }
}
