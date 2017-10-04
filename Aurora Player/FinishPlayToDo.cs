using System;
using System.Windows.Forms;
using System.Drawing;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class FinishPlayToDo : DSkinForm
    {
        public FinishPlayToDo()
        {
            InitializeComponent();
        }

        public int n_FinishodoNext = -1;
        //int n_Tick = 0;
        int n_LeftSecond = 30;
        Timer tm;
        MainForm mainfrm;

        private void FinishPlay_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //this.BackgroundImage = main.BackImageCurrent;
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new System.EventHandler(this.timer_Tick);
            tm.Start();

            if (n_FinishodoNext == 0)
            {
                dSkinLabel_Tip.Text = "Aurora播放器即将在30s后即将关闭";
            }
            else if (n_FinishodoNext == 1)
            {
                dSkinLabel_Tip.Text = "电脑即将在30s后即将注销";
            }
            else if (n_FinishodoNext == 2)
            {
                dSkinLabel_Tip.Text = "电脑即将在30s后即将关机";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //n_Tick++;
            n_LeftSecond--;
            Console.WriteLine(n_LeftSecond);
            if (n_FinishodoNext == 0)
            {
                dSkinLabel_Tip.Text = "Aurora播放器即将在" + n_LeftSecond.ToString() + "s后即将关闭";
            }
            else if (n_FinishodoNext == 1)
            {
                dSkinLabel_Tip.Text = "电脑即将在" + n_LeftSecond.ToString() + "s后即将注销";
            }
            else if (n_FinishodoNext == 2)
            {
                dSkinLabel_Tip.Text = "电脑即将在" + n_LeftSecond.ToString() + "s后即将关机";
            }

            if (n_LeftSecond <= 0)
            {
                if(n_FinishodoNext == 0)
                {
                    this.Close();
                    mainfrm.QuitApp();
                }
                else if (n_FinishodoNext == 1)
                {
                    CommandHelper.Excute("shutdown /l");
                }
                else if (n_FinishodoNext == 2)
                {
                    CommandHelper.Excute("shutdown /s /t 0");
                }
            }
        }

        private void FinishPlayToDo_FormClosing(object sender, FormClosingEventArgs e)
        {
            tm.Dispose();
        }

        private void dSkinButton_Cancel_Click(object sender, EventArgs e)
        {
            CommandHelper.Excute("shutdown /a");
            dSkinLabel_Tip.Text = "用户已取消操作";
            mainfrm.ShowTips("用户已取消操作");
            this.Close();
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
    }
}
