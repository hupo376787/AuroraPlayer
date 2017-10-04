namespace Aurora_Player
{
    partial class EndUserLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndUserLicense));
            this.dSkinBaseControl1 = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBox1 = new DSkin.DirectUI.DuiTextBox();
            this.SuspendLayout();
            // 
            // dSkinBaseControl1
            // 
            this.dSkinBaseControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dSkinBaseControl1.DUIControls.AddRange(new DSkin.DirectUI.DuiBaseControl[] {
            this.duiTextBox1});
            this.dSkinBaseControl1.Location = new System.Drawing.Point(7, 25);
            this.dSkinBaseControl1.Name = "dSkinBaseControl1";
            this.dSkinBaseControl1.Size = new System.Drawing.Size(533, 293);
            this.dSkinBaseControl1.TabIndex = 0;
            this.dSkinBaseControl1.Text = "dSkinBaseControl1";
            // 
            // duiTextBox1
            // 
            this.duiTextBox1.AutoSize = false;
            this.duiTextBox1.Controls.AddRange(new DSkin.DirectUI.DuiBaseControl[] {
            this.duiTextBox1.InnerScrollBar});
            this.duiTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.duiTextBox1.DesignModeCanMove = false;
            this.duiTextBox1.DesignModeCanResize = false;
            this.duiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duiTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiTextBox1.Location = new System.Drawing.Point(0, 0);
            this.duiTextBox1.Multiline = true;
            this.duiTextBox1.Name = "duiTextBox1";
            this.duiTextBox1.ReadOnly = true;
            this.duiTextBox1.RollSize = 28;
            this.duiTextBox1.Size = new System.Drawing.Size(533, 293);
            this.duiTextBox1.Text = resources.GetString("duiTextBox1.Text");
            // 
            // EndUserLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(547, 325);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinBaseControl1);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndUserLicense";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.Text = "最终用户协议";
            this.Load += new System.EventHandler(this.EndUserLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinBaseControl dSkinBaseControl1;
        private DSkin.DirectUI.DuiTextBox duiTextBox1;
    }
}