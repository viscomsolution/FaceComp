using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace FaceCompDemo
{
    public partial class FormMain : Form
    {
        
        static FormMain m_instance;
        Button currentButton;
        Form activeForm;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormMain GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormMain();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_Load(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("FaceComp");

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            StartProgressbar();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.g_facecomp = new FaceComp();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            StopProgressbar();

            this.Text += Program.g_facecomp.HasLicense ? " (Licensed)" : " (Vui lòng liên hệ: 0939.825.125)";

            lbl_version.Text = Program.g_facecomp.GetVersion();

            string childform = TGMTregistry.GetInstance().ReadString("childform");
            if (childform == "" || childform == "FormImage")
                btn_compare.PerformClick();
            else if (childform == "FormWebcam")
                btnWebcam.PerformClick();
            else if (childform == "FormCompare")
                btn_compare.PerformClick();
            else if (childform == "FormFolder")
                btn_folder.PerformClick();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnWebcam_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormWebcam.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_compare_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormCompare.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_folder_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormFolder.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_settings_Click(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;

            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            ActiveButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            TGMTregistry.GetInstance().SaveValue("childform", childForm.Name);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;

                    Color color = SelectThemeColor(currentButton);
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Color SelectThemeColor(Button btn)
        {
            int index = FindIndexOfBtn(btn);
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int FindIndexOfBtn(Button btn)
        {
            int index = -1;
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    index++;
                    if ((Button)ctrl == btn)
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartProgressbar()
        {
            this.Invoke(new Action(() =>
            {
                timerProgressbar.Start();
            }));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopProgressbar()
        {
            this.Invoke(new Action(() =>
            {
                timerProgressbar.Stop();
                progressBar1.Value = progressBar1.Minimum;
            }));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(activeForm != null)
                activeForm.Close();
        }

        
    }
}