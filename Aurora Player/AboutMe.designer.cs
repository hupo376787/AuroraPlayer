namespace Aurora_Player
{
    partial class AboutMe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutMe));
            this.dSkinButton1 = new DSkin.Controls.DSkinButton();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel4 = new DSkin.Controls.DSkinLabel();
            this.dSkinBaseControl1 = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBox1 = new DSkin.DirectUI.DuiTextBox();
            this.dSkinLabel_Website = new DSkin.Controls.DSkinLabel();
            this.SuspendLayout();
            // 
            // dSkinButton1
            // 
            this.dSkinButton1.AdaptImage = true;
            this.dSkinButton1.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton1.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton1.ButtonBorderWidth = 1;
            this.dSkinButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinButton1.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton1.HoverImage = null;
            this.dSkinButton1.IsPureColor = false;
            this.dSkinButton1.Location = new System.Drawing.Point(357, 49);
            this.dSkinButton1.Name = "dSkinButton1";
            this.dSkinButton1.NormalImage = null;
            this.dSkinButton1.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton1.PressedImage = null;
            this.dSkinButton1.Radius = 15;
            this.dSkinButton1.ShowButtonBorder = true;
            this.dSkinButton1.Size = new System.Drawing.Size(66, 22);
            this.dSkinButton1.TabIndex = 4;
            this.dSkinButton1.Text = "确定";
            this.dSkinButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton1.TextPadding = 0;
            this.dSkinButton1.Visible = false;
            this.dSkinButton1.Click += new System.EventHandler(this.dSkinButton1_Click);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dSkinLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.Location = new System.Drawing.Point(12, 12);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(303, 21);
            this.dSkinLabel1.TabIndex = 5;
            this.dSkinLabel1.Text = "关于Aurora Player 单机版(2017.03.03)";
            this.dSkinLabel1.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel2.Location = new System.Drawing.Point(12, 49);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(283, 43);
            this.dSkinLabel2.TabIndex = 6;
            this.dSkinLabel2.Text = "©Aurora 保留所有权利. 软件作者拥有最终解释权.\r\nCopyRight© 2016 Aurora. All Rights Reserved.\r\n软件bug" +
    "请在官方QQ群 543866933 反馈.";
            // 
            // dSkinLabel4
            // 
            this.dSkinLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel4.ForeColor = System.Drawing.Color.Blue;
            this.dSkinLabel4.Location = new System.Drawing.Point(344, 106);
            this.dSkinLabel4.Name = "dSkinLabel4";
            this.dSkinLabel4.Size = new System.Drawing.Size(79, 16);
            this.dSkinLabel4.TabIndex = 9;
            this.dSkinLabel4.Text = "最终用户协议";
            this.dSkinLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dSkinLabel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinLabel4_MouseDown);
            this.dSkinLabel4.MouseEnter += new System.EventHandler(this.dSkinLabel4_MouseEnter);
            this.dSkinLabel4.MouseLeave += new System.EventHandler(this.dSkinLabel4_MouseLeave);
            // 
            // dSkinBaseControl1
            // 
            this.dSkinBaseControl1.DUIControls.Add(this.duiTextBox1);
            this.dSkinBaseControl1.Location = new System.Drawing.Point(12, 138);
            this.dSkinBaseControl1.Name = "dSkinBaseControl1";
            this.dSkinBaseControl1.Size = new System.Drawing.Size(411, 110);
            this.dSkinBaseControl1.TabIndex = 11;
            this.dSkinBaseControl1.Text = "dSkinBaseControl1";
            // 
            // duiTextBox1
            // 
            this.duiTextBox1.AutoSize = false;
            this.duiTextBox1.Controls.Add(this.duiTextBox1.InnerScrollBar);
            this.duiTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.duiTextBox1.DesignModeCanMove = false;
            this.duiTextBox1.DesignModeCanResize = false;
            this.duiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duiTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiTextBox1.Location = new System.Drawing.Point(0, 0);
            this.duiTextBox1.Multiline = true;
            this.duiTextBox1.Name = "duiTextBox1";
            this.duiTextBox1.ReadOnly = true;
            this.duiTextBox1.Size = new System.Drawing.Size(411, 110);
            this.duiTextBox1.Text = resources.GetString("duiTextBox1.Text");
            // 
            // dSkinLabel_Website
            // 
            this.dSkinLabel_Website.ForeColor = System.Drawing.Color.Blue;
            this.dSkinLabel_Website.Location = new System.Drawing.Point(12, 108);
            this.dSkinLabel_Website.Name = "dSkinLabel_Website";
            this.dSkinLabel_Website.Size = new System.Drawing.Size(172, 14);
            this.dSkinLabel_Website.TabIndex = 12;
            this.dSkinLabel_Website.Text = "http://www.auroraplayer.com";
            this.dSkinLabel_Website.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinLabel_Website_MouseDown);
            this.dSkinLabel_Website.MouseEnter += new System.EventHandler(this.dSkinLabel_Website_MouseEnter);
            this.dSkinLabel_Website.MouseLeave += new System.EventHandler(this.dSkinLabel_Website_MouseLeave);
            // 
            // AboutMe
            // 
            this.AnimationType = DSkin.Forms.AnimationTypes.ThreeDTurn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.DimGray;
            this.CanResize = false;
            this.CaptionShowMode = DSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(434, 260);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinLabel_Website);
            this.Controls.Add(this.dSkinBaseControl1);
            this.Controls.Add(this.dSkinLabel4);
            this.Controls.Add(this.dSkinLabel2);
            this.Controls.Add(this.dSkinLabel1);
            this.Controls.Add(this.dSkinButton1);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutMe";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = " Aurora协议声明";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AboutMe_FormClosed);
            this.Load += new System.EventHandler(this.AboutMe_Load);
            this.Click += new System.EventHandler(this.AboutMe_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinButton dSkinButton1;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.Controls.DSkinLabel dSkinLabel4;
        private DSkin.Controls.DSkinBaseControl dSkinBaseControl1;
        private DSkin.DirectUI.DuiTextBox duiTextBox1;
        private DSkin.Controls.DSkinLabel dSkinLabel_Website;
    }
}