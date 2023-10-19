using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using TGMTcs;

namespace FaceCompDemo
{
    public partial class FormCompare : Form
    {
        static FormCompare m_instance;
        VideoCaptureDevice m_videoSource1;
        VideoCaptureDevice m_videoSource2;
        Bitmap g_bmp1;
        Bitmap g_bmp2;
        double g_scaleX = 1;
        double g_scaleY = 1;

        private static Random random = new Random();
        Stopwatch watch;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormCompare()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormCompare GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormCompare();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("input");
            InitCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera1.Items.Clear();
            cbCamera2.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera1.Items.Add(videosources[i].Name);
                cbCamera2.Items.Add(videosources[i].Name);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera1();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera2();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera1()
        {
            if (cbCamera1.Items.Count == 0 || cbCamera1.SelectedIndex == -1)
                return;
            if (m_videoSource1 != null)
            {
                m_videoSource1.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource1 = new VideoCaptureDevice(videosources[cbCamera1.SelectedIndex].MonikerString);
            }

            m_videoSource1.NewFrame += new NewFrameEventHandler(OnCameraFrame1);
            m_videoSource1.Start();
            btn_takePicture1.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera2()
        {
            if (cbCamera2.Items.Count == 0 || cbCamera2.SelectedIndex == -1)
                return;
            if (m_videoSource2 != null)
            {
                m_videoSource2.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource2 = new VideoCaptureDevice(videosources[cbCamera2.SelectedIndex].MonikerString);
            }

            m_videoSource2.NewFrame += new NewFrameEventHandler(OnCameraFrame2);
            m_videoSource2.Start();
            btn_takePicture2.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp1 != null)
                g_bmp1.Dispose();

            g_scaleX = (float)eventArgs.Frame.Width / picCamera1.Width;
            g_scaleY = (float)eventArgs.Frame.Height / picCamera1.Height;

            g_bmp1 = (Bitmap)eventArgs.Frame.Clone();
            picCamera1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame2(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp2 != null)
                g_bmp2.Dispose();

            g_scaleX = (float)eventArgs.Frame.Width / picCamera2.Width;
            g_scaleY = (float)eventArgs.Frame.Height / picCamera2.Height;

            g_bmp2 = (Bitmap)eventArgs.Frame.Clone();
            picCamera2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_takePicture1_Click(object sender, EventArgs e)
        {
            if(btn_takePicture1.Text == "Chụp ảnh")
            {
                if (g_bmp1 == null)
                {
                    return;
                }

                picCamera1.Image = (Bitmap)g_bmp1.Clone();
                StopAllCamera();

                btn_takePicture1.Text = "Start";
                watch = Stopwatch.StartNew();
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                m_videoSource1.Start();
                btn_takePicture1.Text = "Chụp ảnh";
            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_takePicture2_Click(object sender, EventArgs e)
        {
            if (btn_takePicture2.Text == "Chụp ảnh")
            {
                if (g_bmp2 == null)
                {
                    return;
                }

                picCamera2.Image = (Bitmap)g_bmp2.Clone();
                StopAllCamera();

                btn_takePicture2.Text = "Start";
                watch = Stopwatch.StartNew();
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                m_videoSource2.Start();
                btn_takePicture2.Text = "Chụp ảnh";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
            }
            else
            {
                StopAllCamera();
                cbCamera1.SelectedIndex = -1;
                cbCamera2.SelectedIndex = -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopAllCamera()
        {
            if (m_videoSource1 != null)
                m_videoSource1.Stop();
            if (m_videoSource2 != null)
                m_videoSource2.Stop();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_select1_Click(object sender, EventArgs e)
        {
            txt_fileName1.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName1.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_select2_Click(object sender, EventArgs e)
        {
            txt_fileName2.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName2.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName1_TextChanged(object sender, EventArgs e)
        {
            if (txt_fileName1.Text == "")
                return;

            string fileName = txt_fileName1.Text.Replace("\"", "");
            lbl_result.Text = "";
            FormMain.GetInstance().StartProgressbar();

            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
            bmp = TGMTimage.CorrectOrientation(bmp);
            if (bmp != null)
            {                
                picCamera1.Image = bmp;
                g_bmp1 = (Bitmap)bmp.Clone();
                FormMain.GetInstance().PrintMessage("");

                Rectangle[] rects = Program.g_facecomp.Detect(g_bmp1);
                if(rects.Length == 0)
                {
                    lbl_message1.Text = "No face";
                    lbl_message1.ForeColor = Color.Red;
                    FormMain.GetInstance().StopProgressbar();
                    return;
                }
                else
                {
                    lbl_message1.Text = rects.Length + " face";
                    lbl_message1.ForeColor = Color.GreenYellow;
                }


                watch = Stopwatch.StartNew();
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName2_TextChanged(object sender, EventArgs e)
        {
            if (txt_fileName2.Text == "")
                return;

            FormMain.GetInstance().StartProgressbar();

            string fileName = txt_fileName2.Text.Replace("\"", "");
            lbl_result.Text = "";
            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
            bmp = TGMTimage.CorrectOrientation(bmp);

            if (bmp != null)
            {
                picCamera2.Image = bmp;
                g_bmp2 = (Bitmap)bmp.Clone();
                FormMain.GetInstance().PrintMessage("");


                Rectangle[] rects = Program.g_facecomp.Detect(g_bmp2);
                if (rects.Length == 0)
                {
                    lbl_message2.Text = "No face";
                    lbl_message2.ForeColor = Color.Red;
                    FormMain.GetInstance().StopProgressbar();
                    return;
                }
                else
                {
                    lbl_message2.Text = rects.Length + " face";
                    lbl_message2.ForeColor = Color.GreenYellow;
                }

                watch = Stopwatch.StartNew();
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (g_bmp1 == null || g_bmp2 == null)
                return;

            
            FormMain.GetInstance().StartProgressbar();

            Bitmap bmp1 = (Bitmap)g_bmp1.Clone();
            Bitmap bmp2 = (Bitmap)g_bmp2.Clone();



            FacialCompare result = Program.g_facecomp.Compare(bmp1, bmp2);
            e.Result = result;
            
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FormMain.GetInstance().StopProgressbar();

            
            watch.Stop();

            if (e.Result == null)
            {
                this.Enabled = true;
                return;
            }
                

            FacialCompare result = (FacialCompare)e.Result;

            if (result.isSamePerson)
            {
                lbl_result.Text = "Same";
                lbl_result.ForeColor = Color.GreenYellow;
            }
            else
            {
                lbl_result.Text = "Not same";
                lbl_result.ForeColor = Color.Red;
            }

            lbl_result.Text += " (" + result.percent + "%)";

            if (result.bitmapDraw1 != null)
                picCamera1.Image = result.bitmapDraw1;
            if (result.bitmapDraw2 != null)
                picCamera2.Image = result.bitmapDraw2;


            if (result.error != "")
            {
                FormMain.GetInstance().PrintError(result.error);
            }
            else
            {
                FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds + " ms");
            }

            this.Enabled = true;
        }
    }
}
