using System;
using System.Windows.Forms;
using System.Drawing;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class AboutMe : DSkinForm
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        MainForm mainfrm;

        private void dSkinButton1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void AboutMe_Load(object sender, System.EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            duiTextBox1.InnerScrollBar.Fillet = true;
            //if (mainfrm.b_ImageFuzzy)
            //{
            //    Bitmap bt = mainfrm.BackImageCurrent;
            //    Rectangle rect = new Rectangle(0, 0, bt.Width, bt.Height);
            //    DSkin.ImageEffects.GaussianBlur(bt, ref rect, 20, false);
            //    this.BackgroundImage = bt;
            //}
            //else
            //{
            //    this.BackgroundImage = mainfrm.BackImageCurrent;
            //}
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            
        }

        private void AboutMe_FormClosed(object sender, FormClosedEventArgs e)
        {
            //owner.OverLayMainFrm(false);
        }

        //连续单机5次。
        private int i = 0;              //i用来计数，看点击了几次鼠标
        private DateTime lastClickTime = DateTime.MinValue;
        private void AboutMe_Click(object sender, System.EventArgs e)
        {
            DateTime now = DateTime.Now;

            if ((now - lastClickTime).TotalMilliseconds <= 500)             // 两次点击间隔小于500毫秒时，算连续点击
            {
                i++;
                if (i >= 5)
                {
                    i = 0;// 连续点击完毕时，清0

                    //dSkinLabel_Version.Text = "http://www.auroraplayer.com/";
                }
            }
            else
            {
                i = 1;// 不是连续点击时，清0
            }
            lastClickTime = now;
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

        private void dSkinLabel_Website_MouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.auroraplayer.com");
        }

        private void dSkinLabel_Website_MouseEnter(object sender, EventArgs e)
        {
            dSkinLabel_Website.Cursor = Cursors.Hand;
        }

        private void dSkinLabel_Website_MouseLeave(object sender, EventArgs e)
        {
            dSkinLabel_Website.Cursor = Cursors.Arrow;
        }

        private void dSkinLabel4_MouseDown(object sender, MouseEventArgs e)
        {
            EndUserLicense dd = new EndUserLicense();
            dd.StartPosition = FormStartPosition.CenterParent;
            dd.ShowDialog();
        }

        private void dSkinLabel4_MouseEnter(object sender, EventArgs e)
        {
            dSkinLabel4.Cursor = Cursors.Hand;
        }

        private void dSkinLabel4_MouseLeave(object sender, EventArgs e)
        {
            dSkinLabel4.Cursor = Cursors.Arrow;
        }
    }
}
