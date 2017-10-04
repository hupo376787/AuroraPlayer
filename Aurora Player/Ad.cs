using System;
using System.Drawing;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class Ad : DSkinForm
    {
        public Ad()
        {
            InitializeComponent();
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(Ad_Tick);
        }

        MainForm mainfrm;
        Timer tm = null;
        //IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");

        public int n_AdType = 0;
        public int n_ShowAdTimeLength = 10;
        public string str_AdUrl = "http://www.2345.com/?k53345154";
        public string str_WhatisNew = "";

        private void Ad_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackgroundImage = mainfrm.BackImageCurrent;
            this.BackgroundImageLayout = ImageLayout.Center;
            tm.Enabled = true;
            tm.Start();

            //-1    不显示广告窗体
            //0     显示广告
            //1     显示更新内容
            if (n_AdType == (int)PublicClass.AdType.AdAd)    //显示广告
            {
                this.Text = "广告推送(10s后自动关闭)";
                controlHost1.Visible = false;
                dSkinChatRichTextBox1.Visible = false;
                dSkinBrowser1.Url = str_AdUrl;
            }
            else if (n_AdType == (int)PublicClass.AdType.WhatIsNew)   //显示更新内容
            {
                this.Text = "What's New";
                dSkinCheckBox_ShowAdOnceMore.Visible = false;
                dSkinBrowser1.Visible = false;
                dSkinChatRichTextBox1.Text = str_WhatisNew;
                //tm.Enabled = false;
                //tm.Stop();
            }

            //Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            //int xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            //int yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            //this.Location = new Point(xPos, yPos);

            #region 窗体右下角向上显示特效
            //自定义特效
            Opacity = 0;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;

            int xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int yPos = Screen.PrimaryScreen.WorkingArea.Height;

            this.Location = new Point(xPos, yPos);
            int endTop = Screen.PrimaryScreen.WorkingArea.Height - Height;
            DoEffect(() =>
            {
                if (Top > (endTop))
                {
                    Opacity = 1 - 1.0 * (Height - endTop) / (rect.Height - Height - endTop);
                    if ((Top - endTop) < 5)
                    {
                        Top -= (Top - endTop);
                    }
                    else
                    {
                        Top -= ((Top - endTop) / 5);
                    }
                    return true;
                }
                Opacity = 1;
                ShowShadow = true;
                return false;
            });
            #endregion
        }

        private void Ad_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(dSkinCheckBox_ShowAdOnceMore.Checked == true)
                //ini.WriteValue("Settings", "LastAdDate", DateTime.Now.ToString("yyyy-MM-dd"));

            if (this.WindowState == FormWindowState.Normal)
            {
                #region 关闭窗体特效
                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                int h = Screen.PrimaryScreen.Bounds.Height;
                int xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                int yPos = Screen.PrimaryScreen.WorkingArea.Height;
                int endTop = h;
                //窗体关闭特效
                int top = Top;
                DoEffect(() =>
                {
                    if (Top < (endTop - 4))
                    {
                        Opacity = 1.0 * (endTop) / (Top);
                        Top += ((endTop - Top) / 5);
                        return true;
                    }
                    Opacity = 0;
                    ShowShadow = false;
                    Close();
                    return false;
                });

                #endregion
            }
        }

        private void Ad_Tick(object sender, EventArgs e)
        {
            //n++;
            n_ShowAdTimeLength--;
            this.Text = "广告推送(" + n_ShowAdTimeLength.ToString() + "s后自动关闭)";
            //if (n >= n_ShowAdTimeLength)
            if (n_ShowAdTimeLength <= 0)
            {
                tm.Dispose();
                this.Close();
            }
        }

        private void dSkinCheckBox_ShowAdOnceMore_CheckedChanged(object sender, EventArgs e)
        {
            //if(dSkinCheckBox_ShowAdOnceMore.Checked == true && tm != null)
            //{
            //    tm.Enabled = false;
            //    AuroraMessageBox msg = null;
            //    msg = new AuroraMessageBox();
            //    msg.strCaption = "Aurora智能提示";
            //    msg.strMessage = "确定今天不再显示推送内容了吗？";
            //    msg.strButtonText = "确定";
            //    msg.StartPosition = FormStartPosition.Manual;
            //    msg.Location = new Point(this.Location.X + this.Width / 2 - msg.Width / 2, this.Location.Y + this.Height / 2 - msg.Height / 2);
            //    msg.ShowDialog();
            //    tm.Enabled = true;
            //}
            //ini.WriteValue("Settings", "ShowAdOnceMore", (!dSkinCheckBox_ShowAdOnceMore.Checked).ToString());
        }

    }
}
