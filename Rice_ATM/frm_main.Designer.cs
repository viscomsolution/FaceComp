namespace Checkin
{
    partial class frm_findPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_findPerson));
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhSáchKhuônMặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.lblBoard = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_personID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pic_result = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picTaken = new System.Windows.Forms.PictureBox();
            this.btn_capture = new System.Windows.Forms.Button();
            this.rdAuto = new System.Windows.Forms.RadioButton();
            this.rdTrigger = new System.Windows.Forms.RadioButton();
            this.btn_trigger = new System.Windows.Forms.Button();
            this.btn_connectBoard = new System.Windows.Forms.Button();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_numDay = new System.Windows.Forms.TextBox();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTaken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // picWebcam
            // 
            this.picWebcam.Location = new System.Drawing.Point(16, 129);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(400, 220);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebcam.TabIndex = 10;
            this.picWebcam.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchKhuônMặtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhSáchKhuônMặtToolStripMenuItem
            // 
            this.danhSáchKhuônMặtToolStripMenuItem.Enabled = false;
            this.danhSáchKhuônMặtToolStripMenuItem.Name = "danhSáchKhuônMặtToolStripMenuItem";
            this.danhSáchKhuônMặtToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.danhSáchKhuônMặtToolStripMenuItem.Text = "Danh sách khuôn mặt";
            this.danhSáchKhuônMặtToolStripMenuItem.Click += new System.EventHandler(this.danhSáchKhuônMặtToolStripMenuItem_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(89, 37);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(224, 24);
            this.cbCamera.TabIndex = 12;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Webcam";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // lblBoard
            // 
            this.lblBoard.AutoSize = true;
            this.lblBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoard.Location = new System.Drawing.Point(451, 39);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(52, 20);
            this.lblBoard.TabIndex = 28;
            this.lblBoard.Text = "Board";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(430, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mã số";
            // 
            // txt_personID
            // 
            this.txt_personID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_personID.Location = new System.Drawing.Point(607, 187);
            this.txt_personID.Name = "txt_personID";
            this.txt_personID.ReadOnly = true;
            this.txt_personID.Size = new System.Drawing.Size(232, 38);
            this.txt_personID.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(594, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ảnh giống nhất";
            // 
            // txt_time
            // 
            this.txt_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_time.Location = new System.Drawing.Point(439, 311);
            this.txt_time.Name = "txt_time";
            this.txt_time.ReadOnly = true;
            this.txt_time.Size = new System.Drawing.Size(400, 38);
            this.txt_time.TabIndex = 21;
            // 
            // lbl_percent
            // 
            this.lbl_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_percent.Location = new System.Drawing.Point(439, 103);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(414, 91);
            this.lbl_percent.TabIndex = 19;
            this.lbl_percent.Text = "Kết quả";
            this.lbl_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(430, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 31);
            this.label4.TabIndex = 20;
            this.label4.Text = "Lần gần nhất";
            // 
            // pic_result
            // 
            this.pic_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_result.Location = new System.Drawing.Point(439, 382);
            this.pic_result.Name = "pic_result";
            this.pic_result.Size = new System.Drawing.Size(400, 223);
            this.pic_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_result.TabIndex = 17;
            this.pic_result.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ảnh chụp";
            // 
            // picTaken
            // 
            this.picTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTaken.Location = new System.Drawing.Point(16, 382);
            this.picTaken.Name = "picTaken";
            this.picTaken.Size = new System.Drawing.Size(400, 223);
            this.picTaken.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTaken.TabIndex = 16;
            this.picTaken.TabStop = false;
            // 
            // btn_capture
            // 
            this.btn_capture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_capture.Enabled = false;
            this.btn_capture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capture.Location = new System.Drawing.Point(214, 70);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(99, 35);
            this.btn_capture.TabIndex = 16;
            this.btn_capture.Text = "Chụp ảnh";
            this.btn_capture.UseVisualStyleBackColor = false;
            this.btn_capture.Click += new System.EventHandler(this.btn_capture_Click);
            // 
            // rdAuto
            // 
            this.rdAuto.AutoSize = true;
            this.rdAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAuto.Location = new System.Drawing.Point(16, 78);
            this.rdAuto.Name = "rdAuto";
            this.rdAuto.Size = new System.Drawing.Size(79, 21);
            this.rdAuto.TabIndex = 26;
            this.rdAuto.Text = "Tự động";
            this.rdAuto.UseVisualStyleBackColor = true;
            this.rdAuto.CheckedChanged += new System.EventHandler(this.rdAuto_CheckedChanged);
            // 
            // rdTrigger
            // 
            this.rdTrigger.AutoSize = true;
            this.rdTrigger.Checked = true;
            this.rdTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTrigger.Location = new System.Drawing.Point(111, 78);
            this.rdTrigger.Name = "rdTrigger";
            this.rdTrigger.Size = new System.Drawing.Size(86, 21);
            this.rdTrigger.TabIndex = 27;
            this.rdTrigger.TabStop = true;
            this.rdTrigger.Text = "Thủ công";
            this.rdTrigger.UseVisualStyleBackColor = true;
            this.rdTrigger.CheckedChanged += new System.EventHandler(this.rdTrigger_CheckedChanged);
            // 
            // btn_trigger
            // 
            this.btn_trigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trigger.Location = new System.Drawing.Point(330, 70);
            this.btn_trigger.Name = "btn_trigger";
            this.btn_trigger.Size = new System.Drawing.Size(86, 35);
            this.btn_trigger.TabIndex = 28;
            this.btn_trigger.Text = "Phát gạo";
            this.btn_trigger.UseVisualStyleBackColor = true;
            this.btn_trigger.Click += new System.EventHandler(this.btn_trigger_Click);
            // 
            // btn_connectBoard
            // 
            this.btn_connectBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connectBoard.Location = new System.Drawing.Point(708, 37);
            this.btn_connectBoard.Name = "btn_connectBoard";
            this.btn_connectBoard.Size = new System.Drawing.Size(129, 34);
            this.btn_connectBoard.TabIndex = 29;
            this.btn_connectBoard.Text = "Connect board";
            this.btn_connectBoard.UseVisualStyleBackColor = true;
            this.btn_connectBoard.Visible = false;
            this.btn_connectBoard.Click += new System.EventHandler(this.btn_connectBoard_Click);
            // 
            // numDay
            // 
            this.numDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDay.Location = new System.Drawing.Point(524, 65);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(60, 23);
            this.numDay.TabIndex = 30;
            this.numDay.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numDay.ValueChanged += new System.EventHandler(this.numDay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(451, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Số ngày";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(430, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 31);
            this.label7.TabIndex = 32;
            this.label7.Text = "Số ngày";
            // 
            // txt_numDay
            // 
            this.txt_numDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numDay.Location = new System.Drawing.Point(607, 231);
            this.txt_numDay.Name = "txt_numDay";
            this.txt_numDay.ReadOnly = true;
            this.txt_numDay.Size = new System.Drawing.Size(232, 38);
            this.txt_numDay.TabIndex = 33;
            // 
            // timerAuto
            // 
            this.timerAuto.Interval = 500;
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // frm_findPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 645);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_numDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDay);
            this.Controls.Add(this.btn_connectBoard);
            this.Controls.Add(this.lblBoard);
            this.Controls.Add(this.btn_trigger);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdTrigger);
            this.Controls.Add(this.txt_personID);
            this.Controls.Add(this.rdAuto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_capture);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_percent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.picWebcam);
            this.Controls.Add(this.pic_result);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picTaken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_findPerson";
            this.Text = "Phần mềm điểm danh khuôn mặt sử dụng module FaceComp x64";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTaken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.PictureBox pic_result;
        private System.Windows.Forms.PictureBox picTaken;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem danhSáchKhuônMặtToolStripMenuItem;
        private System.Windows.Forms.Button btn_capture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_personID;
        private System.Windows.Forms.RadioButton rdAuto;
        private System.Windows.Forms.RadioButton rdTrigger;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Button btn_trigger;
        private System.Windows.Forms.Button btn_connectBoard;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_numDay;
        private System.Windows.Forms.Timer timerAuto;
    }
}

