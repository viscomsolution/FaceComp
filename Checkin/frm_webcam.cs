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

namespace Checkin
{
    public partial class frm_webcam : Form
    {
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        float g_scaleX = 1;
        float g_scaleY = 1;
        bool g_loadFaceSuccess;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public frm_webcam()
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

            btn_capture.Enabled = true;            

            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {            
            InitCamera();
            TGMTregistry.GetInstance().Init("FaceComp");

            Program.g_parentDir = TGMTregistry.GetInstance().ReadString("parentDir");

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
            LoadImageInDir();

            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;

            danhSáchKhuônMặtToolStripMenuItem.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadImageInDir()
        {
            cbCamera.Enabled = false;
            btn_capture.Enabled = false;

            if (Program.g_parentDir == "")
            {
                PrintError("Chưa setup parent folder, vui lòng vào menu Danh sách khuôn mặt để thêm");
                return;
            }
                

            listView1.Items.Clear();

            g_loadFaceSuccess = Program.g_facecomp.LoadFaceInDir(Program.g_parentDir);
            string[] dirList = Program.g_facecomp.GetDirList();

            if(dirList.Length == 0)
            {
                MessageBox.Show("Chưa có khuôn mặt trong database. Vui lòng thêm khuôn mặt trong menu Danh sách khuôn mặt");
                return;
            }

            foreach (string dir in dirList)
            {
                string dirName = Path.GetFileName(dir);
                ListViewItem item = new ListViewItem(dirName);
                item.SubItems.Add("0");
                listView1.Items.Add(item);
            }

            cbCamera.Enabled = true;
            btn_capture.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAllCamera();
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
            Bitmap bmp = (Bitmap)g_bmp.Clone();

            FacialRecognized result = Program.g_facecomp.FindMostSimilarInArray(bmp);
            if(result.isMatch)
            {
                lbl_percent.ForeColor = Color.Green;
                lbl_percent.Text = "Giống " + result.percent + "%";
            }
            else
            {
                lbl_percent.ForeColor = Color.Red;
                lbl_percent.Text = "Không giống: " + result.percent + "%";
            }

            picTaken.Image = bmp;
            pic_result.ImageLocation = result.mostSimilarImagePath;
            txt_name.Text = result.imageDir;
            txt_time.Text = DateTime.Now.ToLongTimeString();
            txt_elapsed.Text = result.elapsedMilisecond + "ms";

            string dirName = Path.GetFileName(result.imageDir);
            for(int i=0; i<listView1.Items.Count; i++)
            {
                ListViewItem item = listView1.Items[i];
                if(item.SubItems[0].Text == dirName)
                {
                    int count = int.Parse(item.SubItems[1].Text);
                    item.SubItems[1].Text = (count + 1).ToString();
                    break;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void danhSáchKhuônMặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbCamera.SelectedIndex = -1;
            StopAllCamera();

            frm_person frm = new frm_person();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadImageInDir();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;            
        }
    }
}
