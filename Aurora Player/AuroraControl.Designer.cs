namespace Aurora_Player
{
    partial class AuroraControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dSkinPictureBox_VR = new DSkin.Controls.DSkinPictureBox();
            this.dSkinBaseControl1 = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBox_VR = new DSkin.DirectUI.DuiTextBox();
            this.SuspendLayout();
            // 
            // dSkinPictureBox_VR
            // 
            this.dSkinPictureBox_VR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinPictureBox_VR.Borders.AllColor = System.Drawing.Color.Transparent;
            this.dSkinPictureBox_VR.Borders.BottomColor = System.Drawing.Color.Transparent;
            this.dSkinPictureBox_VR.Borders.LeftColor = System.Drawing.Color.Transparent;
            this.dSkinPictureBox_VR.Borders.RightColor = System.Drawing.Color.Transparent;
            this.dSkinPictureBox_VR.Borders.TopColor = System.Drawing.Color.Transparent;
            this.dSkinPictureBox_VR.Image = null;
            this.dSkinPictureBox_VR.Images = null;
            this.dSkinPictureBox_VR.Interval = 40;
            this.dSkinPictureBox_VR.Location = new System.Drawing.Point(20, 3);
            this.dSkinPictureBox_VR.Name = "dSkinPictureBox_VR";
            this.dSkinPictureBox_VR.Size = new System.Drawing.Size(160, 160);
            this.dSkinPictureBox_VR.TabIndex = 3;
            this.dSkinPictureBox_VR.Text = "dSkinPictureBox1";
            this.dSkinPictureBox_VR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox_VR_MouseDown);
            this.dSkinPictureBox_VR.MouseEnter += new System.EventHandler(this.dSkinPictureBox_VR_MouseEnter);
            this.dSkinPictureBox_VR.MouseLeave += new System.EventHandler(this.dSkinPictureBox_VR_MouseLeave);
            this.dSkinPictureBox_VR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dSkinPictureBox_VR_MouseUp);
            // 
            // dSkinBaseControl1
            // 
            this.dSkinBaseControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinBaseControl1.DUIControls.AddRange(new DSkin.DirectUI.DuiBaseControl[] {
            this.duiTextBox_VR});
            this.dSkinBaseControl1.Location = new System.Drawing.Point(3, 169);
            this.dSkinBaseControl1.Name = "dSkinBaseControl1";
            this.dSkinBaseControl1.Size = new System.Drawing.Size(194, 28);
            this.dSkinBaseControl1.TabIndex = 4;
            this.dSkinBaseControl1.Text = "dSkinBaseControl1";
            // 
            // duiTextBox_VR
            // 
            this.duiTextBox_VR.AutoSize = false;
            this.duiTextBox_VR.BackColor = System.Drawing.Color.Transparent;
            this.duiTextBox_VR.Controls.AddRange(new DSkin.DirectUI.DuiBaseControl[] {
            this.duiTextBox_VR.InnerScrollBar});
            this.duiTextBox_VR.Cursor = System.Windows.Forms.Cursors.Default;
            this.duiTextBox_VR.DesignModeCanMove = false;
            this.duiTextBox_VR.DesignModeCanResize = false;
            this.duiTextBox_VR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duiTextBox_VR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiTextBox_VR.Location = new System.Drawing.Point(0, 0);
            this.duiTextBox_VR.Multiline = true;
            this.duiTextBox_VR.Name = "duiTextBox_VR";
            this.duiTextBox_VR.ReadOnly = true;
            this.duiTextBox_VR.SelectionBackColor = System.Drawing.Color.Transparent;
            this.duiTextBox_VR.SelectionColor = System.Drawing.Color.Transparent;
            this.duiTextBox_VR.Size = new System.Drawing.Size(194, 28);
            this.duiTextBox_VR.Text = "矩形双目全景\n左右(Oculus)";
            this.duiTextBox_VR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.duiTextBox_VR.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.duiTextBox_VR_MouseEnter);
            this.duiTextBox_VR.MouseLeave += new System.EventHandler(this.duiTextBox_VR_MouseLeave);
            this.duiTextBox_VR.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiTextBox_VR_MouseDown);
            this.duiTextBox_VR.MouseUp += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiTextBox_VR_MouseUp);
            // 
            // AuroraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Borders.AllColor = System.Drawing.Color.DeepSkyBlue;
            this.Borders.BottomColor = System.Drawing.Color.DeepSkyBlue;
            this.Borders.LeftColor = System.Drawing.Color.DeepSkyBlue;
            this.Borders.RightColor = System.Drawing.Color.DeepSkyBlue;
            this.Borders.TopColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.dSkinBaseControl1);
            this.Controls.Add(this.dSkinPictureBox_VR);
            this.Name = "AuroraControl";
            this.Size = new System.Drawing.Size(200, 200);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AuroraControl_MouseDown);
            this.MouseEnter += new System.EventHandler(this.AuroraControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AuroraControl_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AuroraControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private DSkin.Controls.DSkinBaseControl dSkinBaseControl1;
        public DSkin.DirectUI.DuiTextBox duiTextBox_VR;
        public DSkin.Controls.DSkinPictureBox dSkinPictureBox_VR;
    }
}
