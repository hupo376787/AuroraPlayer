namespace Aurora_Player
{
    partial class ControlFrm
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
            this.dSkinTrackBar_Progress = new DSkin.Controls.DSkinTrackBar();
            this.dSkinButton_PlayPause = new DSkin.Controls.DSkinButton();
            this.dSkinButton_Next = new DSkin.Controls.DSkinButton();
            this.dSkinButton_Previous = new DSkin.Controls.DSkinButton();
            this.dSkinLabel_CurrentTime = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel_TotalTime = new DSkin.Controls.DSkinLabel();
            this.dSkinButton_Volumn = new DSkin.Controls.DSkinButton();
            this.dSkinTrackBar_Volumn = new DSkin.Controls.DSkinTrackBar();
            this.dSkinButton_PlayList = new DSkin.Controls.DSkinButton();
            this.dSkinButton_VR = new DSkin.Controls.DSkinButton();
            this.SuspendLayout();
            // 
            // dSkinTrackBar_Progress
            // 
            this.dSkinTrackBar_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinTrackBar_Progress.InnerPadding = 10;
            this.dSkinTrackBar_Progress.IsEllipsePointButton = true;
            this.dSkinTrackBar_Progress.Location = new System.Drawing.Point(7, 2);
            this.dSkinTrackBar_Progress.MainLineBorderColor = System.Drawing.Color.Transparent;
            this.dSkinTrackBar_Progress.MainLineBorderWidth = 1;
            this.dSkinTrackBar_Progress.MainLineBrushDown = null;
            this.dSkinTrackBar_Progress.MainLineBrushUp = null;
            this.dSkinTrackBar_Progress.MainLineColorDown = System.Drawing.Color.White;
            this.dSkinTrackBar_Progress.MainLineColorUp = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Progress.MainLineWidth = 6;
            this.dSkinTrackBar_Progress.Maximum = 1000;
            this.dSkinTrackBar_Progress.Minimum = 0;
            this.dSkinTrackBar_Progress.Name = "dSkinTrackBar_Progress";
            this.dSkinTrackBar_Progress.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.dSkinTrackBar_Progress.PointButtonBorderColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Progress.PointButtonBorderWidth = 2;
            this.dSkinTrackBar_Progress.PointButtonHoverColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Progress.PointButtonHoverImage = null;
            this.dSkinTrackBar_Progress.PointButtonNormalColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Progress.PointButtonNormalImage = null;
            this.dSkinTrackBar_Progress.PointButtonPressColor = System.Drawing.Color.White;
            this.dSkinTrackBar_Progress.PointButtonPressImage = null;
            this.dSkinTrackBar_Progress.PointButtonSize = new System.Drawing.Size(14, 14);
            this.dSkinTrackBar_Progress.Size = new System.Drawing.Size(624, 32);
            this.dSkinTrackBar_Progress.TabIndex = 2;
            this.dSkinTrackBar_Progress.Text = "dSkinTrackBar_Progress";
            this.dSkinTrackBar_Progress.Value = 0;
            this.dSkinTrackBar_Progress.Click += new System.EventHandler(this.dSkinTrackBar_Progress_Click);
            this.dSkinTrackBar_Progress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dSkinTrackBar_Progress_MouseClick);
            this.dSkinTrackBar_Progress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinTrackBar_Progress_MouseDown);
            this.dSkinTrackBar_Progress.MouseEnter += new System.EventHandler(this.dSkinTrackBar_Progress_MouseEnter);
            this.dSkinTrackBar_Progress.MouseLeave += new System.EventHandler(this.dSkinTrackBar_Progress_MouseLeave);
            this.dSkinTrackBar_Progress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dSkinTrackBar_Progress_MouseMove);
            this.dSkinTrackBar_Progress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dSkinTrackBar_Progress_MouseUp);
            // 
            // dSkinButton_PlayPause
            // 
            this.dSkinButton_PlayPause.AdaptImage = true;
            this.dSkinButton_PlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_PlayPause.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayPause.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayPause.ButtonBorderWidth = 1;
            this.dSkinButton_PlayPause.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_PlayPause.HoverColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayPause.HoverImage = null;
            this.dSkinButton_PlayPause.Image = global::Aurora_Player.Properties.Resources.Play24;
            this.dSkinButton_PlayPause.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_PlayPause.IsPureColor = true;
            this.dSkinButton_PlayPause.Location = new System.Drawing.Point(268, 29);
            this.dSkinButton_PlayPause.Name = "dSkinButton_PlayPause";
            this.dSkinButton_PlayPause.NormalImage = null;
            this.dSkinButton_PlayPause.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_PlayPause.PressedImage = null;
            this.dSkinButton_PlayPause.Radius = 30;
            this.dSkinButton_PlayPause.ShowButtonBorder = true;
            this.dSkinButton_PlayPause.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_PlayPause.TabIndex = 3;
            this.dSkinButton_PlayPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_PlayPause.TextPadding = 0;
            this.dSkinButton_PlayPause.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_PlayPause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_PlayPause_MouseDown);
            this.dSkinButton_PlayPause.MouseEnter += new System.EventHandler(this.dSkinButton_PlayPause_MouseEnter);
            this.dSkinButton_PlayPause.MouseLeave += new System.EventHandler(this.dSkinButton_PlayPause_MouseLeave);
            // 
            // dSkinButton_Next
            // 
            this.dSkinButton_Next.AdaptImage = true;
            this.dSkinButton_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_Next.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Next.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Next.ButtonBorderWidth = 1;
            this.dSkinButton_Next.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_Next.HoverColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Next.HoverImage = null;
            this.dSkinButton_Next.Image = global::Aurora_Player.Properties.Resources.Next24;
            this.dSkinButton_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Next.IsPureColor = true;
            this.dSkinButton_Next.Location = new System.Drawing.Point(347, 29);
            this.dSkinButton_Next.Name = "dSkinButton_Next";
            this.dSkinButton_Next.NormalImage = null;
            this.dSkinButton_Next.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_Next.PressedImage = null;
            this.dSkinButton_Next.Radius = 30;
            this.dSkinButton_Next.ShowButtonBorder = true;
            this.dSkinButton_Next.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_Next.TabIndex = 4;
            this.dSkinButton_Next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Next.TextPadding = 0;
            this.dSkinButton_Next.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_Next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_Next_MouseDown);
            this.dSkinButton_Next.MouseEnter += new System.EventHandler(this.dSkinButton_Next_MouseEnter);
            this.dSkinButton_Next.MouseLeave += new System.EventHandler(this.dSkinButton_Next_MouseLeave);
            // 
            // dSkinButton_Previous
            // 
            this.dSkinButton_Previous.AdaptImage = true;
            this.dSkinButton_Previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_Previous.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Previous.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Previous.ButtonBorderWidth = 1;
            this.dSkinButton_Previous.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_Previous.HoverColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Previous.HoverImage = null;
            this.dSkinButton_Previous.Image = global::Aurora_Player.Properties.Resources.Previous24;
            this.dSkinButton_Previous.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Previous.IsPureColor = true;
            this.dSkinButton_Previous.Location = new System.Drawing.Point(189, 29);
            this.dSkinButton_Previous.Name = "dSkinButton_Previous";
            this.dSkinButton_Previous.NormalImage = null;
            this.dSkinButton_Previous.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_Previous.PressedImage = null;
            this.dSkinButton_Previous.Radius = 30;
            this.dSkinButton_Previous.ShowButtonBorder = true;
            this.dSkinButton_Previous.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_Previous.TabIndex = 5;
            this.dSkinButton_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Previous.TextPadding = 0;
            this.dSkinButton_Previous.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_Previous.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_Previous_MouseDown);
            this.dSkinButton_Previous.MouseEnter += new System.EventHandler(this.dSkinButton_Previous_MouseEnter);
            this.dSkinButton_Previous.MouseLeave += new System.EventHandler(this.dSkinButton_Previous_MouseLeave);
            // 
            // dSkinLabel_CurrentTime
            // 
            this.dSkinLabel_CurrentTime.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel_CurrentTime.Location = new System.Drawing.Point(7, 28);
            this.dSkinLabel_CurrentTime.Name = "dSkinLabel_CurrentTime";
            this.dSkinLabel_CurrentTime.Size = new System.Drawing.Size(54, 16);
            this.dSkinLabel_CurrentTime.TabIndex = 6;
            this.dSkinLabel_CurrentTime.Text = "当前时间";
            // 
            // dSkinLabel_TotalTime
            // 
            this.dSkinLabel_TotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinLabel_TotalTime.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel_TotalTime.Location = new System.Drawing.Point(589, 28);
            this.dSkinLabel_TotalTime.Name = "dSkinLabel_TotalTime";
            this.dSkinLabel_TotalTime.Size = new System.Drawing.Size(42, 16);
            this.dSkinLabel_TotalTime.TabIndex = 7;
            this.dSkinLabel_TotalTime.Text = "总时间";
            // 
            // dSkinButton_Volumn
            // 
            this.dSkinButton_Volumn.AdaptImage = true;
            this.dSkinButton_Volumn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_Volumn.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Volumn.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Volumn.ButtonBorderWidth = 1;
            this.dSkinButton_Volumn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_Volumn.HoverColor = System.Drawing.Color.Fuchsia;
            this.dSkinButton_Volumn.HoverImage = null;
            this.dSkinButton_Volumn.Image = global::Aurora_Player.Properties.Resources.Volumn1_24;
            this.dSkinButton_Volumn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Volumn.IsPureColor = true;
            this.dSkinButton_Volumn.Location = new System.Drawing.Point(430, 29);
            this.dSkinButton_Volumn.Name = "dSkinButton_Volumn";
            this.dSkinButton_Volumn.NormalImage = null;
            this.dSkinButton_Volumn.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_Volumn.PressedImage = null;
            this.dSkinButton_Volumn.Radius = 30;
            this.dSkinButton_Volumn.ShowButtonBorder = true;
            this.dSkinButton_Volumn.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_Volumn.TabIndex = 8;
            this.dSkinButton_Volumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Volumn.TextPadding = 0;
            this.dSkinButton_Volumn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_Volumn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_Volumn_MouseDown);
            this.dSkinButton_Volumn.MouseEnter += new System.EventHandler(this.dSkinButton_Volumn_MouseEnter);
            this.dSkinButton_Volumn.MouseLeave += new System.EventHandler(this.dSkinButton_Volumn_MouseLeave);
            // 
            // dSkinTrackBar_Volumn
            // 
            this.dSkinTrackBar_Volumn.InnerPadding = 9;
            this.dSkinTrackBar_Volumn.IsEllipsePointButton = true;
            this.dSkinTrackBar_Volumn.Location = new System.Drawing.Point(476, 28);
            this.dSkinTrackBar_Volumn.MainLineBorderColor = System.Drawing.Color.Transparent;
            this.dSkinTrackBar_Volumn.MainLineBorderWidth = 1;
            this.dSkinTrackBar_Volumn.MainLineBrushDown = null;
            this.dSkinTrackBar_Volumn.MainLineBrushUp = null;
            this.dSkinTrackBar_Volumn.MainLineColorDown = System.Drawing.Color.White;
            this.dSkinTrackBar_Volumn.MainLineColorUp = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Volumn.MainLineWidth = 4;
            this.dSkinTrackBar_Volumn.Maximum = 100;
            this.dSkinTrackBar_Volumn.Minimum = 0;
            this.dSkinTrackBar_Volumn.Name = "dSkinTrackBar_Volumn";
            this.dSkinTrackBar_Volumn.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.dSkinTrackBar_Volumn.PointButtonBorderColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Volumn.PointButtonBorderWidth = 1;
            this.dSkinTrackBar_Volumn.PointButtonHoverColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Volumn.PointButtonHoverImage = null;
            this.dSkinTrackBar_Volumn.PointButtonNormalColor = System.Drawing.Color.Fuchsia;
            this.dSkinTrackBar_Volumn.PointButtonNormalImage = null;
            this.dSkinTrackBar_Volumn.PointButtonPressColor = System.Drawing.Color.White;
            this.dSkinTrackBar_Volumn.PointButtonPressImage = null;
            this.dSkinTrackBar_Volumn.PointButtonSize = new System.Drawing.Size(9, 9);
            this.dSkinTrackBar_Volumn.Size = new System.Drawing.Size(92, 32);
            this.dSkinTrackBar_Volumn.TabIndex = 9;
            this.dSkinTrackBar_Volumn.Text = "dSkinTrackBar2";
            this.dSkinTrackBar_Volumn.Value = 0;
            this.dSkinTrackBar_Volumn.ValueChanged += new System.EventHandler(this.dSkinTrackBar_Volumn_ValueChanged);
            this.dSkinTrackBar_Volumn.MouseEnter += new System.EventHandler(this.dSkinTrackBar_Volumn_MouseEnter);
            this.dSkinTrackBar_Volumn.MouseLeave += new System.EventHandler(this.dSkinTrackBar_Volumn_MouseLeave);
            // 
            // dSkinButton_PlayList
            // 
            this.dSkinButton_PlayList.AdaptImage = true;
            this.dSkinButton_PlayList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_PlayList.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayList.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayList.ButtonBorderWidth = 1;
            this.dSkinButton_PlayList.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_PlayList.HoverColor = System.Drawing.Color.Transparent;
            this.dSkinButton_PlayList.HoverImage = null;
            this.dSkinButton_PlayList.Image = global::Aurora_Player.Properties.Resources.PlayList_24;
            this.dSkinButton_PlayList.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_PlayList.IsPureColor = true;
            this.dSkinButton_PlayList.Location = new System.Drawing.Point(122, 29);
            this.dSkinButton_PlayList.Name = "dSkinButton_PlayList";
            this.dSkinButton_PlayList.NormalImage = null;
            this.dSkinButton_PlayList.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_PlayList.PressedImage = null;
            this.dSkinButton_PlayList.Radius = 30;
            this.dSkinButton_PlayList.ShowButtonBorder = true;
            this.dSkinButton_PlayList.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_PlayList.TabIndex = 10;
            this.dSkinButton_PlayList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_PlayList.TextPadding = 0;
            this.dSkinButton_PlayList.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_PlayList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_PlayList_MouseDown);
            this.dSkinButton_PlayList.MouseEnter += new System.EventHandler(this.dSkinButton_PlayList_MouseEnter);
            this.dSkinButton_PlayList.MouseLeave += new System.EventHandler(this.dSkinButton_PlayList_MouseLeave);
            // 
            // dSkinButton_VR
            // 
            this.dSkinButton_VR.AdaptImage = true;
            this.dSkinButton_VR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dSkinButton_VR.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_VR.ButtonBorderColor = System.Drawing.Color.Transparent;
            this.dSkinButton_VR.ButtonBorderWidth = 1;
            this.dSkinButton_VR.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_VR.HoverColor = System.Drawing.Color.Transparent;
            this.dSkinButton_VR.HoverImage = null;
            this.dSkinButton_VR.Image = global::Aurora_Player.Properties.Resources.VRCardbox1_24;
            this.dSkinButton_VR.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_VR.IsPureColor = true;
            this.dSkinButton_VR.Location = new System.Drawing.Point(62, 28);
            this.dSkinButton_VR.Name = "dSkinButton_VR";
            this.dSkinButton_VR.NormalImage = null;
            this.dSkinButton_VR.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_VR.PressedImage = null;
            this.dSkinButton_VR.Radius = 30;
            this.dSkinButton_VR.ShowButtonBorder = true;
            this.dSkinButton_VR.Size = new System.Drawing.Size(30, 30);
            this.dSkinButton_VR.TabIndex = 11;
            this.dSkinButton_VR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_VR.TextPadding = 0;
            this.dSkinButton_VR.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_VR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinButton_VR_MouseDown);
            this.dSkinButton_VR.MouseEnter += new System.EventHandler(this.dSkinButton_VR_MouseEnter);
            this.dSkinButton_VR.MouseLeave += new System.EventHandler(this.dSkinButton_VR_MouseLeave);
            // 
            // ControlFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(638, 64);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinButton_VR);
            this.Controls.Add(this.dSkinButton_PlayList);
            this.Controls.Add(this.dSkinTrackBar_Volumn);
            this.Controls.Add(this.dSkinButton_Volumn);
            this.Controls.Add(this.dSkinLabel_TotalTime);
            this.Controls.Add(this.dSkinLabel_CurrentTime);
            this.Controls.Add(this.dSkinButton_Previous);
            this.Controls.Add(this.dSkinButton_Next);
            this.Controls.Add(this.dSkinButton_PlayPause);
            this.Controls.Add(this.dSkinTrackBar_Progress);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.KeyPreview = true;
            this.MoveMode = DSkin.Forms.MoveModes.None;
            this.Name = "ControlFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.Load += new System.EventHandler(this.ControlFrm_Load);
            this.SizeChanged += new System.EventHandler(this.ControlFrm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlFrm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlFrm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ControlFrm_MouseEnter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControlFrm_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.ControlFrm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DSkin.Controls.DSkinTrackBar dSkinTrackBar_Progress;
        public DSkin.Controls.DSkinButton dSkinButton_Previous;
        public DSkin.Controls.DSkinButton dSkinButton_Next;
        public DSkin.Controls.DSkinButton dSkinButton_PlayPause;
        public DSkin.Controls.DSkinLabel dSkinLabel_TotalTime;
        public DSkin.Controls.DSkinLabel dSkinLabel_CurrentTime;
        public DSkin.Controls.DSkinButton dSkinButton_Volumn;
        public DSkin.Controls.DSkinTrackBar dSkinTrackBar_Volumn;
        public DSkin.Controls.DSkinButton dSkinButton_PlayList;
        public DSkin.Controls.DSkinButton dSkinButton_VR;
    }
}