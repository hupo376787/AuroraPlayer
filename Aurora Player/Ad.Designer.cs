namespace Aurora_Player
{
    partial class Ad
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
            this.dSkinBrowser1 = new DSkin.Controls.DSkinBrowser();
            this.dSkinCheckBox_ShowAdOnceMore = new DSkin.Controls.DSkinCheckBox();
            this.controlHost1 = new DSkin.Controls.ControlHost();
            this.dSkinChatRichTextBox1 = new DSkin.Controls.DSkinChatRichTextBox();
            this.controlHost1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinBrowser1
            // 
            this.dSkinBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinBrowser1.Location = new System.Drawing.Point(3, 28);
            this.dSkinBrowser1.Name = "dSkinBrowser1";
            this.dSkinBrowser1.Size = new System.Drawing.Size(354, 189);
            this.dSkinBrowser1.TabIndex = 0;
            this.dSkinBrowser1.Text = "dSkinBrowser1";
            this.dSkinBrowser1.Url = "";
            this.dSkinBrowser1.ZoomFactor = 1F;
            // 
            // dSkinCheckBox_ShowAdOnceMore
            // 
            this.dSkinCheckBox_ShowAdOnceMore.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dSkinCheckBox_ShowAdOnceMore.Checked = true;
            this.dSkinCheckBox_ShowAdOnceMore.CheckFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            this.dSkinCheckBox_ShowAdOnceMore.CheckFlagColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectBackColorDisabled = System.Drawing.Color.Silver;
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectBackColorHighLight = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(239)))), ((int)(((byte)(219)))));
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectBackColorNormal = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(239)))), ((int)(((byte)(219)))));
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectBackColorPressed = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(226)))), ((int)(((byte)(188)))));
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectColor = System.Drawing.Color.DodgerBlue;
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_ShowAdOnceMore.CheckRectWidth = 14;
            this.dSkinCheckBox_ShowAdOnceMore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dSkinCheckBox_ShowAdOnceMore.InnerPaddingWidth = 2;
            this.dSkinCheckBox_ShowAdOnceMore.InnerRectInflate = 3;
            this.dSkinCheckBox_ShowAdOnceMore.Location = new System.Drawing.Point(167, 5);
            this.dSkinCheckBox_ShowAdOnceMore.Name = "dSkinCheckBox_ShowAdOnceMore";
            this.dSkinCheckBox_ShowAdOnceMore.Size = new System.Drawing.Size(100, 19);
            this.dSkinCheckBox_ShowAdOnceMore.SpaceBetweenCheckMarkAndText = 3;
            this.dSkinCheckBox_ShowAdOnceMore.TabIndex = 1;
            this.dSkinCheckBox_ShowAdOnceMore.Text = "今日不再推送";
            this.dSkinCheckBox_ShowAdOnceMore.TextColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_ShowAdOnceMore.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinCheckBox_ShowAdOnceMore.CheckedChanged += new System.EventHandler(this.dSkinCheckBox_ShowAdOnceMore_CheckedChanged);
            // 
            // controlHost1
            // 
            this.controlHost1.Controls.Add(this.dSkinChatRichTextBox1);
            this.controlHost1.Location = new System.Drawing.Point(3, 28);
            this.controlHost1.Name = "controlHost1";
            this.controlHost1.Size = new System.Drawing.Size(354, 189);
            this.controlHost1.TabIndex = 2;
            this.controlHost1.Text = "controlHost1";
            this.controlHost1.TransparencyKey = System.Drawing.Color.Empty;
            // 
            // dSkinChatRichTextBox1
            // 
            this.dSkinChatRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dSkinChatRichTextBox1.ContextMenuMode = DSkin.Controls.ChatBoxContextMenuMode.None;
            this.dSkinChatRichTextBox1.Location = new System.Drawing.Point(3, 0);
            this.dSkinChatRichTextBox1.Name = "dSkinChatRichTextBox1";
            this.dSkinChatRichTextBox1.PopoutImageWhenDoubleClick = false;
            this.dSkinChatRichTextBox1.ReadOnly = true;
            this.dSkinChatRichTextBox1.SelectControl = null;
            this.dSkinChatRichTextBox1.SelectControlIndex = 0;
            this.dSkinChatRichTextBox1.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.dSkinChatRichTextBox1.ShowSelectionMargin = true;
            this.dSkinChatRichTextBox1.Size = new System.Drawing.Size(354, 189);
            this.dSkinChatRichTextBox1.TabIndex = 3;
            this.dSkinChatRichTextBox1.Text = "";
            // 
            // Ad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(360, 220);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinCheckBox_ShowAdOnceMore);
            this.Controls.Add(this.dSkinBrowser1);
            this.Controls.Add(this.controlHost1);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.IsLayeredWindowForm = false;
            this.MaxBox.NormalColor = System.Drawing.Color.White;
            this.MaxBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MaxBox.Size = new System.Drawing.Size(30, 22);
            this.MinBox.NormalColor = System.Drawing.Color.White;
            this.MinBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MinBox.Size = new System.Drawing.Size(30, 22);
            this.Name = "Ad";
            this.NormalBox.NormalColor = System.Drawing.Color.White;
            this.NormalBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NormalBox.Size = new System.Drawing.Size(30, 22);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = "广告推送(10s后自动关闭)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ad_FormClosing);
            this.Load += new System.EventHandler(this.Ad_Load);
            this.controlHost1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinBrowser dSkinBrowser1;
        private DSkin.Controls.DSkinCheckBox dSkinCheckBox_ShowAdOnceMore;
        private DSkin.Controls.ControlHost controlHost1;
        private DSkin.Controls.DSkinChatRichTextBox dSkinChatRichTextBox1;
    }
}