namespace FaceCompDemo
{
    partial class FormWebcam
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
            this.panelLogo = new System.Windows.Forms.Panel();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(183)))), ((int)(((byte)(110)))));
            this.panelLogo.Controls.Add(this.cbCamera);
            this.panelLogo.Controls.Add(this.lbl_result);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(1035, 57);
            this.panelLogo.TabIndex = 21;
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(102, 19);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(264, 25);
            this.cbCamera.TabIndex = 3;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.Color.White;
            this.lbl_result.Location = new System.Drawing.Point(383, 19);
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
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 598);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.picResult);
            this.panel2.Controls.Add(this.btn_clear);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panelResult);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.picCamera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 598);
            this.panel2.TabIndex = 26;
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Location = new System.Drawing.Point(3, 314);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 267);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 28;
            this.picResult.TabStop = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(788, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(129, 35);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(689, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "Results";
            // 
            // panelResult
            // 
            this.panelResult.AutoScroll = true;
            this.panelResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelResult.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.panelResult.Location = new System.Drawing.Point(489, 39);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(490, 542);
            this.panelResult.TabIndex = 26;
            this.panelResult.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(188, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Webcam";
            // 
            // picCamera
            // 
            this.picCamera.BackColor = System.Drawing.Color.White;
            this.picCamera.Location = new System.Drawing.Point(3, 39);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(480, 267);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera.TabIndex = 24;
            this.picCamera.TabStop = false;
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
            // FormWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 655);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormWebcam";
            this.Text = "Nhận diện khuôn mặt từ webcam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWebcam_FormClosed);
            this.Load += new System.EventHandler(this.FormWebcam_Load);
            this.VisibleChanged += new System.EventHandler(this.FormWebcam_VisibleChanged);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.FlowLayoutPanel panelResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox picResult;
    }
}

