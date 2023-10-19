using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace FaceCompDemo
{
    public partial class FormFolder : Form
    {
        static FormFolder m_instance;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");
            txt_noFaceDir.Text = TGMTregistry.GetInstance().ReadString("txt_noFaceDir");
            txt_sameFaceDir.Text = TGMTregistry.GetInstance().ReadString("txt_sameFaceDir");
            txt_differentFaceDir.Text = TGMTregistry.GetInstance().ReadString("txt_differentFaceDir");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormFolder GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormFolder();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            txt_fileName.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName_TextChanged(object sender, EventArgs e)
        {
            if (txt_fileName.Text == "")
                return;

            btnDetect.Enabled = false;

            string fileName = txt_fileName.Text.Replace("\"", "");
            lbl_result.Text = "";
            FormMain.GetInstance().StartProgressbar();

            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
            bmp = TGMTimage.CorrectOrientation(bmp);
            if (bmp != null)
            {
                picResult.Image = bmp;
                FormMain.GetInstance().PrintMessage("");

                Rectangle[] rects = Program.g_facecomp.Detect((Bitmap)bmp.Clone());

                FormMain.GetInstance().StopProgressbar();

                if (rects.Length == 0)
                {
                    lbl_result.Text = "No face";
                    lbl_result.ForeColor = Color.Red;
                    
                    return;
                }
                else if(rects.Length > 1)
                {
                    lbl_result.Text = rects.Length + " face";
                    lbl_result.ForeColor = Color.Red;
                }
                else
                {
                    lbl_result.Text = rects.Length + " face";
                    lbl_result.ForeColor = Color.GreenYellow;
                    btnDetect.Enabled = true;
                }
            }

            FormMain.GetInstance().StopProgressbar();
        }
    

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            lstImage.Items.Clear();

            string[] fileList = Directory.GetFiles(txtFolderInput.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> files = (List<string>)e.Result;
            for (int i = 0; i < files.Count; i++)
            {
                lstImage.Items.Add(files[i]);
            }
            FormMain.GetInstance().PrintMessage("Loaded " + lstImage.Items.Count + " images");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstImage.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                DisplayResultImage();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (lstImage.Items.Count == 0 || lstImage.SelectedItems.Count == 0)
            {
                return;
            }

            string fileName = lstImage.SelectedItems[0].Text;


            string inputDir = TGMTutil.CorrectPath(txtFolderInput.Text);
            string noFaceDir = TGMTutil.CorrectPath(txt_noFaceDir.Text);
            string sameFaceDir = TGMTutil.CorrectPath(txt_sameFaceDir.Text);
            string differentFaceDir = TGMTutil.CorrectPath(txt_differentFaceDir.Text);



            if (File.Exists(inputDir + fileName))
            {
                picResult.Image = TGMTimage.LoadBitmapWithoutLock(inputDir + fileName);
                FormMain.GetInstance().PrintMessage(inputDir + fileName);
            }
            else if (File.Exists(noFaceDir + fileName))
            {
                picResult.Image = TGMTimage.LoadBitmapWithoutLock(noFaceDir + fileName);
                FormMain.GetInstance().PrintMessage(noFaceDir + fileName);
            }
            else if (File.Exists(sameFaceDir + fileName))
            {
                picResult.Image = TGMTimage.LoadBitmapWithoutLock(sameFaceDir + fileName);
                FormMain.GetInstance().PrintMessage(sameFaceDir + fileName);
            }
            else if (File.Exists(differentFaceDir + fileName))
            {
                picResult.Image = TGMTimage.LoadBitmapWithoutLock(differentFaceDir + fileName);
                FormMain.GetInstance().PrintMessage(differentFaceDir + fileName);
            }
            else
            {
                FormMain.GetInstance().PrintError("File " + fileName + " does not exist");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResultImage();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderInput_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderInput.Text))
                return;

            TGMTregistry.GetInstance().SaveValue("folderInput", txtFolderInput.Text);
            FormMain.GetInstance().PrintMessage("Loading files...");
            lstImage.Items.Clear();
            bgLoadFile.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (!File.Exists(filePath))
            {
                FormMain.GetInstance().PrintMessage("File does not exist");

            }


            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(filePath);
                FormMain.GetInstance().PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(filePath);
                Clipboard.SetFileDropList(paths);
                FormMain.GetInstance().PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.ClickedItem.Name == "btnDelete")
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string inputPath = "";
            if (txtFolderInput.Text != "")
                inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);

            string noFaceDir = "";
            if (txt_noFaceDir.Text != "")
                noFaceDir = TGMTutil.CorrectPath(txt_noFaceDir.Text);

            string sameFaceDir = "";
            if (txt_sameFaceDir.Text != "")
                sameFaceDir = TGMTutil.CorrectPath(txt_sameFaceDir.Text);

            string differentDir = "";
            if (txt_differentFaceDir.Text != "")
                differentDir = TGMTutil.CorrectPath(txt_differentFaceDir.Text);

            int exactlyCount = 0;

            

            for (int i = 0; i < lstImage.Items.Count; i++)
            {
                if (bgWorker1.CancellationPending)
                    return;
                //bgWorker1.ReportProgress(i + 1);

                //Program.reader.OutputFileName = lstImage.Items[i].Text;

                string fileName = lstImage.Items[i].Text;
                string filePath = inputPath + fileName;

                if (txt_fileName.Text == filePath)
                    continue;
                
                string ext = Path.GetExtension(fileName);
                string landmarkFile = fileName.Replace(ext, ".bin");
                string landmarkPath = inputPath + landmarkFile;

                FormMain.GetInstance().PrintMessage(i + " / " + lstImage.Items.Count + " " + filePath);                

                FacialCompare result = Program.g_facecomp.Compare(txt_fileName.Text, filePath, true);
               
                if (lstImage.Items[i].SubItems.Count == 1)
                {
                    lstImage.Items[i].SubItems.Add(result.percent.ToString());
                }
                else
                {
                    lstImage.Items[i].SubItems[1].Text = result.percent.ToString();
                }
                

                if (result.isSamePerson)
                {
                    lstImage.Items[i].ForeColor = Color.Green;
                    exactlyCount++;
                    if (chk_moveSameFace.Checked)
                    {
                        Task.Run(() => File.Move(filePath, sameFaceDir + fileName));
                        Task.Run(() => File.Move(landmarkPath, sameFaceDir + landmarkFile));                        
                    }
                }
                else
                {
                    if (result.errorCode == 204 || result.percent == 0) //face not found
                    {
                        lstImage.Items[i].ForeColor = Color.Red;
                        if (chk_moveNoFace.Checked)
                        {
                            Task.Run(() => File.Move(filePath, noFaceDir + fileName));
                            Task.Run(() => File.Move(landmarkPath, noFaceDir + landmarkFile));
                        }                            
                    }
                    else //different person
                    {
                        if (chk_moveDifferentFace.Checked)
                        {
                            Task.Run(() => File.Move(filePath, differentDir + fileName));
                            Task.Run(() => File.Move(landmarkPath, differentDir + landmarkFile));
                        }
                    }
                }
                

                lstImage.EnsureVisible(i);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FormMain.GetInstance().PrintMessage(e.ProgressPercentage + "/" + lstImage.Items.Count + "(" + (100 * e.ProgressPercentage / lstImage.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormMain.GetInstance().StopProgressbar();

            btnDetect.Text = "Start detect (F5)";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select folder contain label";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                txtFolderInput.Text = folderPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ch_moveNoFace_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_moveNoFace.Checked)
            {
                errorProvider1.Clear();

                if (txt_noFaceDir.Text == "")
                {
                    chk_moveNoFace.Checked = false;
                    FormMain.GetInstance().PrintError("No face directory is empty");
                }
                else if (!Directory.Exists(txt_noFaceDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_noFaceDir, "Dir does not exist");

                    chk_moveNoFace.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_noFaceDir", txt_noFaceDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_moveSameFace_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_moveSameFace.Checked)
            {
                errorProvider1.Clear();

                if (txt_sameFaceDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Same face directory is empty");
                    chk_moveSameFace.Checked = false;
                }
                else if (!Directory.Exists(txt_sameFaceDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_sameFaceDir, "Dir does not exist");
                    chk_moveSameFace.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_sameFaceDir", txt_sameFaceDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_moveDifferentFace_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_moveDifferentFace.Checked)
            {
                errorProvider1.Clear();

                if (txt_differentFaceDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chk_moveDifferentFace.Checked = false;
                }
                else if (!Directory.Exists(txt_differentFaceDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_differentFaceDir, "Dir does not exist");
                    chk_moveDifferentFace.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_differentFaceDir", txt_differentFaceDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (txt_fileName.Text == "")
                return;
            if (btnDetect.Text.Contains("Start"))
            {
                bgWorker1.RunWorkerAsync();
                btnDetect.Text = "Stop";
            }
            else
            {
                bgWorker1.CancelAsync();
                btnDetect.Text = "Start detect";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string ConvertToLandmarkPath(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            string landmarkPath = filePath.Replace(ext, ".bin");
            return landmarkPath;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1)
                return;
            
            ListView lv = (ListView)sender;

            //propriety SortOrder make me some problem on graphic layout
            //i use this tag to set last order
            if (lv.Tag == null || (int)lv.Tag > 0)
            {
                ListViewItem[] tmp = lv.Items.Cast<ListViewItem>().OrderBy(t => int.Parse(t.SubItems[e.Column].Text)).ToArray();
                lv.Items.Clear();
                lv.Items.AddRange(tmp);

                lv.Tag = -1;
            }
            else
            {
                ListViewItem[] tmp = lv.Items.Cast<ListViewItem>().OrderByDescending(t => int.Parse(t.SubItems[e.Column].Text)).ToArray();
                lv.Items.Clear();
                lv.Items.AddRange(tmp);

                lv.Tag = +1;
            }
            
        }
    }
}
