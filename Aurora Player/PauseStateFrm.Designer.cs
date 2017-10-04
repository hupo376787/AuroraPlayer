namespace Aurora_Player
{
    partial class PauseStateFrm
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
            this.dSkinPictureBox_Pause = new DSkin.Controls.DSkinPictureBox();
            this.SuspendLayout();
            // 
            // dSkinPictureBox_Pause
            // 
            this.dSkinPictureBox_Pause.Image = null;
            this.dSkinPictureBox_Pause.Images = null;
            this.dSkinPictureBox_Pause.Interval = 40;
            this.dSkinPictureBox_Pause.Location = new System.Drawing.Point(0, 0);
            this.dSkinPictureBox_Pause.Name = "dSkinPictureBox_Pause";
            this.dSkinPictureBox_Pause.Size = new System.Drawing.Size(256, 256);
            this.dSkinPictureBox_Pause.TabIndex = 0;
            this.dSkinPictureBox_Pause.Text = "dSkinPictureBox1";
            this.dSkinPictureBox_Pause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox_Pause_MouseDown);
            this.dSkinPictureBox_Pause.MouseLeave += new System.EventHandler(this.dSkinPictureBox_Pause_MouseLeave);
            this.dSkinPictureBox_Pause.MouseHover += new System.EventHandler(this.dSkinPictureBox_Pause_MouseHover);
            // 
            // PauseStateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinPictureBox_Pause);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Name = "PauseStateFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.PauseStateFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinPictureBox dSkinPictureBox_Pause;
    }
}