namespace Aurora_Player
{
    partial class TimeLineFrm
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
            this.dSkinLabel_Preview = new DSkin.Controls.DSkinLabel();
            this.SuspendLayout();
            // 
            // dSkinLabel_Preview
            // 
            this.dSkinLabel_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinLabel_Preview.Location = new System.Drawing.Point(8, 9);
            this.dSkinLabel_Preview.Name = "dSkinLabel_Preview";
            this.dSkinLabel_Preview.Size = new System.Drawing.Size(54, 14);
            this.dSkinLabel_Preview.TabIndex = 1;
            this.dSkinLabel_Preview.Text = "00:00:00";
            this.dSkinLabel_Preview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeLineFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(70, 30);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinLabel_Preview);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "TimeLineFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.TimeLineFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DSkin.Controls.DSkinLabel dSkinLabel_Preview;
    }
}