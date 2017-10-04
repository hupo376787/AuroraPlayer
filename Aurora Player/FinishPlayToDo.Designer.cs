namespace Aurora_Player
{
    partial class FinishPlayToDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishPlayToDo));
            this.dSkinButton_Cancel = new DSkin.Controls.DSkinButton();
            this.dSkinLabel_Tip = new DSkin.Controls.DSkinLabel();
            this.SuspendLayout();
            // 
            // dSkinButton_Cancel
            // 
            this.dSkinButton_Cancel.AdaptImage = true;
            this.dSkinButton_Cancel.BaseColor = System.Drawing.Color.Transparent;
            this.dSkinButton_Cancel.ButtonBorderColor = System.Drawing.Color.Gray;
            this.dSkinButton_Cancel.ButtonBorderWidth = 1;
            this.dSkinButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton_Cancel.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton_Cancel.HoverImage = null;
            this.dSkinButton_Cancel.IsPureColor = false;
            this.dSkinButton_Cancel.Location = new System.Drawing.Point(163, 113);
            this.dSkinButton_Cancel.Name = "dSkinButton_Cancel";
            this.dSkinButton_Cancel.NormalImage = null;
            this.dSkinButton_Cancel.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton_Cancel.PressedImage = null;
            this.dSkinButton_Cancel.Radius = 60;
            this.dSkinButton_Cancel.ShowButtonBorder = true;
            this.dSkinButton_Cancel.Size = new System.Drawing.Size(60, 60);
            this.dSkinButton_Cancel.TabIndex = 13;
            this.dSkinButton_Cancel.Text = "取消";
            this.dSkinButton_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton_Cancel.TextPadding = 0;
            this.dSkinButton_Cancel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dSkinButton_Cancel.Click += new System.EventHandler(this.dSkinButton_Cancel_Click);
            // 
            // dSkinLabel_Tip
            // 
            this.dSkinLabel_Tip.Location = new System.Drawing.Point(79, 59);
            this.dSkinLabel_Tip.Name = "dSkinLabel_Tip";
            this.dSkinLabel_Tip.Size = new System.Drawing.Size(73, 14);
            this.dSkinLabel_Tip.TabIndex = 14;
            this.dSkinLabel_Tip.Text = "dSkinLabel1";
            // 
            // FinishPlayToDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionHeight = 22;
            this.CaptionOffset = new System.Drawing.Point(2, 2);
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.CloseBox.HoverBackColor = System.Drawing.Color.Red;
            this.CloseBox.NormalColor = System.Drawing.Color.White;
            this.CloseBox.Size = new System.Drawing.Size(30, 22);
            this.Controls.Add(this.dSkinLabel_Tip);
            this.Controls.Add(this.dSkinButton_Cancel);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinishPlayToDo";
            this.ShowInTaskbar = false;
            this.ShowShadow = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "播放结束操作";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinishPlayToDo_FormClosing);
            this.Load += new System.EventHandler(this.FinishPlay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinButton dSkinButton_Cancel;
        private DSkin.Controls.DSkinLabel dSkinLabel_Tip;
    }
}