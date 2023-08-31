namespace FaceCompUI
{
    partial class FormCompare
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
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.txt_fileName2 = new System.Windows.Forms.TextBox();
            this.btn_select2 = new System.Windows.Forms.Button();
            this.txt_fileName1 = new System.Windows.Forms.TextBox();
            this.btn_select1 = new System.Windows.Forms.Button();
            this.btn_takePicture2 = new System.Windows.Forms.Button();
            this.cbCamera2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_takePicture1 = new System.Windows.Forms.Button();
            this.cbCamera1 = new System.Windows.Forms.ComboBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_message2 = new System.Windows.Forms.Label();
            this.picCamera2 = new System.Windows.Forms.PictureBox();
            this.lbl_message1 = new System.Windows.Forms.Label();
            this.picCamera1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panelLogo.Controls.Add(this.txt_fileName2);
            this.panelLogo.Controls.Add(this.btn_select2);
            this.panelLogo.Controls.Add(this.txt_fileName1);
            this.panelLogo.Controls.Add(this.btn_select1);
            this.panelLogo.Controls.Add(this.btn_takePicture2);
            this.panelLogo.Controls.Add(this.cbCamera2);
            this.panelLogo.Controls.Add(this.label4);
            this.panelLogo.Controls.Add(this.btn_takePicture1);
            this.panelLogo.Controls.Add(this.cbCamera1);
            this.panelLogo.Controls.Add(this.lbl_result);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(982, 131);
            this.panelLogo.TabIndex = 21;
            // 
            // txt_fileName2
            // 
            this.txt_fileName2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fileName2.Location = new System.Drawing.Point(520, 61);
            this.txt_fileName2.Name = "txt_fileName2";
            this.txt_fileName2.Size = new System.Drawing.Size(379, 25);
            this.txt_fileName2.TabIndex = 12;
            this.txt_fileName2.TextChanged += new System.EventHandler(this.txt_fileName2_TextChanged);
            // 
            // btn_select2
            // 
            this.btn_select2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.btn_select2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_select2.ForeColor = System.Drawing.Color.White;
            this.btn_select2.Location = new System.Drawing.Point(905, 55);
            this.btn_select2.Name = "btn_select2";
            this.btn_select2.Size = new System.Drawing.Size(41, 35);
            this.btn_select2.TabIndex = 11;
            this.btn_select2.Text = "...";
            this.btn_select2.UseVisualStyleBackColor = false;
            this.btn_select2.Click += new System.EventHandler(this.btn_select2_Click);
            // 
            // txt_fileName1
            // 
            this.txt_fileName1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fileName1.Location = new System.Drawing.Point(18, 61);
            this.txt_fileName1.Name = "txt_fileName1";
            this.txt_fileName1.Size = new System.Drawing.Size(381, 25);
            this.txt_fileName1.TabIndex = 10;
            this.txt_fileName1.TextChanged += new System.EventHandler(this.txt_fileName1_TextChanged);
            // 
            // btn_select1
            // 
            this.btn_select1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.btn_select1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_select1.ForeColor = System.Drawing.Color.White;
            this.btn_select1.Location = new System.Drawing.Point(405, 54);
            this.btn_select1.Name = "btn_select1";
            this.btn_select1.Size = new System.Drawing.Size(41, 35);
            this.btn_select1.TabIndex = 9;
            this.btn_select1.Text = "...";
            this.btn_select1.UseVisualStyleBackColor = false;
            this.btn_select1.Click += new System.EventHandler(this.btn_select1_Click);
            // 
            // btn_takePicture2
            // 
            this.btn_takePicture2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.btn_takePicture2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_takePicture2.ForeColor = System.Drawing.Color.White;
            this.btn_takePicture2.Location = new System.Drawing.Point(817, 14);
            this.btn_takePicture2.Name = "btn_takePicture2";
            this.btn_takePicture2.Size = new System.Drawing.Size(129, 35);
            this.btn_takePicture2.TabIndex = 7;
            this.btn_takePicture2.Text = "Chụp ảnh";
            this.btn_takePicture2.UseVisualStyleBackColor = false;
            this.btn_takePicture2.Click += new System.EventHandler(this.btn_takePicture2_Click);
            // 
            // cbCamera2
            // 
            this.cbCamera2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera2.FormattingEnabled = true;
            this.cbCamera2.Location = new System.Drawing.Point(602, 20);
            this.cbCamera2.Name = "cbCamera2";
            this.cbCamera2.Size = new System.Drawing.Size(209, 25);
            this.cbCamera2.TabIndex = 6;
            this.cbCamera2.SelectedIndexChanged += new System.EventHandler(this.cbCamera2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(516, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Webcam";
            // 
            // btn_takePicture1
            // 
            this.btn_takePicture1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.btn_takePicture1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_takePicture1.ForeColor = System.Drawing.Color.White;
            this.btn_takePicture1.Location = new System.Drawing.Point(317, 13);
            this.btn_takePicture1.Name = "btn_takePicture1";
            this.btn_takePicture1.Size = new System.Drawing.Size(129, 35);
            this.btn_takePicture1.TabIndex = 4;
            this.btn_takePicture1.Text = "Chụp ảnh";
            this.btn_takePicture1.UseVisualStyleBackColor = false;
            this.btn_takePicture1.Click += new System.EventHandler(this.btn_takePicture1_Click);
            // 
            // cbCamera1
            // 
            this.cbCamera1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera1.FormattingEnabled = true;
            this.cbCamera1.Location = new System.Drawing.Point(102, 19);
            this.cbCamera1.Name = "cbCamera1";
            this.cbCamera1.Size = new System.Drawing.Size(209, 25);
            this.cbCamera1.TabIndex = 3;
            this.cbCamera1.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_result.Location = new System.Drawing.Point(452, 94);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(76, 30);
            this.lbl_result.TabIndex = 2;
            this.lbl_result.Text = "Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Webcam";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.picWebcam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 386);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(183)))), ((int)(((byte)(110)))));
            this.panel2.Controls.Add(this.lbl_message2);
            this.panel2.Controls.Add(this.picCamera2);
            this.panel2.Controls.Add(this.lbl_message1);
            this.panel2.Controls.Add(this.picCamera1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 386);
            this.panel2.TabIndex = 26;
            // 
            // lbl_message2
            // 
            this.lbl_message2.AutoSize = true;
            this.lbl_message2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_message2.ForeColor = System.Drawing.Color.White;
            this.lbl_message2.Location = new System.Drawing.Point(703, 11);
            this.lbl_message2.Name = "lbl_message2";
            this.lbl_message2.Size = new System.Drawing.Size(83, 25);
            this.lbl_message2.TabIndex = 27;
            this.lbl_message2.Text = "Image 2";
            // 
            // picCamera2
            // 
            this.picCamera2.BackColor = System.Drawing.Color.White;
            this.picCamera2.Location = new System.Drawing.Point(489, 39);
            this.picCamera2.Name = "picCamera2";
            this.picCamera2.Size = new System.Drawing.Size(480, 320);
            this.picCamera2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera2.TabIndex = 26;
            this.picCamera2.TabStop = false;
            // 
            // lbl_message1
            // 
            this.lbl_message1.AutoSize = true;
            this.lbl_message1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_message1.ForeColor = System.Drawing.Color.White;
            this.lbl_message1.Location = new System.Drawing.Point(188, 11);
            this.lbl_message1.Name = "lbl_message1";
            this.lbl_message1.Size = new System.Drawing.Size(83, 25);
            this.lbl_message1.TabIndex = 25;
            this.lbl_message1.Text = "Image 1";
            // 
            // picCamera1
            // 
            this.picCamera1.BackColor = System.Drawing.Color.White;
            this.picCamera1.Location = new System.Drawing.Point(3, 39);
            this.picCamera1.Name = "picCamera1";
            this.picCamera1.Size = new System.Drawing.Size(480, 320);
            this.picCamera1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera1.TabIndex = 24;
            this.picCamera1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(188, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ảnh input";
            // 
            // picWebcam
            // 
            this.picWebcam.BackColor = System.Drawing.Color.White;
            this.picWebcam.Location = new System.Drawing.Point(21, 63);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(480, 320);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebcam.TabIndex = 24;
            this.picWebcam.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormCompare";
            this.Text = "So sánh 2 khuôn mặt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWebcam_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.FormWebcam_VisibleChanged);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_message1;
        private System.Windows.Forms.PictureBox picCamera1;
        private System.Windows.Forms.ComboBox cbCamera1;
        private System.Windows.Forms.Button btn_takePicture1;
        private System.Windows.Forms.PictureBox picCamera2;
        private System.Windows.Forms.Button btn_takePicture2;
        private System.Windows.Forms.ComboBox cbCamera2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fileName2;
        private System.Windows.Forms.Button btn_select2;
        private System.Windows.Forms.TextBox txt_fileName1;
        private System.Windows.Forms.Button btn_select1;
        private System.Windows.Forms.Label lbl_message2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

