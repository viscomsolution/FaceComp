namespace FaceCompDemo
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_folder = new System.Windows.Forms.Button();
            this.btn_person = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnWebcam = new System.Windows.Forms.Button();
            this.btn_compare = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lbl_version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btn_settings);
            this.panelMenu.Controls.Add(this.btn_folder);
            this.panelMenu.Controls.Add(this.btn_person);
            this.panelMenu.Controls.Add(this.progressBar1);
            this.panelMenu.Controls.Add(this.btnWebcam);
            this.panelMenu.Controls.Add(this.btn_compare);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 767);
            this.panelMenu.TabIndex = 16;
            // 
            // btn_settings
            // 
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_settings.FlatAppearance.BorderSize = 0;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_settings.Image")));
            this.btn_settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.Location = new System.Drawing.Point(0, 316);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_settings.Size = new System.Drawing.Size(200, 60);
            this.btn_settings.TabIndex = 9;
            this.btn_settings.Text = "   Settings";
            this.btn_settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Visible = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_folder
            // 
            this.btn_folder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_folder.FlatAppearance.BorderSize = 0;
            this.btn_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_folder.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_folder.Image = global::FaceCompDemo.Properties.Resources.folder_32px;
            this.btn_folder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_folder.Location = new System.Drawing.Point(0, 256);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_folder.Size = new System.Drawing.Size(200, 60);
            this.btn_folder.TabIndex = 10;
            this.btn_folder.Text = " Search in folder";
            this.btn_folder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_folder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // btn_person
            // 
            this.btn_person.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_person.FlatAppearance.BorderSize = 0;
            this.btn_person.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_person.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_person.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_person.Image = global::FaceCompDemo.Properties.Resources.users;
            this.btn_person.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_person.Location = new System.Drawing.Point(0, 196);
            this.btn_person.Name = "btn_person";
            this.btn_person.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_person.Size = new System.Drawing.Size(200, 60);
            this.btn_person.TabIndex = 8;
            this.btn_person.Text = " Persons";
            this.btn_person.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_person.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_person.UseVisualStyleBackColor = true;
            this.btn_person.Visible = false;
            this.btn_person.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 744);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnWebcam
            // 
            this.btnWebcam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWebcam.FlatAppearance.BorderSize = 0;
            this.btnWebcam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebcam.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnWebcam.Image = ((System.Drawing.Image)(resources.GetObject("btnWebcam.Image")));
            this.btnWebcam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebcam.Location = new System.Drawing.Point(0, 136);
            this.btnWebcam.Name = "btnWebcam";
            this.btnWebcam.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnWebcam.Size = new System.Drawing.Size(200, 60);
            this.btnWebcam.TabIndex = 2;
            this.btnWebcam.Text = " Webcam realtime";
            this.btnWebcam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebcam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWebcam.UseVisualStyleBackColor = true;
            this.btnWebcam.Click += new System.EventHandler(this.btnWebcam_Click);
            // 
            // btn_compare
            // 
            this.btn_compare.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_compare.FlatAppearance.BorderSize = 0;
            this.btn_compare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_compare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_compare.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_compare.Image = ((System.Drawing.Image)(resources.GetObject("btn_compare.Image")));
            this.btn_compare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_compare.Location = new System.Drawing.Point(0, 76);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_compare.Size = new System.Drawing.Size(200, 60);
            this.btn_compare.TabIndex = 1;
            this.btn_compare.Text = " Compare 2 faces";
            this.btn_compare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_compare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(72)))), ((int)(((byte)(51)))));
            this.panelLogo.Controls.Add(this.lbl_version);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 76);
            this.panelLogo.TabIndex = 0;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.ForeColor = System.Drawing.Color.White;
            this.lbl_version.Location = new System.Drawing.Point(86, 46);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(62, 21);
            this.lbl_version.TabIndex = 2;
            this.lbl_version.Text = "Version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(81, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "FaceComp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 767);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1187, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(987, 767);
            this.panelDesktop.TabIndex = 17;
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Enabled = true;
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 300000;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 789);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Phần mềm nhận diện khuôn mặt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnWebcam;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btn_person;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button btn_folder;
    }
}