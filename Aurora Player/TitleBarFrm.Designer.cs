namespace Aurora_Player
{
    partial class TitleBarFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleBarFrm));
            this.SuspendLayout();
            // 
            // TitleBarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 25;
            this.CaptionOffset = new System.Drawing.Point(3, 2);
            this.ClientSize = new System.Drawing.Size(666, 25);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.CloseBox.ToolTip = "关闭Aurora";
            this.DoubleClickMaximized = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconRectangle = new System.Drawing.Rectangle(2, 2, 20, 20);
            this.KeyPreview = true;
            this.MaxBox.NormalColor = System.Drawing.Color.White;
            this.MaxBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MaxBox.Size = new System.Drawing.Size(30, 22);
            this.MaxBox.ToolTip = "最大化";
            this.MaximizeBox = false;
            this.MinBox.NormalColor = System.Drawing.Color.White;
            this.MinBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MinBox.Size = new System.Drawing.Size(30, 22);
            this.MinBox.ToolTip = "最小化";
            this.MinimumSize = new System.Drawing.Size(25, 25);
            this.MoveMode = DSkin.Forms.MoveModes.Title;
            this.Name = "TitleBarFrm";
            this.NormalBox.NormalColor = System.Drawing.Color.White;
            this.NormalBox.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NormalBox.Size = new System.Drawing.Size(30, 22);
            this.NormalBox.ToolTip = "还原";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Aurora Player";
            this.SystemButtonMouseClick += new System.EventHandler<DSkin.Forms.SystemButtonMouseClickEventArgs>(this.TitleBarFrm_SystemButtonMouseClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TitleBarFrm_FormClosing);
            this.Load += new System.EventHandler(this.TitleBarFrm_Load);
            this.LocationChanged += new System.EventHandler(this.TitleBarFrm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.TitleBarFrm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBarFrm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TitleBarFrm_MouseEnter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TitleBarFrm_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}