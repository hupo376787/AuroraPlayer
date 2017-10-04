namespace Aurora_Player
{
    partial class TV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TV));
            this.TVUrl = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBox_TVUrl = new DSkin.DirectUI.DuiTextBox();
            this.dSkinContextMenuStrip1 = new DSkin.Controls.DSkinContextMenuStrip();
            this.toolStripMenuItem_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_All = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_DelPasteGo = new System.Windows.Forms.ToolStripMenuItem();
            this.duiButton_Clear = new DSkin.DirectUI.DuiButton();
            this.dSkinButton_GO = new DSkin.Controls.DSkinButton();
            this.dSkinContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TVUrl
            // 
            this.TVUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TVUrl.Borders.AllColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.TVUrl.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.TVUrl.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.TVUrl.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.TVUrl.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.TVUrl.DUIControls.Add(this.duiTextBox_TVUrl);
            this.TVUrl.DUIControls.Add(this.duiButton_Clear);
            this.TVUrl.Location = new System.Drawing.Point(7, 56);
            this.TVUrl.Name = "TVUrl";
            this.TVUrl.Size = new System.Drawing.Size(406, 26);
            this.TVUrl.TabIndex = 28;
            this.TVUrl.Text = "dSkinBaseControl1";
            // 
            // duiTextBox_TVUrl
            // 
            this.duiTextBox_TVUrl.AllowPasteImage = false;
            this.duiTextBox_TVUrl.AutoSize = false;
            this.duiTextBox_TVUrl.ContextMenuStrip = this.dSkinContextMenuStrip1;
            this.duiTextBox_TVUrl.Controls.Add(this.duiTextBox_TVUrl.InnerScrollBar);
            this.duiTextBox_TVUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.duiTextBox_TVUrl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiTextBox_TVUrl.Location = new System.Drawing.Point(0, 0);
            this.duiTextBox_TVUrl.Name = "duiTextBox_TVUrl";
            this.duiTextBox_TVUrl.Size = new System.Drawing.Size(406, 26);
            this.duiTextBox_TVUrl.KeyDown += new System.EventHandler<System.Windows.Forms.KeyEventArgs>(this.duiTextBox_TVUrl_KeyDown);
            // 
            // dSkinContextMenuStrip1
            // 
            this.dSkinContextMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip1.Back = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.dSkinContextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinContextMenuStrip1.BackRadius = 4;
            this.dSkinContextMenuStrip1.Base = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.DropDownImageSeparator = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.Fore = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.dSkinContextMenuStrip1.ItemAnamorphosis = false;
            this.dSkinContextMenuStrip1.ItemBorder = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.ItemBorderShow = true;
            this.dSkinContextMenuStrip1.ItemHover = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.ItemPressed = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.ItemRadius = 1;
            this.dSkinContextMenuStrip1.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Undo,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Cut,
            this.toolStripMenuItem_Copy,
            this.toolStripMenuItem_Paste,
            this.toolStripMenuItem_Del,
            this.toolStripSeparator2,
            this.toolStripMenuItem_All,
            this.toolStripSeparator3,
            this.toolStripMenuItem_DelPasteGo});
            this.dSkinContextMenuStrip1.ItemSplitter = System.Drawing.Color.DarkOrange;
            this.dSkinContextMenuStrip1.Name = "dSkinContextMenuStrip1";
            this.dSkinContextMenuStrip1.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip1.ShowImageMargin = false;
            this.dSkinContextMenuStrip1.Size = new System.Drawing.Size(130, 176);
            this.dSkinContextMenuStrip1.SkinAllColor = true;
            this.dSkinContextMenuStrip1.TitleAnamorphosis = true;
            this.dSkinContextMenuStrip1.TitleColor = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip1.TitleRadius = 4;
            this.dSkinContextMenuStrip1.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // toolStripMenuItem_Undo
            // 
            this.toolStripMenuItem_Undo.Name = "toolStripMenuItem_Undo";
            this.toolStripMenuItem_Undo.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_Undo.Text = "撤销(U)";
            this.toolStripMenuItem_Undo.Click += new System.EventHandler(this.toolStripMenuItem_Undo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItem_Cut
            // 
            this.toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
            this.toolStripMenuItem_Cut.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_Cut.Text = "剪切(T)";
            this.toolStripMenuItem_Cut.Click += new System.EventHandler(this.toolStripMenuItem_Cut_Click);
            // 
            // toolStripMenuItem_Copy
            // 
            this.toolStripMenuItem_Copy.Name = "toolStripMenuItem_Copy";
            this.toolStripMenuItem_Copy.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_Copy.Text = "复制(C)";
            this.toolStripMenuItem_Copy.Click += new System.EventHandler(this.toolStripMenuItem_Copy_Click);
            // 
            // toolStripMenuItem_Paste
            // 
            this.toolStripMenuItem_Paste.Name = "toolStripMenuItem_Paste";
            this.toolStripMenuItem_Paste.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_Paste.Text = "粘贴(P)";
            this.toolStripMenuItem_Paste.Click += new System.EventHandler(this.toolStripMenuItem_Paste_Click);
            // 
            // toolStripMenuItem_Del
            // 
            this.toolStripMenuItem_Del.Name = "toolStripMenuItem_Del";
            this.toolStripMenuItem_Del.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_Del.Text = "删除(D)";
            this.toolStripMenuItem_Del.Click += new System.EventHandler(this.toolStripMenuItem_Del_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItem_All
            // 
            this.toolStripMenuItem_All.Name = "toolStripMenuItem_All";
            this.toolStripMenuItem_All.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_All.Text = "全选(A)";
            this.toolStripMenuItem_All.Click += new System.EventHandler(this.toolStripMenuItem_All_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItem_DelPasteGo
            // 
            this.toolStripMenuItem_DelPasteGo.Name = "toolStripMenuItem_DelPasteGo";
            this.toolStripMenuItem_DelPasteGo.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem_DelPasteGo.Text = "删除.粘贴.点播";
            this.toolStripMenuItem_DelPasteGo.Click += new System.EventHandler(this.toolStripMenuItem_DelPasteGo_Click);
            // 
            // duiButton_Clear
            // 
            this.duiButton_Clear.BaseColor = System.Drawing.Color.Transparent;
            this.duiButton_Clear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiButton_Clear.HoverColor = System.Drawing.Color.Empty;
            this.duiButton_Clear.Location = new System.Drawing.Point(382, 2);
            this.duiButton_Clear.Name = "duiButton_Clear";
            this.duiButton_Clear.PressColor = System.Drawing.Color.Empty;
            this.duiButton_Clear.Radius = 22;
            this.duiButton_Clear.Size = new System.Drawing.Size(22, 22);
            this.duiButton_Clear.TabStop = false;
            this.duiButton_Clear.Text = "X";
            this.duiButton_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.duiButton_Clear.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiButton_Clear_MouseDown);
            // 
            // dSkinButton_GO
            // 
            this.dSkinButton_GO.AdaptImage = true;
            this.dSkinButton_GO.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_GO.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_GO.ButtonBorderWidth = 1;
            this.dSkinButton_GO.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_GO.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_GO.HoverImage = null;
            this.dSkinButton_GO.IsPureColor = false;
            this.dSkinButton_GO.Location = new System.Drawing.Point(180, 102);
            this.dSkinButton_GO.Name = "dSkinButton_GO";
            this.dSkinButton_GO.NormalImage = null;
            this.dSkinButton_GO.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_GO.PressedImage = null;
            this.dSkinButton_GO.Radius = 60;
            this.dSkinButton_GO.ShowButtonBorder = true;
            this.dSkinButton_GO.Size = new System.Drawing.Size(60, 60);
            this.dSkinButton_GO.TabIndex = 29;
            this.dSkinButton_GO.TabStop = false;
            this.dSkinButton_GO.Text = "点播";
            this.dSkinButton_GO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_GO.TextPadding = 0;
            this.dSkinButton_GO.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_GO.Click += new System.EventHandler(this.dSkinButton_GO_Click);
            // 
            // TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(420, 179);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinButton_GO);
            this.Controls.Add(this.TVUrl);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TV";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = "打开Url";
            this.Load += new System.EventHandler(this.TV_Load);
            this.Shown += new System.EventHandler(this.TV_Shown);
            this.dSkinContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinBaseControl TVUrl;
        private DSkin.DirectUI.DuiTextBox duiTextBox_TVUrl;
        private DSkin.Controls.DSkinButton dSkinButton_GO;
        private DSkin.Controls.DSkinContextMenuStrip dSkinContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Undo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_All;
        private DSkin.DirectUI.DuiButton duiButton_Clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DelPasteGo;
    }
}