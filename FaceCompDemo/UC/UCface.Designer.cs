namespace UI
{
    partial class UCface
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picResult = new System.Windows.Forms.PictureBox();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_personID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(291, 164);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // lbl_time
            // 
            this.lbl_time.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(0, 195);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(291, 25);
            this.lbl_time.TabIndex = 1;
            this.lbl_time.Text = "2023";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_personID
            // 
            this.lbl_personID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_personID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_personID.Location = new System.Drawing.Point(0, 170);
            this.lbl_personID.Name = "lbl_personID";
            this.lbl_personID.Size = new System.Drawing.Size(291, 25);
            this.lbl_personID.TabIndex = 2;
            this.lbl_personID.Text = "69M1 035.69";
            this.lbl_personID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_personID);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.picResult);
            this.Name = "UCface";
            this.Size = new System.Drawing.Size(291, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lbl_time;
        public System.Windows.Forms.PictureBox picResult;
        public System.Windows.Forms.Label lbl_personID;
    }
}
