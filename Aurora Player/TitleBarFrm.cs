using System;
using System.Drawing;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class TitleBarFrm : DSkinForm
    {
        public TitleBarFrm()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this.ControlFrm_MouseWheel);
        }

        MainForm mainfrm;

        private SystemButton systemButton_Settings;
        private SystemButton systemButton_UserCenter;
        public SystemButton systemButton_FullScreen;
        private SystemButton systemButton_ScreenShot;
        private SystemButton systemButton_SetTop;
        private SystemButton systemButton_FeedBack;

        private void TitleBarFrm_Load(object sender, EventArgs e)
        {
            this.Height = 25;
            this.Opacity = 0.75;
            InitSystemButton();
            mainfrm = (MainForm)this.Owner;
            mainfrm.LocateResizeTitleBarPanel();
        }

        private void ControlFrm_MouseWheel(object sender, MouseEventArgs e)
        {
            mainfrm.MainForm_MouseWheel(sender, e);
        }

        private void TitleBarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainfrm.QuitApp();
        }

        private void TitleBarFrm_LocationChanged(object sender, EventArgs e)
        {
            if (mainfrm != null)
            {
                if (mainfrm.b_isFullScreen)
                    return;
                else
                {
                    mainfrm.Location = new Point(this.Location.X - 1, this.Location.Y - 1);
                }
            }
        }

        private void TitleBarFrm_SizeChanged(object sender, EventArgs e)
        {
            if (mainfrm != null && mainfrm.b_isFullScreen)
                this.MoveMode = MoveModes.None;
            //if(if(mainfrm != null))
            //{
            //    if (this.WindowState == FormWindowState.Minimized)
            //    {
            //        //this.WindowState = FormWindowState.Normal;
            //        //mainfrm.WindowState = FormWindowState.Minimized;
            //        this.Hide();
            //        //mainfrm.MinimizeApp();
            //    }
            //    else
            //    {
            //        this.Show();
            //        mainfrm.WindowState = FormWindowState.Normal;
            //    }
            //}
        }

        #region 系统按钮栏：皮肤按钮、反馈按钮
        private void InitSystemButton()
        {
            InitSettingsButton();
            InitFullScreenButton();
            InitScreenShotButton();
            InitSetTopButton();
            InitFeedBackButton();
            this.MinBox.MouseClick += delegate {
                mainfrm.WindowState = FormWindowState.Minimized;
            };
        }

        private void InitSettingsButton()
        {
            systemButton_Settings = new SystemButton();
            systemButton_Settings.Image = global::Aurora_Player.Properties.Resources.Settingss;
            systemButton_Settings.Name = "Settings";
            systemButton_Settings.ToolTip = "设置";
            systemButton_Settings.NormalBackColor = System.Drawing.Color.Transparent;
            systemButton_Settings.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            systemButton_Settings.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            systemButton_Settings.Size = new Size(30, 22);
            this.SystemButtons.Add(systemButton_Settings);
        }

        //private void InitUserCenterButton()
        //{
        //    systemButton_UserCenter = new SystemButton();
        //    systemButton_UserCenter.Image = global::Aurora_Player.Properties.Resources.UserCenter;
        //    systemButton_UserCenter.Name = "UserCenter";
        //    systemButton_UserCenter.ToolTip = "个人中心";
        //    systemButton_UserCenter.NormalBackColor = System.Drawing.Color.Transparent;
        //    systemButton_UserCenter.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
        //    systemButton_UserCenter.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
        //    systemButton_UserCenter.Size = new Size(30, 22);
        //    this.SystemButtons.Add(systemButton_UserCenter);
        //}

        private void InitFullScreenButton()
        {
            systemButton_FullScreen = new SystemButton();
            systemButton_FullScreen.Image = global::Aurora_Player.Properties.Resources.FullScreenF;
            systemButton_FullScreen.Name = "FullScreen";
            systemButton_FullScreen.ToolTip = "全屏";
            systemButton_FullScreen.NormalBackColor = System.Drawing.Color.Transparent;
            systemButton_FullScreen.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            systemButton_FullScreen.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            systemButton_FullScreen.Size = new Size(30, 22);
            this.SystemButtons.Add(systemButton_FullScreen);
        }

        private void InitScreenShotButton()
        {
            systemButton_ScreenShot = new SystemButton();
            systemButton_ScreenShot.Image = global::Aurora_Player.Properties.Resources.Camera;
            systemButton_ScreenShot.Name = "ScreenShot";
            systemButton_ScreenShot.ToolTip = "截图";
            systemButton_ScreenShot.NormalBackColor = System.Drawing.Color.Transparent;
            systemButton_ScreenShot.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            systemButton_ScreenShot.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            //systemButton_Skin.NormalImage = global::Aurora_Stock.Properties.Resources.skinNormal;
            //systemButton_Skin.PressImage = global::Aurora_Stock.Properties.Resources.skinPress;
            systemButton_ScreenShot.Size = new Size(30, 22);
            this.SystemButtons.Add(systemButton_ScreenShot);
        }

        private void InitSetTopButton()
        {
            systemButton_SetTop = new SystemButton();
            systemButton_SetTop.Image = global::Aurora_Player.Properties.Resources.Nail;
            systemButton_SetTop.Name = "SetTop";
            systemButton_SetTop.ToolTip = "置顶";
            systemButton_SetTop.NormalBackColor = System.Drawing.Color.Transparent;
            systemButton_SetTop.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            systemButton_SetTop.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            systemButton_SetTop.Size = new Size(30, 22);
            this.SystemButtons.Add(systemButton_SetTop);
        }

        private void InitFeedBackButton()
        {
            systemButton_FeedBack = new SystemButton();
            systemButton_FeedBack.Image = global::Aurora_Player.Properties.Resources.FeedBack;
            systemButton_FeedBack.Name = "FeedBack";
            systemButton_FeedBack.ToolTip = "关于";
            systemButton_FeedBack.NormalBackColor = System.Drawing.Color.Transparent;
            systemButton_FeedBack.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            systemButton_FeedBack.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            systemButton_FeedBack.Size = new Size(30, 22);
            this.SystemButtons.Add(systemButton_FeedBack);
        }

        private void TitleBarFrm_SystemButtonMouseClick(object sender, SystemButtonMouseClickEventArgs e)
        {
            if (e.Button.Name == "ScreenShot")
            {
                mainfrm.CallScreenShot();
            }
            else if (e.Button.Name == "Settings")
            {
                mainfrm.CallSettings();
            }
            else if (e.Button.Name == "UserCenter")
            {
                //mainfrm.CallUserCenter();
            }
            else if (e.Button.Name == "FullScreen")
            {
                mainfrm.MaxScreen();
            }
            else if (e.Button.Name == "SetTop")
            {
                if(mainfrm.str_TopMost == "Never")
                    mainfrm.str_TopMost = "TopMostWhilePlay";
                else if (mainfrm.str_TopMost == "TopMostWhilePlay")
                    mainfrm.str_TopMost = "Always";
                else if (mainfrm.str_TopMost == "Always")
                    mainfrm.str_TopMost = "Never";

                mainfrm.SetTopMost();
            }
            else if (e.Button.Name == "FeedBack")
            {
                mainfrm.CallAbout();
            }
        }

        #endregion

        private void TitleBarFrm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Clicks == 1)
            {
                Point pt = PointToClient(MousePosition);
                Rectangle rc = new Rectangle(systemButton_FeedBack.Location, new Size(240, 22));

                if (!mainfrm.b_isFullScreen && !rc.Contains(pt))
                {
                    DllHelper.ReleaseCapture();
                    DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
                }
            }
            else if(e.Clicks == 2)
            {
                mainfrm.MaxScreen();
            }
        }

        private void TitleBarFrm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            mainfrm.axPlayer1_PreviewKeyDown(sender, e);
        }

        private void TitleBarFrm_MouseEnter(object sender, EventArgs e)
        {
            this.Activate();
        }

        //const int SC_CLOSE = 0xF060;
        //const int SC_MINIMIZE = 0xF020;
        //const int SC_MAXIMIZE = 0xF030;
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_SYSCOMMAND)
        //    {
        //        if (m.WParam.ToInt32() == SC_MINIMIZE)
        //        {
        //            mainfrm.Hide();
        //            this.Hide();

        //            return;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}
    }
}
