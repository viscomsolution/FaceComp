namespace FaceCompUI
{
    partial class FormFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSelectFolderInput = new System.Windows.Forms.Button();
            this.txtFolderInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grFolder = new System.Windows.Forms.GroupBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_differentFaceDir = new System.Windows.Forms.TextBox();
            this.chk_moveDifferentFace = new System.Windows.Forms.CheckBox();
            this.txt_sameFaceDir = new System.Windows.Forms.TextBox();
            this.chk_moveSameFace = new System.Windows.Forms.CheckBox();
            this.txt_noFaceDir = new System.Windows.Forms.TextBox();
            this.chk_moveNoFace = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picResult = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.grFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // bgWorker1
            // 
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // btnSelectFolderInput
            // 
            this.btnSelectFolderInput.Location = new System.Drawing.Point(396, 54);
            this.btnSelectFolderInput.Name = "btnSelectFolderInput";
            this.btnSelectFolderInput.Size = new System.Drawing.Size(24, 27);
            this.btnSelectFolderInput.TabIndex = 17;
            this.btnSelectFolderInput.Text = "...";
            this.btnSelectFolderInput.UseVisualStyleBackColor = true;
            this.btnSelectFolderInput.Click += new System.EventHandler(this.btnSelectFolderInput_Click);
            // 
            // txtFolderInput
            // 
            this.txtFolderInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderInput.Location = new System.Drawing.Point(119, 55);
            this.txtFolderInput.Name = "txtFolderInput";
            this.txtFolderInput.Size = new System.Drawing.Size(273, 25);
            this.txtFolderInput.TabIndex = 16;
            this.txtFolderInput.TextChanged += new System.EventHandler(this.txtFolderInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tìm trong folder";
            // 
            // btnDetect
            // 
            this.btnDetect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetect.Location = new System.Drawing.Point(877, 31);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(100, 52);
            this.btnDetect.TabIndex = 18;
            this.btnDetect.Text = "Start detect (F5)";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStrip1.Text = "Copy path";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // grFolder
            // 
            this.grFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.grFolder.Controls.Add(this.lbl_result);
            this.grFolder.Controls.Add(this.label3);
            this.grFolder.Controls.Add(this.btn_selectImage);
            this.grFolder.Controls.Add(this.txt_fileName);
            this.grFolder.Controls.Add(this.label1);
            this.grFolder.Controls.Add(this.txt_differentFaceDir);
            this.grFolder.Controls.Add(this.chk_moveDifferentFace);
            this.grFolder.Controls.Add(this.txt_sameFaceDir);
            this.grFolder.Controls.Add(this.btnDetect);
            this.grFolder.Controls.Add(this.chk_moveSameFace);
            this.grFolder.Controls.Add(this.btnSelectFolderInput);
            this.grFolder.Controls.Add(this.txtFolderInput);
            this.grFolder.Controls.Add(this.txt_noFaceDir);
            this.grFolder.Controls.Add(this.label2);
            this.grFolder.Controls.Add(this.chk_moveNoFace);
            this.grFolder.Controls.Add(this.label4);
            this.grFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grFolder.Location = new System.Drawing.Point(0, 0);
            this.grFolder.Name = "grFolder";
            this.grFolder.Size = new System.Drawing.Size(995, 161);
            this.grFolder.TabIndex = 33;
            this.grFolder.TabStop = false;
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_result.Location = new System.Drawing.Point(449, 116);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(76, 30);
            this.lbl_result.TabIndex = 23;
            this.lbl_result.Text = "Result";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ghi chú: phần mềm sẽ save landmark (*.bin) trong folder ảnh";
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(396, 18);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(24, 27);
            this.btn_selectImage.TabIndex = 21;
            this.btn_selectImage.Text = "...";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // txt_fileName
            // 
            this.txt_fileName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fileName.Location = new System.Drawing.Point(119, 19);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(273, 25);
            this.txt_fileName.TabIndex = 20;
            this.txt_fileName.TextChanged += new System.EventHandler(this.txt_fileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ảnh cần tìm";
            // 
            // txt_differentFaceDir
            // 
            this.txt_differentFaceDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_differentFaceDir.Location = new System.Drawing.Point(600, 77);
            this.txt_differentFaceDir.Name = "txt_differentFaceDir";
            this.txt_differentFaceDir.Size = new System.Drawing.Size(273, 25);
            this.txt_differentFaceDir.TabIndex = 17;
            // 
            // chk_moveDifferentFace
            // 
            this.chk_moveDifferentFace.AutoSize = true;
            this.chk_moveDifferentFace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_moveDifferentFace.ForeColor = System.Drawing.Color.White;
            this.chk_moveDifferentFace.Location = new System.Drawing.Point(429, 76);
            this.chk_moveDifferentFace.Name = "chk_moveDifferentFace";
            this.chk_moveDifferentFace.Size = new System.Drawing.Size(163, 23);
            this.chk_moveDifferentFace.TabIndex = 16;
            this.chk_moveDifferentFace.Text = "Move different face to";
            this.chk_moveDifferentFace.UseVisualStyleBackColor = true;
            this.chk_moveDifferentFace.CheckedChanged += new System.EventHandler(this.chk_moveDifferentFace_CheckedChanged);
            // 
            // txt_sameFaceDir
            // 
            this.txt_sameFaceDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sameFaceDir.Location = new System.Drawing.Point(600, 46);
            this.txt_sameFaceDir.Name = "txt_sameFaceDir";
            this.txt_sameFaceDir.Size = new System.Drawing.Size(273, 25);
            this.txt_sameFaceDir.TabIndex = 15;
            // 
            // chk_moveSameFace
            // 
            this.chk_moveSameFace.AutoSize = true;
            this.chk_moveSameFace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_moveSameFace.ForeColor = System.Drawing.Color.White;
            this.chk_moveSameFace.Location = new System.Drawing.Point(429, 47);
            this.chk_moveSameFace.Name = "chk_moveSameFace";
            this.chk_moveSameFace.Size = new System.Drawing.Size(144, 23);
            this.chk_moveSameFace.TabIndex = 14;
            this.chk_moveSameFace.Text = "Move same face to";
            this.chk_moveSameFace.UseVisualStyleBackColor = true;
            this.chk_moveSameFace.CheckedChanged += new System.EventHandler(this.chk_moveSameFace_CheckedChanged);
            // 
            // txt_noFaceDir
            // 
            this.txt_noFaceDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noFaceDir.Location = new System.Drawing.Point(600, 15);
            this.txt_noFaceDir.Name = "txt_noFaceDir";
            this.txt_noFaceDir.Size = new System.Drawing.Size(273, 25);
            this.txt_noFaceDir.TabIndex = 13;
            // 
            // chk_moveNoFace
            // 
            this.chk_moveNoFace.AutoSize = true;
            this.chk_moveNoFace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_moveNoFace.ForeColor = System.Drawing.Color.White;
            this.chk_moveNoFace.Location = new System.Drawing.Point(429, 15);
            this.chk_moveNoFace.Name = "chk_moveNoFace";
            this.chk_moveNoFace.Size = new System.Drawing.Size(149, 23);
            this.chk_moveNoFace.TabIndex = 12;
            this.chk_moveNoFace.Text = "Move file no face to";
            this.chk_moveNoFace.UseVisualStyleBackColor = true;
            this.chk_moveNoFace.CheckedChanged += new System.EventHandler(this.ch_moveNoFace_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lstImage
            // 
            this.lstImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstImage.ContextMenuStrip = this.contextMenuStrip1;
            this.lstImage.FullRowSelect = true;
            this.lstImage.GridLines = true;
            this.lstImage.HideSelection = false;
            this.lstImage.Location = new System.Drawing.Point(2, 167);
            this.lstImage.MultiSelect = false;
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(486, 290);
            this.lstImage.TabIndex = 34;
            this.lstImage.UseCompatibleStateImageBehavior = false;
            this.lstImage.View = System.Windows.Forms.View.Details;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image path";
            this.columnHeader1.Width = 272;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Percent";
            this.columnHeader2.Width = 154;
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(498, 167);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 290);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 32;
            this.picResult.TabStop = false;
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 471);
            this.Controls.Add(this.lstImage);
            this.Controls.Add(this.grFolder);
            this.Controls.Add(this.picResult);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.Load += new System.EventHandler(this.FormFolder_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.grFolder.ResumeLayout(false);
            this.grFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Button btnSelectFolderInput;
        private System.Windows.Forms.TextBox txtFolderInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.GroupBox grFolder;
        private System.Windows.Forms.TextBox txt_differentFaceDir;
        private System.Windows.Forms.CheckBox chk_moveDifferentFace;
        private System.Windows.Forms.TextBox txt_sameFaceDir;
        private System.Windows.Forms.CheckBox chk_moveSameFace;
        private System.Windows.Forms.TextBox txt_noFaceDir;
        private System.Windows.Forms.CheckBox chk_moveNoFace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListView lstImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_result;
    }
}