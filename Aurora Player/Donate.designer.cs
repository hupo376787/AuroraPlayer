namespace Aurora_Player
{
    partial class Donate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donate));
            this.dSkinPictureBox1 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinPictureBox2 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.TVUrl = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBox1 = new DSkin.DirectUI.DuiTextBox();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.SuspendLayout();
            // 
            // dSkinPictureBox1
            // 
            this.dSkinPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dSkinPictureBox1.Image = global::Aurora_Player.Properties.Resources.微信;
            this.dSkinPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::Aurora_Player.Properties.Resources.微信))};
            this.dSkinPictureBox1.Interval = 40;
            this.dSkinPictureBox1.Location = new System.Drawing.Point(41, 135);
            this.dSkinPictureBox1.Name = "dSkinPictureBox1";
            this.dSkinPictureBox1.Size = new System.Drawing.Size(200, 200);
            this.dSkinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dSkinPictureBox1.TabIndex = 30;
            this.dSkinPictureBox1.Text = "dSkinPictureBox1";
            this.dSkinPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox1_MouseDown);
            // 
            // dSkinPictureBox2
            // 
            this.dSkinPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinPictureBox2.Image = global::Aurora_Player.Properties.Resources.支付宝;
            this.dSkinPictureBox2.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::Aurora_Player.Properties.Resources.支付宝))};
            this.dSkinPictureBox2.Interval = 40;
            this.dSkinPictureBox2.Location = new System.Drawing.Point(331, 135);
            this.dSkinPictureBox2.Name = "dSkinPictureBox2";
            this.dSkinPictureBox2.Size = new System.Drawing.Size(200, 200);
            this.dSkinPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dSkinPictureBox2.TabIndex = 31;
            this.dSkinPictureBox2.Text = "dSkinPictureBox2";
            this.dSkinPictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox2_MouseDown);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dSkinLabel1.Location = new System.Drawing.Point(93, 109);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(105, 21);
            this.dSkinLabel1.TabIndex = 32;
            this.dSkinLabel1.Text = "微信扫码赞助";
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dSkinLabel2.Location = new System.Drawing.Point(375, 109);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(121, 21);
            this.dSkinLabel2.TabIndex = 33;
            this.dSkinLabel2.Text = "支付宝扫码赞助";
            // 
            // TVUrl
            // 
            this.TVUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TVUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TVUrl.DUIControls.Add(this.duiTextBox1);
            this.TVUrl.Location = new System.Drawing.Point(11, 28);
            this.TVUrl.Name = "TVUrl";
            this.TVUrl.Size = new System.Drawing.Size(554, 76);
            this.TVUrl.TabIndex = 35;
            this.TVUrl.Text = "dSkinBaseControl1";
            // 
            // duiTextBox1
            // 
            this.duiTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duiTextBox1.AutoSize = false;
            this.duiTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.duiTextBox1.Controls.Add(this.duiTextBox1.InnerScrollBar);
            this.duiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.duiTextBox1.Enabled = false;
            this.duiTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiTextBox1.Location = new System.Drawing.Point(0, 0);
            this.duiTextBox1.Multiline = true;
            this.duiTextBox1.Name = "duiTextBox1";
            this.duiTextBox1.ReadOnly = true;
            this.duiTextBox1.Size = new System.Drawing.Size(550, 74);
            this.duiTextBox1.Text = "      Aurora Player 是由Aurora团队开发的免费软件。我们目前没有任何资金收入、您的资助可以帮助\nAurora的后续开发，捐赠资金将用于硬件" +
    "、软件、主机托管和其他的维护费用。 \n\n      衷心感谢您支持Aurora的开发工作，无论多寡，均弥足珍贵。我们将会在Aurora Player 官网不定期" +
    "更新赞助者名单，再次感谢您的支持！";
            this.duiTextBox1.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiTextBox1_MouseDown);
            // 
            // dSkinLabel3
            // 
            this.dSkinLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinLabel3.AutoSize = false;
            this.dSkinLabel3.Location = new System.Drawing.Point(7, 343);
            this.dSkinLabel3.Name = "dSkinLabel3";
            this.dSkinLabel3.Size = new System.Drawing.Size(474, 16);
            this.dSkinLabel3.TabIndex = 36;
            this.dSkinLabel3.Text = "赞助金额在50元以上的童鞋，请自觉加群 543866933 联系管理员，帮你开通VIP权限。";
            // 
            // Donate
            // 
            this.AnimationType = DSkin.Forms.AnimationTypes.RotateZoomEffect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinLabel3);
            this.Controls.Add(this.TVUrl);
            this.Controls.Add(this.dSkinLabel2);
            this.Controls.Add(this.dSkinLabel1);
            this.Controls.Add(this.dSkinPictureBox2);
            this.Controls.Add(this.dSkinPictureBox1);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Donate";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = "赞助Aurora";
            this.Load += new System.EventHandler(this.Donate_Load);
            this.Resize += new System.EventHandler(this.Donate_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox1;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox2;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.DirectUI.DuiTextBox duiTextBox1;
        private DSkin.Controls.DSkinBaseControl TVUrl;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
    }
}