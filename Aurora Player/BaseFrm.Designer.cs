namespace Aurora_Player
{
    partial class BaseFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFrm));
            this.SuspendLayout();
            // 
            // BaseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxBox.NormalColor = System.Drawing.Color.White;
            this.MaxBox.Size = new System.Drawing.Size(30, 22);
            this.MinBox.NormalColor = System.Drawing.Color.White;
            this.MinBox.Size = new System.Drawing.Size(30, 22);
            this.Name = "BaseFrm";
            this.NormalBox.NormalColor = System.Drawing.Color.White;
            this.NormalBox.Size = new System.Drawing.Size(30, 22);
            this.ShowInTaskbar = false;
            this.Text = "BaseFrm";
            this.ResumeLayout(false);

        }

        #endregion
    }
}