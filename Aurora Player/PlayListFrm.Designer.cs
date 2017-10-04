namespace Aurora_Player
{
    partial class PlayListFrm
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
            this.dSkinTabControl1 = new DSkin.Controls.DSkinTabControl();
            this.dSkinTabPage1 = new DSkin.Controls.DSkinTabPage();
            this.dSkinGridList_PlayList_LocalList = new DSkin.Controls.DSkinGridList();
            this.dSkinContextMenuStrip_LocalList = new DSkin.Controls.DSkinContextMenuStrip();
            this.toolStripMenuItem_LocalList_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PlayFromStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_LocalList_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_LocalList_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DeleteUselessFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_LocalList_ClearList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_MoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.dSkinContextMenuStrip_TV = new DSkin.Controls.DSkinContextMenuStrip();
            this.toolStripMenuItem_TV_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TV_ChangeSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ExpandCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RefreshTVList = new System.Windows.Forms.ToolStripMenuItem();
            this.dSkinTabControl1.SuspendLayout();
            this.dSkinTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinGridList_PlayList_LocalList)).BeginInit();
            this.dSkinContextMenuStrip_LocalList.SuspendLayout();
            this.dSkinContextMenuStrip_TV.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTabControl1
            // 
            this.dSkinTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinTabControl1.BitmapCache = false;
            this.dSkinTabControl1.Controls.Add(this.dSkinTabPage1);
            this.dSkinTabControl1.HoverBackColors = new System.Drawing.Color[] {
        System.Drawing.Color.Transparent,
        System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))};
            this.dSkinTabControl1.ItemBackgroundImage = null;
            this.dSkinTabControl1.ItemBackgroundImageHover = null;
            this.dSkinTabControl1.ItemBackgroundImageSelected = null;
            this.dSkinTabControl1.ItemSize = new System.Drawing.Size(70, 28);
            this.dSkinTabControl1.Location = new System.Drawing.Point(0, 0);
            this.dSkinTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.dSkinTabControl1.Name = "dSkinTabControl1";
            this.dSkinTabControl1.NormalBackColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))};
            this.dSkinTabControl1.PageImagePosition = DSkin.Controls.ePageImagePosition.Left;
            this.dSkinTabControl1.SelectedBackColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
        System.Drawing.Color.Red};
            this.dSkinTabControl1.Size = new System.Drawing.Size(232, 400);
            this.dSkinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.dSkinTabControl1.TabIndex = 0;
            this.dSkinTabControl1.UpdownBtnArrowNormalColor = System.Drawing.Color.Gray;
            this.dSkinTabControl1.UpdownBtnArrowPressColor = System.Drawing.Color.White;
            this.dSkinTabControl1.UpdownBtnBackColor = System.Drawing.Color.Transparent;
            this.dSkinTabControl1.UpdownBtnBorderColor = System.Drawing.Color.Gray;
            // 
            // dSkinTabPage1
            // 
            this.dSkinTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTabPage1.Controls.Add(this.dSkinGridList_PlayList_LocalList);
            this.dSkinTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinTabPage1.Location = new System.Drawing.Point(0, 28);
            this.dSkinTabPage1.Name = "dSkinTabPage1";
            this.dSkinTabPage1.Size = new System.Drawing.Size(232, 372);
            this.dSkinTabPage1.TabIndex = 0;
            this.dSkinTabPage1.TabItemImage = null;
            this.dSkinTabPage1.Text = "本地视频";
            // 
            // dSkinGridList_PlayList_LocalList
            // 
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList_PlayList_LocalList.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.BackPageButton.IsPureColor = true;
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Location = new System.Drawing.Point(386, 4);
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Name = "BtnBackPage";
            this.dSkinGridList_PlayList_LocalList.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Radius = 0;
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.dSkinGridList_PlayList_LocalList.BackPageButton.Text = "上一页";
            this.dSkinGridList_PlayList_LocalList.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList_PlayList_LocalList.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList_PlayList_LocalList.Borders.AllColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.Borders.BottomColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.Borders.LeftColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.Borders.RightColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.Borders.TopColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.ColumnHeight = 30;
            this.dSkinGridList_PlayList_LocalList.ContextMenuStrip = this.dSkinContextMenuStrip_LocalList;
            this.dSkinGridList_PlayList_LocalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinGridList_PlayList_LocalList.DoubleItemsBackColor = System.Drawing.Color.Transparent;
            this.dSkinGridList_PlayList_LocalList.EnabledOrder = false;
            this.dSkinGridList_PlayList_LocalList.EnablePage = false;
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.IsPureColor = true;
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Location = new System.Drawing.Point(338, 4);
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Name = "BtnFistPage";
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Radius = 0;
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.Text = "首页";
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList_PlayList_LocalList.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList_PlayList_LocalList.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.GoPageButton.IsPureColor = true;
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Name = "BtnGoPage";
            this.dSkinGridList_PlayList_LocalList.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Radius = 0;
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList_PlayList_LocalList.GoPageButton.Text = "跳转";
            this.dSkinGridList_PlayList_LocalList.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList_PlayList_LocalList.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList_PlayList_LocalList.GridLineColor = System.Drawing.Color.Silver;
            this.dSkinGridList_PlayList_LocalList.GridListContextMenuStrip = this.dSkinContextMenuStrip_LocalList;
            this.dSkinGridList_PlayList_LocalList.HeaderFont = new System.Drawing.Font("宋体", 9F);
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.HScrollBar.AutoSize = false;
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Fillet = true;
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Location = new System.Drawing.Point(0, 56);
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Name = "";
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.dSkinGridList_PlayList_LocalList.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Size = new System.Drawing.Size(232, 12);
            this.dSkinGridList_PlayList_LocalList.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList_PlayList_LocalList.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.LastPageButton.IsPureColor = true;
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Location = new System.Drawing.Point(494, 4);
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Name = "BtnLastPage";
            this.dSkinGridList_PlayList_LocalList.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Radius = 0;
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList_PlayList_LocalList.LastPageButton.Text = "末页";
            this.dSkinGridList_PlayList_LocalList.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList_PlayList_LocalList.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList_PlayList_LocalList.Location = new System.Drawing.Point(0, 0);
            this.dSkinGridList_PlayList_LocalList.Name = "dSkinGridList_PlayList_LocalList";
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList_PlayList_LocalList.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList_PlayList_LocalList.NextPageButton.IsPureColor = true;
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Location = new System.Drawing.Point(440, 4);
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Name = "BtnNextPage";
            this.dSkinGridList_PlayList_LocalList.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Radius = 0;
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.dSkinGridList_PlayList_LocalList.NextPageButton.Text = "下一页";
            this.dSkinGridList_PlayList_LocalList.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList_PlayList_LocalList.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList_PlayList_LocalList.RowHeight = 25;
            this.dSkinGridList_PlayList_LocalList.SelectedItem = null;
            this.dSkinGridList_PlayList_LocalList.Size = new System.Drawing.Size(232, 372);
            this.dSkinGridList_PlayList_LocalList.TabIndex = 0;
            this.dSkinGridList_PlayList_LocalList.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.dSkinGridList_PlayList_LocalList.VScrollBar.AutoSize = false;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.BitmapCache = true;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Fillet = true;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList_PlayList_LocalList.VScrollBar.LargeChange = 1000;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Location = new System.Drawing.Point(219, 1);
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Maximum = 10000;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Name = "";
            this.dSkinGridList_PlayList_LocalList.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Size = new System.Drawing.Size(12, 339);
            this.dSkinGridList_PlayList_LocalList.VScrollBar.SmallChange = 500;
            this.dSkinGridList_PlayList_LocalList.VScrollBar.Visible = false;
            this.dSkinGridList_PlayList_LocalList.ItemDoubleClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.dSkinGridList_PlayList_LocalList_ItemDoubleClick);
            // 
            // dSkinContextMenuStrip_LocalList
            // 
            this.dSkinContextMenuStrip_LocalList.Arrow = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip_LocalList.Back = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.BackColor = System.Drawing.SystemColors.Control;
            this.dSkinContextMenuStrip_LocalList.BackRadius = 1;
            this.dSkinContextMenuStrip_LocalList.Base = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dSkinContextMenuStrip_LocalList.Fore = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip_LocalList.HoverFore = System.Drawing.Color.White;
            this.dSkinContextMenuStrip_LocalList.ItemAnamorphosis = false;
            this.dSkinContextMenuStrip_LocalList.ItemBorder = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.ItemBorderShow = false;
            this.dSkinContextMenuStrip_LocalList.ItemHover = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.ItemPressed = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.ItemRadius = 1;
            this.dSkinContextMenuStrip_LocalList.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip_LocalList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_LocalList_Play,
            this.toolStripMenuItem_PlayFromStart,
            this.toolStripSeparator3,
            this.toolStripMenuItem_LocalList_Add,
            this.toolStripMenuItem_AddFolder,
            this.toolStripMenuItem_LocalList_Delete,
            this.toolStripMenuItem_DeleteUselessFile,
            this.toolStripMenuItem_LocalList_ClearList,
            this.toolStripSeparator4,
            this.toolStripMenuItem_MoveUp,
            this.toolStripMenuItem_MoveTop,
            this.toolStripMenuItem_MoveDown,
            this.toolStripMenuItem_MoveBottom});
            this.dSkinContextMenuStrip_LocalList.ItemSplitter = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.Name = "dSkinContextMenuStrip_TV";
            this.dSkinContextMenuStrip_LocalList.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip_LocalList.Size = new System.Drawing.Size(149, 258);
            this.dSkinContextMenuStrip_LocalList.SkinAllColor = true;
            this.dSkinContextMenuStrip_LocalList.TitleAnamorphosis = true;
            this.dSkinContextMenuStrip_LocalList.TitleColor = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_LocalList.TitleRadius = 4;
            this.dSkinContextMenuStrip_LocalList.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // toolStripMenuItem_LocalList_Play
            // 
            this.toolStripMenuItem_LocalList_Play.Name = "toolStripMenuItem_LocalList_Play";
            this.toolStripMenuItem_LocalList_Play.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_LocalList_Play.Text = "播放";
            this.toolStripMenuItem_LocalList_Play.Click += new System.EventHandler(this.toolStripMenuItem_LocalList_Play_Click);
            // 
            // toolStripMenuItem_PlayFromStart
            // 
            this.toolStripMenuItem_PlayFromStart.Name = "toolStripMenuItem_PlayFromStart";
            this.toolStripMenuItem_PlayFromStart.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_PlayFromStart.Text = "从头播放";
            this.toolStripMenuItem_PlayFromStart.Click += new System.EventHandler(this.toolStripMenuItem_PlayFromStart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_LocalList_Add
            // 
            this.toolStripMenuItem_LocalList_Add.Name = "toolStripMenuItem_LocalList_Add";
            this.toolStripMenuItem_LocalList_Add.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_LocalList_Add.Text = "添加";
            this.toolStripMenuItem_LocalList_Add.Click += new System.EventHandler(this.toolStripMenuItem_LocalList_Add_Click);
            // 
            // toolStripMenuItem_AddFolder
            // 
            this.toolStripMenuItem_AddFolder.Name = "toolStripMenuItem_AddFolder";
            this.toolStripMenuItem_AddFolder.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_AddFolder.Text = "添加文件夹";
            this.toolStripMenuItem_AddFolder.Click += new System.EventHandler(this.toolStripMenuItem_AddFolder_Click);
            // 
            // toolStripMenuItem_LocalList_Delete
            // 
            this.toolStripMenuItem_LocalList_Delete.Name = "toolStripMenuItem_LocalList_Delete";
            this.toolStripMenuItem_LocalList_Delete.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_LocalList_Delete.Text = "删除";
            this.toolStripMenuItem_LocalList_Delete.Click += new System.EventHandler(this.toolStripMenuItem_LocalList_Delete_Click);
            // 
            // toolStripMenuItem_DeleteUselessFile
            // 
            this.toolStripMenuItem_DeleteUselessFile.Name = "toolStripMenuItem_DeleteUselessFile";
            this.toolStripMenuItem_DeleteUselessFile.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_DeleteUselessFile.Text = "删除无效文件";
            this.toolStripMenuItem_DeleteUselessFile.Click += new System.EventHandler(this.toolStripMenuItem_DeleteUselessFile_Click);
            // 
            // toolStripMenuItem_LocalList_ClearList
            // 
            this.toolStripMenuItem_LocalList_ClearList.Name = "toolStripMenuItem_LocalList_ClearList";
            this.toolStripMenuItem_LocalList_ClearList.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_LocalList_ClearList.Text = "清空整个列表";
            this.toolStripMenuItem_LocalList_ClearList.Click += new System.EventHandler(this.toolStripMenuItem_LocalList_ClearList_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_MoveUp
            // 
            this.toolStripMenuItem_MoveUp.Name = "toolStripMenuItem_MoveUp";
            this.toolStripMenuItem_MoveUp.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_MoveUp.Text = "上移";
            this.toolStripMenuItem_MoveUp.Click += new System.EventHandler(this.toolStripMenuItem_MoveUp_Click);
            // 
            // toolStripMenuItem_MoveTop
            // 
            this.toolStripMenuItem_MoveTop.Name = "toolStripMenuItem_MoveTop";
            this.toolStripMenuItem_MoveTop.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_MoveTop.Text = "置顶";
            this.toolStripMenuItem_MoveTop.Click += new System.EventHandler(this.toolStripMenuItem_MoveTop_Click);
            // 
            // toolStripMenuItem_MoveDown
            // 
            this.toolStripMenuItem_MoveDown.Name = "toolStripMenuItem_MoveDown";
            this.toolStripMenuItem_MoveDown.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_MoveDown.Text = "下移";
            this.toolStripMenuItem_MoveDown.Click += new System.EventHandler(this.toolStripMenuItem_MoveDown_Click);
            // 
            // toolStripMenuItem_MoveBottom
            // 
            this.toolStripMenuItem_MoveBottom.Name = "toolStripMenuItem_MoveBottom";
            this.toolStripMenuItem_MoveBottom.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_MoveBottom.Text = "置底";
            this.toolStripMenuItem_MoveBottom.Click += new System.EventHandler(this.toolStripMenuItem_MoveBottom_Click);
            // 
            // dSkinContextMenuStrip_TV
            // 
            this.dSkinContextMenuStrip_TV.Arrow = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip_TV.Back = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.BackColor = System.Drawing.SystemColors.Control;
            this.dSkinContextMenuStrip_TV.BackRadius = 1;
            this.dSkinContextMenuStrip_TV.Base = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dSkinContextMenuStrip_TV.Fore = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip_TV.HoverFore = System.Drawing.Color.White;
            this.dSkinContextMenuStrip_TV.ItemAnamorphosis = false;
            this.dSkinContextMenuStrip_TV.ItemBorder = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.ItemBorderShow = false;
            this.dSkinContextMenuStrip_TV.ItemHover = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.ItemPressed = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.ItemRadius = 1;
            this.dSkinContextMenuStrip_TV.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip_TV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_TV_Play,
            this.toolStripMenuItem_TV_ChangeSource,
            this.toolStripMenuItem_EditSource,
            this.toolStripSeparator1,
            this.toolStripMenuItem_ExpandCollapseAll,
            this.toolStripMenuItem_RefreshTVList});
            this.dSkinContextMenuStrip_TV.ItemSplitter = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.Name = "dSkinContextMenuStrip_TV";
            this.dSkinContextMenuStrip_TV.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip_TV.Size = new System.Drawing.Size(125, 120);
            this.dSkinContextMenuStrip_TV.SkinAllColor = true;
            this.dSkinContextMenuStrip_TV.TitleAnamorphosis = true;
            this.dSkinContextMenuStrip_TV.TitleColor = System.Drawing.Color.Transparent;
            this.dSkinContextMenuStrip_TV.TitleRadius = 4;
            this.dSkinContextMenuStrip_TV.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // PlayListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.CaptionHeight = 4;
            this.ClientSize = new System.Drawing.Size(232, 400);
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinTabControl1);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MoveMode = DSkin.Forms.MoveModes.None;
            this.Name = "PlayListFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.PlayListFrm_Load);
            this.SizeChanged += new System.EventHandler(this.PlayListFrm_SizeChanged);
            this.dSkinTabControl1.ResumeLayout(false);
            this.dSkinTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinGridList_PlayList_LocalList)).EndInit();
            this.dSkinContextMenuStrip_LocalList.ResumeLayout(false);
            this.dSkinContextMenuStrip_TV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DSkin.Controls.DSkinTabPage dSkinTabPage1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TV_Play;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TV_ChangeSource;
        public DSkin.Controls.DSkinGridList dSkinGridList_PlayList_LocalList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LocalList_Play;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LocalList_Delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LocalList_ClearList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LocalList_Add;
        public DSkin.Controls.DSkinTabControl dSkinTabControl1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExpandCollapseAll;
        public DSkin.Controls.DSkinContextMenuStrip dSkinContextMenuStrip_LocalList;
        public DSkin.Controls.DSkinContextMenuStrip dSkinContextMenuStrip_TV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteUselessFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PlayFromStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveTop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveBottom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RefreshTVList;
    }
}