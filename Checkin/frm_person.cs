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
    public partial class frm_person : Form
    {
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        float g_scaleX = 1;
        float g_scaleY = 1;

        public frm_person()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frm_person_Load(object sender, EventArgs e)
        {
            string[] dirList = Program.g_facecomp.GetDirList();

            foreach (string dir in dirList)
            {
                string dirName = Path.GetFileName(dir);
                listView1.Items.Add(dirName);
            }

            txt_parentDir.Text = Program.g_parentDir;

            InitCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_capture_Click(object sender, EventArgs e)
        {
            StopAllCamera();
            cbCamera.SelectedIndex = -1;
            btn_capture.Enabled = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera();
            btn_capture.Enabled = true;
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

        void StopAllCamera()
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            btn_save.Enabled = true;
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            PrintMessage("");
            if (txt_folder.Text == "")
            {
                PrintError("Chưa chọn folder để save");
                return;
            }

            string personDir = txt_parentDir.Text + "\\" + txt_folder.Text;
            if (!Directory.Exists(personDir))
            {
                Directory.CreateDirectory(personDir);
            }

            string imagePath = personDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";

            g_bmp.Save(imagePath);
            Program.g_facecomp.SaveLandmarkAsync(imagePath);

            PrintSuccess("Save thành công");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_parentDir_TextChanged(object sender, EventArgs e)
        {
            Program.g_facecomp.LoadFaceInDir(txt_parentDir.Text);
            string[] dirList = Program.g_facecomp.GetDirList();

            foreach (string dir in dirList)
            {
                string dirName = Path.GetFileName(dir);
                listView1.Items.Add(dirName);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frm_person_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.g_parentDir = txt_parentDir.Text;
            TGMTregistry.GetInstance().SaveValue("parentDir", Program.g_parentDir);
        }
    }

    
}
