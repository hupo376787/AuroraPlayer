namespace Aurora_Player
{
    partial class ScreenShot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenShot));
            this.dSkinPictureBox_Preview = new DSkin.Controls.DSkinPictureBox();
            this.dSkinCheckBox_NoShowWindow = new DSkin.Controls.DSkinCheckBox();
            this.dSkinTextBox_SavePath = new DSkin.Controls.DSkinTextBox();
            this.dSkinButton_SelectPath = new DSkin.Controls.DSkinButton();
            this.dSkinButton_Save = new DSkin.Controls.DSkinButton();
            this.dSkinButton_CopytoClipboard = new DSkin.Controls.DSkinButton();
            this.dSkinComboBox_FileType = new DSkin.Controls.DSkinComboBox();
            this.dSkinLabel_Tip = new DSkin.Controls.DSkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinComboBox_FileType.InnerListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dSkinPictureBox_Preview
            // 
            this.dSkinPictureBox_Preview.Borders.AllColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dSkinPictureBox_Preview.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dSkinPictureBox_Preview.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dSkinPictureBox_Preview.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dSkinPictureBox_Preview.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dSkinPictureBox_Preview.Image = null;
            this.dSkinPictureBox_Preview.Images = null;
            this.dSkinPictureBox_Preview.Interval = 40;
            this.dSkinPictureBox_Preview.Location = new System.Drawing.Point(12, 44);
            this.dSkinPictureBox_Preview.Name = "dSkinPictureBox_Preview";
            this.dSkinPictureBox_Preview.Size = new System.Drawing.Size(754, 406);
            this.dSkinPictureBox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dSkinPictureBox_Preview.TabIndex = 8;
            this.dSkinPictureBox_Preview.Text = "dSkinPictureBox1";
            this.dSkinPictureBox_Preview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox_Preview_MouseDown);
            // 
            // dSkinCheckBox_NoShowWindow
            // 
            this.dSkinCheckBox_NoShowWindow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dSkinCheckBox_NoShowWindow.Checked = false;
            this.dSkinCheckBox_NoShowWindow.CheckFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            this.dSkinCheckBox_NoShowWindow.CheckFlagColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_NoShowWindow.CheckRectBackColorDisabled = System.Drawing.Color.Silver;
            this.dSkinCheckBox_NoShowWindow.CheckRectBackColorHighLight = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(239)))), ((int)(((byte)(219)))));
            this.dSkinCheckBox_NoShowWindow.CheckRectBackColorNormal = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(239)))), ((int)(((byte)(219)))));
            this.dSkinCheckBox_NoShowWindow.CheckRectBackColorPressed = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(226)))), ((int)(((byte)(188)))));
            this.dSkinCheckBox_NoShowWindow.CheckRectColor = System.Drawing.Color.DodgerBlue;
            this.dSkinCheckBox_NoShowWindow.CheckRectColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_NoShowWindow.CheckRectWidth = 14;
            this.dSkinCheckBox_NoShowWindow.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.dSkinCheckBox_NoShowWindow.InnerPaddingWidth = 2;
            this.dSkinCheckBox_NoShowWindow.InnerRectInflate = 3;
            this.dSkinCheckBox_NoShowWindow.Location = new System.Drawing.Point(12, 475);
            this.dSkinCheckBox_NoShowWindow.Name = "dSkinCheckBox_NoShowWindow";
            this.dSkinCheckBox_NoShowWindow.Size = new System.Drawing.Size(100, 19);
            this.dSkinCheckBox_NoShowWindow.SpaceBetweenCheckMarkAndText = 3;
            this.dSkinCheckBox_NoShowWindow.TabIndex = 9;
            this.dSkinCheckBox_NoShowWindow.Text = "下次不再显示";
            this.dSkinCheckBox_NoShowWindow.TextColorDisabled = System.Drawing.Color.Gray;
            this.dSkinCheckBox_NoShowWindow.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinCheckBox_NoShowWindow.CheckedChanged += new System.EventHandler(this.dSkinCheckBox_NoShowWindow_CheckedChanged);
            // 
            // dSkinTextBox_SavePath
            // 
            this.dSkinTextBox_SavePath.BitmapCache = false;
            this.dSkinTextBox_SavePath.Location = new System.Drawing.Point(139, 474);
            this.dSkinTextBox_SavePath.Name = "dSkinTextBox_SavePath";
            this.dSkinTextBox_SavePath.ReadOnly = true;
            this.dSkinTextBox_SavePath.Size = new System.Drawing.Size(246, 21);
            this.dSkinTextBox_SavePath.TabIndex = 10;
            this.dSkinTextBox_SavePath.TransparencyKey = System.Drawing.Color.Empty;
            this.dSkinTextBox_SavePath.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinTextBox_SavePath.WaterText = "";
            this.dSkinTextBox_SavePath.WaterTextOffset = new System.Drawing.Point(0, 0);
            this.dSkinTextBox_SavePath.TextChanged += new System.EventHandler(this.dSkinTextBox_SavePath_TextChanged);
            // 
            // dSkinButton_SelectPath
            // 
            this.dSkinButton_SelectPath.AdaptImage = true;
            this.dSkinButton_SelectPath.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_SelectPath.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_SelectPath.ButtonBorderWidth = 1;
            this.dSkinButton_SelectPath.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_SelectPath.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_SelectPath.HoverImage = null;
            this.dSkinButton_SelectPath.IsPureColor = false;
            this.dSkinButton_SelectPath.Location = new System.Drawing.Point(599, 454);
            this.dSkinButton_SelectPath.Name = "dSkinButton_SelectPath";
            this.dSkinButton_SelectPath.NormalImage = null;
            this.dSkinButton_SelectPath.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_SelectPath.PressedImage = null;
            this.dSkinButton_SelectPath.Radius = 60;
            this.dSkinButton_SelectPath.ShowButtonBorder = true;
            this.dSkinButton_SelectPath.Size = new System.Drawing.Size(60, 60);
            this.dSkinButton_SelectPath.TabIndex = 11;
            this.dSkinButton_SelectPath.Text = "选择路径";
            this.dSkinButton_SelectPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_SelectPath.TextPadding = 0;
            this.dSkinButton_SelectPath.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_SelectPath.Click += new System.EventHandler(this.dSkinButton_SelectPath_Click);
            // 
            // dSkinButton_Save
            // 
            this.dSkinButton_Save.AdaptImage = true;
            this.dSkinButton_Save.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Save.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_Save.ButtonBorderWidth = 1;
            this.dSkinButton_Save.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_Save.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_Save.HoverImage = null;
            this.dSkinButton_Save.IsPureColor = false;
            this.dSkinButton_Save.Location = new System.Drawing.Point(512, 454);
            this.dSkinButton_Save.Name = "dSkinButton_Save";
            this.dSkinButton_Save.NormalImage = null;
            this.dSkinButton_Save.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_Save.PressedImage = null;
            this.dSkinButton_Save.Radius = 60;
            this.dSkinButton_Save.ShowButtonBorder = true;
            this.dSkinButton_Save.Size = new System.Drawing.Size(60, 60);
            this.dSkinButton_Save.TabIndex = 12;
            this.dSkinButton_Save.Text = "保存截图";
            this.dSkinButton_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Save.TextPadding = 0;
            this.dSkinButton_Save.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_Save.Click += new System.EventHandler(this.dSkinButton_Save_Click);
            // 
            // dSkinButton_CopytoClipboard
            // 
            this.dSkinButton_CopytoClipboard.AdaptImage = true;
            this.dSkinButton_CopytoClipboard.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_CopytoClipboard.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_CopytoClipboard.ButtonBorderWidth = 1;
            this.dSkinButton_CopytoClipboard.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_CopytoClipboard.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_CopytoClipboard.HoverImage = null;
            this.dSkinButton_CopytoClipboard.IsPureColor = false;
            this.dSkinButton_CopytoClipboard.Location = new System.Drawing.Point(686, 454);
            this.dSkinButton_CopytoClipboard.Name = "dSkinButton_CopytoClipboard";
            this.dSkinButton_CopytoClipboard.NormalImage = null;
            this.dSkinButton_CopytoClipboard.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_CopytoClipboard.PressedImage = null;
            this.dSkinButton_CopytoClipboard.Radius = 60;
            this.dSkinButton_CopytoClipboard.ShowButtonBorder = true;
            this.dSkinButton_CopytoClipboard.Size = new System.Drawing.Size(60, 60);
            this.dSkinButton_CopytoClipboard.TabIndex = 13;
            this.dSkinButton_CopytoClipboard.Text = "复制到\r\n剪切板";
            this.dSkinButton_CopytoClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_CopytoClipboard.TextPadding = 0;
            this.dSkinButton_CopytoClipboard.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_CopytoClipboard.Click += new System.EventHandler(this.dSkinButton_CopytoClipboard_Click);
            // 
            // dSkinComboBox_FileType
            // 
            this.dSkinComboBox_FileType.AdaptImage = true;
            this.dSkinComboBox_FileType.AutoDrawSelecedItem = true;
            this.dSkinComboBox_FileType.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinComboBox_FileType.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinComboBox_FileType.ButtonBorderWidth = 1;
            this.dSkinComboBox_FileType.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinComboBox_FileType.HoverColor = System.Drawing.Color.Empty;
            this.dSkinComboBox_FileType.HoverImage = null;
            // 
            // 
            // 
            this.dSkinComboBox_FileType.InnerListBox.BackColor = System.Drawing.Color.Transparent;
            this.dSkinComboBox_FileType.InnerListBox.Location = new System.Drawing.Point(0, 0);
            this.dSkinComboBox_FileType.InnerListBox.Name = "";
            this.dSkinComboBox_FileType.InnerListBox.ScrollBarWidth = 12;
            this.dSkinComboBox_FileType.InnerListBox.TabIndex = 0;
            this.dSkinComboBox_FileType.InnerListBox.Value = 0D;
            this.dSkinComboBox_FileType.IsDrawText = false;
            this.dSkinComboBox_FileType.IsPureColor = false;
            this.dSkinComboBox_FileType.ItemHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dSkinComboBox_FileType.Location = new System.Drawing.Point(412, 474);
            this.dSkinComboBox_FileType.Name = "dSkinComboBox_FileType";
            this.dSkinComboBox_FileType.NormalImage = null;
            this.dSkinComboBox_FileType.PaddingLeft = 2;
            this.dSkinComboBox_FileType.PressColor = System.Drawing.Color.Empty;
            this.dSkinComboBox_FileType.PressedImage = null;
            this.dSkinComboBox_FileType.Radius = 8;
            this.dSkinComboBox_FileType.SelectedIndex = -1;
            this.dSkinComboBox_FileType.ShowArrow = true;
            this.dSkinComboBox_FileType.ShowButtonBorder = true;
            this.dSkinComboBox_FileType.Size = new System.Drawing.Size(73, 21);
            this.dSkinComboBox_FileType.TabIndex = 14;
            this.dSkinComboBox_FileType.Text = "dSkinComboBox1";
            this.dSkinComboBox_FileType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dSkinComboBox_FileType.TextPadding = 3;
            this.dSkinComboBox_FileType.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // 
            // 
            this.dSkinComboBox_FileType.ToolStripDropDown.BorderColor = System.Drawing.Color.DarkGray;
            this.dSkinComboBox_FileType.ToolStripDropDown.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.dSkinComboBox_FileType.ToolStripDropDown.MinimumSize = new System.Drawing.Size(18, 18);
            this.dSkinComboBox_FileType.ToolStripDropDown.Name = "";
            this.dSkinComboBox_FileType.ToolStripDropDown.Padding = new System.Windows.Forms.Padding(0);
            this.dSkinComboBox_FileType.ToolStripDropDown.Resizable = false;
            this.dSkinComboBox_FileType.ToolStripDropDown.ResizeGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.dSkinComboBox_FileType.ToolStripDropDown.ResizeGridSize = new System.Drawing.Size(16, 16);
            this.dSkinComboBox_FileType.ToolStripDropDown.Size = new System.Drawing.Size(18, 18);
            this.dSkinComboBox_FileType.ToolStripDropDown.WhereIsResizeGrid = DSkin.ResizeGridLocation.BottomRight;
            this.dSkinComboBox_FileType.SelectedIndexChanged += new System.EventHandler(this.dSkinComboBox_FileType_SelectedIndexChanged);
            // 
            // dSkinLabel_Tip
            // 
            this.dSkinLabel_Tip.Location = new System.Drawing.Point(12, 28);
            this.dSkinLabel_Tip.Name = "dSkinLabel_Tip";
            this.dSkinLabel_Tip.Size = new System.Drawing.Size(73, 14);
            this.dSkinLabel_Tip.TabIndex = 15;
            this.dSkinLabel_Tip.Text = "dSkinLabel1";
            // 
            // ScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(773, 520);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinLabel_Tip);
            this.Controls.Add(this.dSkinComboBox_FileType);
            this.Controls.Add(this.dSkinButton_CopytoClipboard);
            this.Controls.Add(this.dSkinButton_Save);
            this.Controls.Add(this.dSkinButton_SelectPath);
            this.Controls.Add(this.dSkinTextBox_SavePath);
            this.Controls.Add(this.dSkinCheckBox_NoShowWindow);
            this.Controls.Add(this.dSkinPictureBox_Preview);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenShot";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = "屏幕截图";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenShot_FormClosing);
            this.Load += new System.EventHandler(this.ScreenShot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinComboBox_FileType.InnerListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox_Preview;
        private DSkin.Controls.DSkinCheckBox dSkinCheckBox_NoShowWindow;
        private DSkin.Controls.DSkinTextBox dSkinTextBox_SavePath;
        private DSkin.Controls.DSkinButton dSkinButton_SelectPath;
        private DSkin.Controls.DSkinButton dSkinButton_Save;
        private DSkin.Controls.DSkinButton dSkinButton_CopytoClipboard;
        private DSkin.Controls.DSkinComboBox dSkinComboBox_FileType;
        private DSkin.Controls.DSkinLabel dSkinLabel_Tip;
    }
}