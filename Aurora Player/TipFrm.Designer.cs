namespace Aurora_Player
{
    partial class TipFrm
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
            this.dSkinLabel_Tip = new DSkin.Controls.DSkinLabel();
            this.dSkinPictureBox1 = new DSkin.Controls.DSkinPictureBox();
            this.SuspendLayout();
            // 
            // dSkinLabel_Tip
            // 
            this.dSkinLabel_Tip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dSkinLabel_Tip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel_Tip.ForeColor = System.Drawing.Color.Fuchsia;
            this.dSkinLabel_Tip.Location = new System.Drawing.Point(22, 6);
            this.dSkinLabel_Tip.Name = "dSkinLabel_Tip";
            this.dSkinLabel_Tip.Size = new System.Drawing.Size(55, 21);
            this.dSkinLabel_Tip.TabIndex = 4;
            this.dSkinLabel_Tip.Text = "小提示";
            this.dSkinLabel_Tip.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.dSkinLabel_Tip.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // dSkinPictureBox1
            // 
            this.dSkinPictureBox1.Image = global::Aurora_Player.Properties.Resources.Tips24;
            this.dSkinPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::Aurora_Player.Properties.Resources.Tips24))};
            this.dSkinPictureBox1.Interval = 40;
            this.dSkinPictureBox1.Location = new System.Drawing.Point(0, 3);
            this.dSkinPictureBox1.Name = "dSkinPictureBox1";
            this.dSkinPictureBox1.Size = new System.Drawing.Size(24, 24);
            this.dSkinPictureBox1.TabIndex = 5;
            this.dSkinPictureBox1.Text = "dSkinPictureBox1";
            // 
            // TipFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(660, 30);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinPictureBox1);
            this.Controls.Add(this.dSkinLabel_Tip);
            this.DrawIcon = false;
            this.Name = "TipFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowSystemButtons = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.Load += new System.EventHandler(this.TipFrm_Load);
            this.Shown += new System.EventHandler(this.TipFrm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox1;
        public DSkin.Controls.DSkinLabel dSkinLabel_Tip;
    }
}