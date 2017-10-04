namespace Aurora_Player
{
    partial class AuroraMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuroraMessageBox));
            this.dSkinLabel_Message = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel_Caption = new DSkin.Controls.DSkinLabel();
            this.dSkinButton_OK = new DSkin.Controls.DSkinButton();
            this.SuspendLayout();
            // 
            // dSkinLabel_Message
            // 
            this.dSkinLabel_Message.AutoSize = false;
            this.dSkinLabel_Message.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel_Message.Location = new System.Drawing.Point(12, 35);
            this.dSkinLabel_Message.Name = "dSkinLabel_Message";
            this.dSkinLabel_Message.Size = new System.Drawing.Size(290, 65);
            this.dSkinLabel_Message.TabIndex = 0;
            this.dSkinLabel_Message.Text = "消息内容";
            this.dSkinLabel_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinLabel_Message.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinLabel_Message_MouseDown);
            // 
            // dSkinLabel_Caption
            // 
            this.dSkinLabel_Caption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dSkinLabel_Caption.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel_Caption.Location = new System.Drawing.Point(12, 7);
            this.dSkinLabel_Caption.Name = "dSkinLabel_Caption";
            this.dSkinLabel_Caption.Size = new System.Drawing.Size(72, 21);
            this.dSkinLabel_Caption.TabIndex = 1;
            this.dSkinLabel_Caption.Text = "窗体标题";
            this.dSkinLabel_Caption.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.dSkinLabel_Caption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinLabel_Caption_MouseDown);
            // 
            // dSkinButton_OK
            // 
            this.dSkinButton_OK.AdaptImage = true;
            this.dSkinButton_OK.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_OK.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_OK.ButtonBorderWidth = 1;
            this.dSkinButton_OK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_OK.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_OK.HoverImage = null;
            this.dSkinButton_OK.IsPureColor = false;
            this.dSkinButton_OK.Location = new System.Drawing.Point(129, 108);
            this.dSkinButton_OK.Name = "dSkinButton_OK";
            this.dSkinButton_OK.NormalImage = null;
            this.dSkinButton_OK.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_OK.PressedImage = null;
            this.dSkinButton_OK.Radius = 50;
            this.dSkinButton_OK.ShowButtonBorder = true;
            this.dSkinButton_OK.Size = new System.Drawing.Size(50, 50);
            this.dSkinButton_OK.TabIndex = 2;
            this.dSkinButton_OK.Text = "确定";
            this.dSkinButton_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_OK.TextPadding = 0;
            this.dSkinButton_OK.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_OK.Click += new System.EventHandler(this.dSkinButton_OK_Click);
            // 
            // AuroraMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Aurora_Player.Properties.Resources.Dribbble;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CanResize = false;
            this.CaptionShowMode = DSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(309, 163);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinButton_OK);
            this.Controls.Add(this.dSkinLabel_Caption);
            this.Controls.Add(this.dSkinLabel_Message);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuroraMessageBox";
            this.ShowShadow = true;
            this.Text = "Message";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Message_FormClosed);
            this.Load += new System.EventHandler(this.Message_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AuroraMessageBox_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSkin.Controls.DSkinLabel dSkinLabel_Message;
        private DSkin.Controls.DSkinLabel dSkinLabel_Caption;
        private DSkin.Controls.DSkinButton dSkinButton_OK;
    }
}