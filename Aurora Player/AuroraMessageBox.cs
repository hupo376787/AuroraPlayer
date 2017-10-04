using System;
using DSkin.Forms;
using System.Windows.Forms;

namespace Aurora_Player
{
    public partial class AuroraMessageBox : DSkinForm
    {
        public AuroraMessageBox()
        {
            InitializeComponent();
        }

        //MainForm owner;
        public string strCaption = string.Empty;
        public string strMessage = string.Empty;
        public string strButtonText = string.Empty;

        private void Message_Load(object sender, EventArgs e)
        {
            //owner = (MainForm)this.Owner;
            //this.BackgroundImage = owner.BackImageCurrent;

            dSkinLabel_Caption.Text = strCaption;
            dSkinLabel_Message.Text = strMessage;
            dSkinButton_OK.Text = strButtonText;

            if (dSkinLabel_Message.Width > this.Width)
            {
                this.Width = dSkinLabel_Message.Width + 20;
                dSkinButton_OK.Left = this.Width / 2 - dSkinButton_OK.Width / 2;
            }
        }

        private void dSkinButton_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Message_FormClosed(object sender, FormClosedEventArgs e)
        {
            //owner.OverLayMainFrm(false);
        }

        private void AuroraMessageBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dSkinLabel_Message_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinLabel_Caption_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        //用法
        //Message msg = null;
        //        if (!IsOpenForm(msg))
        //            msg = new Message();
        //msg.strCaption = "Aurora智能提示";
        //        msg.strMessage = "请选择要删除的行(按Ctrl键可多选)";
        //        msg.StartPosition = FormStartPosition.CenterScreen;
        //        SetForeColor(msg, BackImageCurrent);
        //msg.Show(this);
    }
}
