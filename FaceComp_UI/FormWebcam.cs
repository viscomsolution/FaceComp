using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TGMTcs;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using UI;

namespace FaceCompUI
{
    public partial class FormWebcam : Form
    {
        static FormWebcam m_instance;
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        private static Random random = new Random();
        Stopwatch watch;
        DateTime m_lastTimePlaySound = DateTime.Now;
        bool m_isBusy = false;
        FaceMesh.FaceAngle m_lastFaceAngle = FaceMesh.FaceAngle.Unknown;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormWebcam()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormWebcam GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormWebcam();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_Load(object sender, EventArgs e)
        {
            InitCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
            cbCamera.Enabled = true;
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

            if (eventArgs.Frame == null)
                return;

            g_bmp = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = (Bitmap)eventArgs.Frame.Clone();

            FaceMesh facemesh = Program.g_facecomp.DetectAndDrawFaceMesh((Bitmap)eventArgs.Frame.Clone());



            if (facemesh.bitmapDraw != null)
            {
                picResult.Image = facemesh.bitmapDraw;
            }
            if (facemesh.faceAngle == FaceMesh.FaceAngle.Straight && m_lastFaceAngle != FaceMesh.FaceAngle.Straight)
            {
                TGMTsound.PlaySound("sfx_counter_0.wav");
                m_lastTimePlaySound = DateTime.Now;

                Recognize();
            }


            m_lastFaceAngle = facemesh.faceAngle;
        }      

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if(cbCamera.Items.Count == 1)
                {
                    cbCamera.SelectedIndex = 0;
                }
            }
            else
            {
                StopAllCamera();
                cbCamera.SelectedIndex = -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopAllCamera()
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            picCamera.Image = null;
            picResult.Image = null;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Recognize()
        {
            if (m_isBusy)
                return;

            m_isBusy = true;
            
            this.Invoke(new Action(() =>
            {
                FormMain.GetInstance().StartProgressbar();
                try
                {
                    Bitmap bmp = (Bitmap)g_bmp.Clone();
                    if (bmp == null)
                    {
                        FormMain.GetInstance().StopProgressbar();
                        m_isBusy = false;
                        return;
                    }
                    Appear appear = Program.g_facecomp.AddAppear(bmp);

                    if (appear.personID == "")
                    {
                        lbl_result.Text = "Not found";
                    }
                    else
                    {
                        lbl_result.Text = appear.personID;

                        UCface ucFace = new UCface();
                        ucFace.picResult.Image = (Bitmap)appear.bitmapDraw.Clone();
                        ucFace.lbl_personID.Text = appear.personID + " (" + appear.percent + "%)";
                        ucFace.lbl_personID.ForeColor = appear.isExist ? Color.Green : Color.Blue;
                        ucFace.lbl_time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        panelResult.Controls.Add(ucFace);
                        FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                FormMain.GetInstance().StopProgressbar();
            }));
            

            m_isBusy = false;
            
            
        }
     
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_clear_Click(object sender, EventArgs e)
        {
            panelResult.Controls.Clear();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAllCamera();
        }
    }
}
