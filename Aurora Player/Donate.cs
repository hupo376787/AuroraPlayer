using System;
using System.Drawing;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class Donate : DSkinForm
    {
        public Donate()
        {
            InitializeComponent();
        }
        
        MainForm mainfrm;

        private void Donate_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //this.BackgroundImage = main.BackImageCurrent;
        }

        #region 改变窗体背景
        protected override void OnLayeredPaintBackground(PaintEventArgs e)
        {
            base.OnLayeredPaintBackground(e);

            //SetForeColor(this, mainFrm.BackImageCurrent);

            if (mainfrm.BackImageCurrent != null)
            {
                if (mainfrm.n_BackImageTransparency <= 1)
                {
                    return;
                }
                if (mainfrm.n_BackImageTransparency == 100)
                {
                    e.Graphics.DrawImage(mainfrm.BackImageCurrent, 0, 0, this.Width, this.Height);
                    return;
                }
                e.Graphics.DrawImage(mainfrm.BackImageCurrent, new Rectangle(0, 0, this.Width, this.Height),
                    0, 0, mainfrm.BackImageCurrent.Width, mainfrm.BackImageCurrent.Height, GraphicsUnit.Pixel,
                    DSkin.ImageEffects.ChangeOpacity((float)(1.0 * mainfrm.n_BackImageTransparency / 100)));
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }
        #endregion

        private void Donate_Resize(object sender, EventArgs e)
        {
            dSkinPictureBox1.Width = dSkinPictureBox2.Width = (this.Width - 90) / 2;
            dSkinPictureBox2.Left = this.Width - dSkinPictureBox2.Width - 7;
            dSkinLabel1.Left = dSkinPictureBox1.Left + dSkinPictureBox1.Width / 2 - dSkinLabel1.Width / 2;
            dSkinLabel2.Left = dSkinPictureBox2.Left + dSkinPictureBox2.Width / 2 - dSkinLabel2.Width / 2;
        }

        private void duiTextBox1_MouseDown(object sender, DSkin.DirectUI.DuiMouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }
    }
}
