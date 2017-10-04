using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using DSkin.Forms;
using DSkin.Controls;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace Aurora_Player
{
    partial class MainForm : Form
    {
        public MainForm()
        {
            this.MouseWheel += new MouseEventHandler(this.MainForm_MouseWheel);
            InitializeComponent();

            timer_SetTask = new Timer();
            timer_SetTask.Interval = 1000;
            timer_SetTask.Tick += new EventHandler(SetTask_Tick);

            timer_ShowHideCursor = new Timer();
            timer_ShowHideCursor.Enabled = true;
            timer_ShowHideCursor.Interval = 500;
            timer_ShowHideCursor.Tick += new EventHandler(timer_ShowHideCursor_Tick);
        }

        #region Aurora Var
        public IntPtr Handle_Aurora;//定义变量,句柄类型

        public SQLiteConnection SQLiteConn;

        public bool b_OpenWithArgs = false;
        public bool b_Close = false;
        public string str_File_OpenWithArgs = "";   //在资源管理器中通过右键选择程序打开时使用

        public TitleBarFrm TitleBarPanel;
        public ControlFrm ControlPanel;
        public TipFrm TipPanel;
        public PlayListFrm PlayListPanel;
        public TimeLineFrm TimeLinePanel;

        private Ad ad;
        private VR vr;
        private TV tv;
        private DLNA dlna;
        private AboutMe aboutme;
        private ScreenShot screenshot;
        private Settings settings;
        private QuickSetting quicksetting;

        public string str_TopMost = "";
        public string str_NowPlaying = "";

        private bool b_IsReadytoPlay = false;
        public bool b_IsPlaying = false;

        public bool b_PlayTV = false;   //标识播放本地视频还是网络源

        public string str_BackGroundImage = "";
        public bool b_UnifyDiffVolumn = true;
        public bool b_PauseWhileMinimize = true;
        public bool b_EnhanceImageQuality = true;
        public bool b_HardwareAcceleration = false;
        public bool b_ShowScreenShotWindow = true;
        public bool b_IncludeSubDir = false;
        public bool b_AutoHideTitleAndControlPanel = false;

        public string str_ScreenShotPath = "";
        public string str_ScreenShotType = "jpg";
        public string str_SetTimeShutDown = "8.19.23.59";
        public int n_FastForward = 5;
        public int n_FastBack = 5;
        public int n_SoundBalance = 50;
        public int n_HumanVolumn = 20;
        public int n_Brightness = 50;
        public int n_Contrast = 50;
        public int n_Saturation = 50;
        public int n_Hue = 50;
        public int n_Volumn = 66;

        public bool b_isFullScreen = false;  //是否全屏
        Rectangle Nor = new Rectangle(0, 0, 0, 0);
        bool isMute = false;        //是否静音
        Form maxForm = null;

        public int n_ShowAd = 0;    //30s后弹广告
        public bool b_ShowAd = false;
        public bool b_ShowAdOnceMore = false;

        public Bitmap BackImage;
        public Bitmap BackImageCurrent;
        public int n_BackImageTransparency = 255;
        public int n_BackColorTransparency = 100;
        public int n_MainFrmOpacity = 100;
        public bool b_ImageFuzzy = false;
        public bool b_EnableDWM = true;
        public bool b_ControlFrmTransparent = false;
        public bool b_AutoMatchLocalSubtitle = true;
        public bool b_AutoMatchNetSubtitle = true;

        public Color FocusColor;        //聚焦色
        public Color ItemHoverColor;    //右键菜单悬浮颜色

        Timer timer_ShowHideCursor = null;      //隐藏显示鼠标
        int n_CursorCount = 0;                  //鼠标状态计数器

        //计划任务
        public Timer timer_SetTask = null;
        public Int64 n_SetTaskTimeLeft = 30;      //单位：s
        public int n_WhatistodoNext = -1;

        public int n_RotateAngle = 0;
        private int n_PlaySpeed = 100;
        private int n_PositionA, n_PositionB;

        private double d_OriginalVideoScale = 1.0;//自然纵横比
        private int n_OriginalWidth = 16;
        private int n_OriginalHeight = 9;
        private string str_OriginalVideoScale = "16;9";
        private double d_CustomVideoScale = 1.0;//自定义纵横比
        private int n_CustomWidth = 16;
        private int n_CustomHeight = 9;
        public string str_CustomVideoScale = "16;9";

        public int n_FontSize = 16;
        public string str_Font = "宋体";
        public int n_SubtitleDelay = 0; //ms
        public int n_AudioDelay = 0;
        public Color SubtitleColor = Color.Yellow;

        public int n_VRMode = 0;
        private bool b_VRDrag = false;
        private int n_VRDragX = 0;
        private int n_VRDragY = 0;
        private double d_VRBaseH = 0.0;
        private double d_VRBaseV = 0.0;
        private double d_VRBaseD = 0.0;

        private Image Image_CheckItem = Properties.Resources.Ckeck_5_22;

        string str_Video_filter = "*.asf;*.avi;*.wm;*.wmp;*.wmv;" +
            "*.ram;*.rmvb;*.rm;*.rp;*.rpm;*.rt;*.smil;*.scm;" +
            "*.dat;*.m1v;*.m2v;*.m2p;*.m2ts;*.mp2v;*.mpe;*.mpeg;*.mpeg1;*.mpeg2;*.mpg;*.mpv2;*.pss;*.pva;*.tp;*.tpr;*.ts;" +
            "*.m4b;*.m4r;*.m4p;*.m4v;*.mp4;*.mpeg4;" +
            "*.3g2;*.3gp;*.3gp2;*.3gpp;" +
            "*.mov;*.qt;" +
            "*.flv;*.f4v;*.swf;*.hlv;" +
            "*.vob;*.ifo;" +
            "*.amv;*.csf;*.divx;*.evo;*.mkv;*.mod;*.pmp;*.vp6;*.bik;*.mts;*.xvx;*.xv;*.xlmv;*.ogm;*.ogv;*.ogx;" +
            "*.dvd;";
        public string str_Audio_filter = "*.aac;*.ac3;*.acc;*.aiff;*.amr;*.ape;*.au;*.cda;*.dts;*.flac;*.m1a;*.m2a;*.m4a;*.mka;*.mp2;*.mp3;*.mpa;*.mpc;*.ra;*.tta;*.wav;*.wma;*.wv;*.mid;*.midi;*.ogg;*.oga;";
        string str_Image_filter = "*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp;*.gif;*.tiff;*.tif;";
        public string str_Subtitle_filter = "*.srt;*.ass;*.ssa;*.smi;*.idx;*.sub;*.sup;*.psb;*.usf;*.ssf;";

        //ini绿色环保
        IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");

        // ---播放器位置
        int ptop = 0;
        int pleft = 0;
        int pwidth = 0;
        int pheight = 0;

        //ShowDialog在关闭时会引起主窗体闪烁。因此在显示子窗体的时候，用一个透明的控件覆盖整个窗体。
        DSkinPictureBox picture_OverLay = new DSkinPictureBox();
        #endregion

        #region 读写ini配置
        private void ReadSettings()
        {
            SetMainFrmLocationAndSize();
            str_TopMost = ini.ReadValue("Settings", "TopMost");
            //toolStripMenuItem_dEnhanceImage.Checked = b_EnhanceImageQuality = Convert.ToBoolean(ini.ReadValue("Settings", "EnhanceImageQuality"));
            b_EnhanceImageQuality = Convert.ToBoolean(ini.ReadValue("Settings", "EnhanceImageQuality"));
            CheckEnhanceImageQuality();
            b_HardwareAcceleration = Convert.ToBoolean(ini.ReadValue("Settings", "HardwareAcceleration"));
            CheckHardwareAcceleration();
            str_BackGroundImage = ini.ReadValue("Settings", "BackGroundImage");
            n_Volumn = Convert.ToInt32(ini.ReadValue("Settings", "Volumn"));
            axPlayer1.SetVolume(n_Volumn);
            b_UnifyDiffVolumn = Convert.ToBoolean(ini.ReadValue("Settings", "UnifyDiffVolumn"));
            b_PauseWhileMinimize = Convert.ToBoolean(ini.ReadValue("Settings", "PauseWhileMinimize"));
            b_ShowScreenShotWindow = Convert.ToBoolean(ini.ReadValue("Settings", "ShowScreenShotWindow"));
            str_ScreenShotPath = ini.ReadValue("Settings", "ScreenShotPath");
            str_SetTimeShutDown = ini.ReadValue("Settings", "SetTimeShutDown");
            n_FastForward = Convert.ToInt32(ini.ReadValue("Settings", "FastForward"));
            n_FastBack = Convert.ToInt32(ini.ReadValue("Settings", "FastBack"));
            b_PlayTV = Convert.ToBoolean(ini.ReadValue("Settings", "PlayTV"));
            b_EnableDWM = Convert.ToBoolean(ini.ReadValue("Settings", "EnableDWM"));
            b_ImageFuzzy = Convert.ToBoolean(ini.ReadValue("Settings", "ImageFuzzy"));
            n_BackColorTransparency = Convert.ToInt32(ini.ReadValue("Settings", "BackColorTransparency"));
            n_BackImageTransparency = Convert.ToInt32(ini.ReadValue("Settings", "BackImageTransparency"));
            n_MainFrmOpacity = Convert.ToInt32(ini.ReadValue("Settings", "MainFrmOpacity"));
            b_ShowAdOnceMore = Convert.ToBoolean(ini.ReadValue("Settings", "ShowAdOnceMore"));
            b_IncludeSubDir = Convert.ToBoolean(ini.ReadValue("Settings", "IncludeSubDir"));
            b_ControlFrmTransparent = Convert.ToBoolean(ini.ReadValue("Settings", "ControlFrmTransparent"));
            b_AutoMatchLocalSubtitle = Convert.ToBoolean(ini.ReadValue("Settings", "AutoMatchLocalSubtitle"));
            b_AutoMatchNetSubtitle = Convert.ToBoolean(ini.ReadValue("Settings", "AutoMatchNetSubtitle"));
            b_AutoHideTitleAndControlPanel = Convert.ToBoolean(ini.ReadValue("Settings", "AutoHideTitleAndControlPanel"));
            FocusColor = ColorHelper.InttoRGB(Convert.ToInt32(ini.ReadValue("Settings", "FocusColor"))); //ColorTranslator.FromHtml(ini.ReadValue("Settings", "FocusColor"));// Color.FromArgb();
            ItemHoverColor = ColorHelper.InttoRGB(Convert.ToInt32(ini.ReadValue("Settings", "ItemHoverColor")));
        }

        private void SaveSettings()
        {
            if (!b_isFullScreen && this.WindowState != FormWindowState.Minimized)
            {
                ini.WriteValue("Settings", "LocationX", this.Location.X.ToString());
                ini.WriteValue("Settings", "LocationY", this.Location.Y.ToString());
                ini.WriteValue("Settings", "Width", this.Width.ToString());
                ini.WriteValue("Settings", "Height", this.Height.ToString());
            }
            else
            {
                int Hwnd = 0;
                Hwnd = DllHelper.FindWindow("Shell_TrayWnd", null);
                if (Hwnd == 0) return;
                //ShowWindow(Hwnd, SW_SHOW);
            }

            ini.WriteValue("Settings", "Volumn", axPlayer1.GetVolume().ToString());
            ini.WriteValue("Settings", "EnhanceImageQuality", b_EnhanceImageQuality.ToString());
            ini.WriteValue("Settings", "HardwareAcceleration", b_HardwareAcceleration.ToString());
            ini.WriteValue("Settings", "PauseWhileMinimize", b_PauseWhileMinimize.ToString());
            ini.WriteValue("Settings", "UnifyDiffVolumn", b_UnifyDiffVolumn.ToString());
            ini.WriteValue("Settings", "ShowScreenShotWindow", b_ShowScreenShotWindow.ToString());
            ini.WriteValue("Settings", "SetTimeShutDown", str_SetTimeShutDown);
            ini.WriteValue("Settings", "PlayTV", b_PlayTV.ToString());
            ini.WriteValue("Settings", "EnableDWM", b_EnableDWM.ToString());
            ini.WriteValue("Settings", "ImageFuzzy", b_ImageFuzzy.ToString());
            ini.WriteValue("Settings", "BackColorTransparency", n_BackColorTransparency.ToString());
            ini.WriteValue("Settings", "BackImageTransparency", n_BackImageTransparency.ToString());
            ini.WriteValue("Settings", "MainFrmOpacity", n_MainFrmOpacity.ToString());
            ini.WriteValue("Settings", "IncludeSubDir", b_IncludeSubDir.ToString());
            ini.WriteValue("Settings", "ControlFrmTransparent", b_ControlFrmTransparent.ToString());
            ini.WriteValue("Settings", "AutoMatchLocalSubtitle", b_AutoMatchLocalSubtitle.ToString());
            ini.WriteValue("Settings", "AutoMatchNetSubtitle", b_AutoMatchNetSubtitle.ToString());
            ini.WriteValue("Settings", "AutoHideTitleAndControlPanel", b_AutoHideTitleAndControlPanel.ToString());
            ini.WriteValue("Settings", "TopMost", str_TopMost);
            ini.WriteValue("Settings", "FocusColor", ColorHelper.RGBtoInt(FocusColor).ToString());
            ini.WriteValue("Settings", "ItemHoverColor", ColorHelper.RGBtoInt(ItemHoverColor).ToString());
            //SaveBackGroundImage();
        }
        #endregion

        private void SaveBackGroundImage()
        {
            try
            {
                Bitmap newBitmap = ImageHelper.KiResizeImage(BackImage, 1600, 900);
                newBitmap.Save(Application.StartupPath + "\\BackGroundImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch { return; }
        }

        private void SetMainFrmLocationAndSize()
        {
            if (ini.ReadValue("Settings", "LocationX") != "" && ini.ReadValue("Settings", "LocationY") != "")
            {
                this.Location = new Point(Convert.ToInt32(ini.ReadValue("Settings", "LocationX")), Convert.ToInt32(ini.ReadValue("Settings", "LocationY")));
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            if (ini.ReadValue("Settings", "Width") != "" && ini.ReadValue("Settings", "Height") != "")
            {
                this.Width = Convert.ToInt32(ini.ReadValue("Settings", "Width"));
                this.Height = Convert.ToInt32(ini.ReadValue("Settings", "Height"));
            }
            else
            {
                this.Width = 600;
                this.Height = 450;
            }
        }

        public void SetPlayerBackground()
        {
            Bitmap image;
            if (File.Exists(str_BackGroundImage))
            {
                image = new Bitmap(str_BackGroundImage);
                axPlayer1.SetCustomLogo((int)image.GetHbitmap());
            }
            else
            {
                //axPlayer1.SetCustomLogo(-1);
                image = new Bitmap(Application.StartupPath + "\\BackGroundImage.jpg");
                axPlayer1.SetCustomLogo((int)image.GetHbitmap());
            }
            BackImageCurrent = BackImage = image;
        }

        private void SetPlayerLogo()
        {
            //axPlayer1.SetConfig(602, "1");
            //axPlayer1.SetConfig(617, Application.StartupPath + "\\logo.png");
            //string str_Picture_Width = axPlayer1.GetConfig(604);
            //string str_Picture_Height = axPlayer1.GetConfig(605);
            //int n_Left = axPlayer1.Location.X + axPlayer1.Width / 2 - Convert.ToInt32(str_Picture_Width) / 2;
            //int n_Top = axPlayer1.Location.Y+ axPlayer1.Height/ 2 - Convert.ToInt32(str_Picture_Height) / 2;
            //axPlayer1.SetConfig(606, n_Left.ToString());
            //axPlayer1.SetConfig(607, n_Top.ToString());
        }

        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadSettings();
            //SetTopMost();

            axPlayer1.SetConfig(105, "0");//设置 Seek 模式，1-Keyframe(Seek较快但不精确), 0-normal(Seek较慢但精确), 默认1
            axPlayer1.SetConfig(120, "1");//播放完成不自动 Close
            axPlayer1.SetConfig(2401, "1");//激活VR

            this.BackColor = FocusColor;
            //Handle_Aurora = this.Handle;

            //axPlayer1.Parent = this;
            this.Opacity = n_MainFrmOpacity / 100.0;

            //dSkinContextMenuStrip1.ItemHover = ItemHoverColor;
            contextMenuStrip1.Renderer = new AuroraMenuRender();

            SetPlayerLogo();
            SetPlayerBackground();
            ShowAd();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitAuroraPanels();
            SQLiteConn = SQLiteHelper.CreateSQLiteConnection(Application.StartupPath + "\\Aurora Player.db");
            InitThumbnailToolbarButton();
            b_IsReadytoPlay = true;
            
            if (b_OpenWithArgs)
            {
                OpenFile(str_File_OpenWithArgs, -1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();

            if (!b_Close)
            {
                QuitApp();
            }
        }

        //窗体靠近屏幕边缘小于16像素，自动吸附
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            if (this.Left == 0 || this.Top == 0 || Screen.PrimaryScreen.WorkingArea.Width - this.Left - this.Width == 0 || Screen.PrimaryScreen.WorkingArea.Height - this.Top - this.Height == 0)
                return;

            if (Math.Abs(this.Left) < 16)
            {
                this.Left = 0;
            }
            if (this.Top < 16)
            {
                this.Top = 0;
            }
            if (Math.Abs(Screen.PrimaryScreen.WorkingArea.Width - this.Left - this.Width) < 16)
            {
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            }
            if (Math.Abs(Screen.PrimaryScreen.WorkingArea.Height - this.Top - this.Height) < 16)
            {
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            }

            if (TitleBarPanel != null)
                LocateResizeTitleBarPanel();
            if (ControlPanel != null)
                LocateResizeControlPanel();
            if (TipPanel != null)
                LocateResizeTipPanel();
            if (PlayListPanel != null)
                LocateResizePlayListPanel();
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            axPlayer1_PreviewKeyDown(sender, e);
            //switch (e.KeyCode)
            //{
            //    case Keys.Left:
            //        {
            //            int nPosition = axPlayer1.GetPosition();
            //            if (nPosition - n_FastBack * 1000 > 0)
            //                axPlayer1.SetPosition(nPosition - n_FastBack * 1000);
            //            else
            //                axPlayer1.SetPosition(0);
            //        }
            //        break;
            //    case Keys.Right:
            //        {
            //            int nPosition = axPlayer1.GetPosition();
            //            if (nPosition + n_FastForward * 1000 < axPlayer1.GetDuration())
            //                axPlayer1.SetPosition(nPosition + n_FastForward * 1000);
            //            else
            //                axPlayer1.Close();
            //        }
            //        break;
            //    case Keys.VolumeMute:
            //        Mute();
            //        break;
            //    case Keys.XButton1:
            //        PlayNext();
            //        break;
            //    case Keys.XButton2:
            //        PlayPrevious();
            //        break;
            //    default:
            //        break;
            //}
        }

        //窗体最小化时暂停播放
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //Resize的时候不能GetState SetState
            if (TitleBarPanel != null)
                LocateResizeTitleBarPanel();
            if (ControlPanel != null)
                LocateResizeControlPanel();
            if (TipPanel != null)
                LocateResizeTipPanel();
            if (PlayListPanel != null)
                LocateResizePlayListPanel();

            if (b_IsReadytoPlay)
            {
                SetPlayerLogo();

                if (axPlayer1.GetState() == (Int32)PublicClass.PLAY_STATE.PS_READY)
                    return;
                //axPlayer1.SetConfig(207, "1");//去黑边

                if (this.WindowState == FormWindowState.Minimized && b_PauseWhileMinimize && axPlayer1.GetVideoWidth() != 0)
                {
                    axPlayer1.Pause();

                    Bitmap bmp = (Properties.Resources.Play24);
                    Icon ico = Icon.FromHandle(bmp.GetHicon());
                    buttonPlayPause.Icon = ico;
                    buttonPlayPause.Tooltip = "播放";
                }
                else if (b_PauseWhileMinimize && (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized))
                {
                    axPlayer1.Play();

                    Bitmap bmp = (Properties.Resources.Pause24);
                    Icon ico = Icon.FromHandle(bmp.GetHicon());
                    buttonPlayPause.Icon = ico;
                    buttonPlayPause.Tooltip = "暂停";
                }

                if (this.WindowState == FormWindowState.Minimized)
                    TitleBarPanel.Visible = false;
                else if (this.WindowState == FormWindowState.Normal)
                    TitleBarPanel.Visible = true;
            }
        }

        //滚动滑轮，控制音量
        public void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            axPlayer1.SetConfig(12, "0");
            isMute = false;
            int n_Volumn = axPlayer1.GetVolume();
            int n_Step = 5;
            if (n_Volumn < 10)
                n_Step = 1;
            else if (n_Volumn >= 10 && n_Volumn < 20)
                n_Step = 2;
            else if (n_Volumn > 20 && n_Volumn < 100)
                n_Step = 5;
            else if (n_Volumn >= 100 && n_Volumn < 500)
                n_Step = 10;
            else if (n_Volumn >= 500 && n_Volumn <= 1000)
                n_Step = 50;
            if (e.Delta > 0)
                axPlayer1.SetVolume(n_Volumn + n_Step);
            else
            {
                if (n_Volumn - n_Step < 0)
                    axPlayer1.SetVolume(0);
                else
                    axPlayer1.SetVolume(n_Volumn - n_Step);
            }

            if (axPlayer1.GetVolume() <= 100)
                ControlPanel.dSkinTrackBar_Volumn.Value = axPlayer1.GetVolume();
            ShowTips("音量：" + axPlayer1.GetVolume().ToString() + "%");
            toolStripMenuItem_Mute.Text = "静音";
            axPlayer1.Focus();
            //Console.WriteLine("音量：" + axPlayer1.GetVolume().ToString() + "%");
        }
        #endregion

        #region 窗体border是none，改变大小
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
            }
        }
        #endregion

        //无边框窗体,实现点击任务栏图标正常最小化或还原窗体
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义 
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作 
                return cp;
            }
        }

        #region AxPlayer事件
        private void axPlayer1_OnMessage(object sender, AxAPlayer3Lib._IPlayerEvents_OnMessageEvent e)
        {
            if (e.nMessage == PublicClass.WM_MOUSEMOVE)
            {
                //鼠标侧键
                if (e.wParam == PublicClass.MK_XBUTTON1)
                    PlayPrevious();
                else if (e.wParam == PublicClass.MK_XBUTTON2)
                    PlayNext();
            }

            switch (e.nMessage)
            {
                case PublicClass.WM_LBUTTONDBLCLK://双击全屏事件
                case PublicClass.WM_MBUTTONDOWN:
                    MaxScreen();
                    break;
                case PublicClass.WM_LBUTTONDOWN:
                    {
                        //if (vr != null && vr.Visible == true)
                        //{
                        //    vr.Visible = false;
                        //}
                        if (n_VRMode == 0)    //未激活VR模式
                        {
                            //ReleaseCapture();
                            //SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);

                            //System.Threading.Thread.Sleep(300); //300毫秒后执行interval时钟事件
                            if (PlayListPanel.Visible == true)
                            {
                                PlayListPanel.Visible = false;
                                break;
                            }

                            if (!b_isFullScreen)
                            {
                                DllHelper.ReleaseCapture();
                                DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
                            }
                            else
                            {
                                //if (axPlayer1.GetState() == Convert.ToInt32(PublicClass.PLAY_STATE.PS_PLAY))
                                //    axPlayer1.Pause();
                                //else
                                //    axPlayer1.Play();
                            }
                        }
                        else    //已激活VR模式
                        {
                            if (PlayListPanel.Visible == true)
                            {
                                PlayListPanel.Visible = false;
                                break;
                            }
                            if (!b_VRDrag)
                            {
                                n_VRDragX = MousePosition.X;
                                n_VRDragY = MousePosition.Y;

                                string str_VR_Position_Now = axPlayer1.GetConfig(2403);
                                string[] strArr = str_VR_Position_Now.Split(';');
                                d_VRBaseH = Convert.ToDouble(strArr[0]);
                                d_VRBaseV = Convert.ToDouble(strArr[1]);
                                d_VRBaseD = Convert.ToDouble(strArr[2]);
                                b_VRDrag = true;
                            }
                        }
                    }
                    break;
                case PublicClass.WM_LBUTTONUP:
                    {
                        if (b_VRDrag)
                        {
                            b_VRDrag = false;
                        }
                    }
                    break;
                case PublicClass.WM_RBUTTONDOWN:
                    contextMenuStrip1.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    //dSkinContextMenuStrip1.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    break;
                case PublicClass.WM_MOUSEWHEEL:
                    //已在MainForm_MouseWheel中实现
                    break;
                case PublicClass.WM_MOUSEMOVE:
                    {
                        //if (axPlayer1.GetVideoHeight() != 0 || axPlayer1.GetConfig(4) == "")//视频
                        {
                            //鼠标移动到客户区右侧，显示/隐藏播放列表
                            //Rectangle rectangleRight = new Rectangle(new Point(this.ClientRectangle.Width - 25, 25), new Size(25, this.ClientRectangle.Height - 50));
                            //if (rectangleRight.Contains(PointToClient(MousePosition)))
                            //{
                            //    panel_PlayList.Visible = true;
                            //}
                            //else
                            //{
                            //    panel_PlayList.Visible = false;
                            //    axPlayer1.Focus();
                            //}

                            //鼠标放在顶部，显示工具栏
                            Rectangle rectangleTop = new Rectangle(new Point(0, 0), new Size(this.ClientRectangle.Width, 25));
                            if (rectangleTop.Contains(PointToClient(MousePosition)) && n_CursorCount >= 0)
                            {
                                if (TitleBarPanel.Visible == false)
                                {
                                    TitleBarPanel.Visible = false;
                                    LocateResizeTitleBarPanel();
                                    TitleBarPanel.Show();
                                    TitleBarPanel.Activate();
                                }
                            }
                            else if (b_AutoHideTitleAndControlPanel)
                            {
                                TitleBarPanel.Hide();
                                axPlayer1.Focus();
                            }

                            //鼠标放在底部，显示控制栏
                            Rectangle rectangleBottom = new Rectangle(new Point(0, this.Height - ControlPanel.Height), ControlPanel.Size);
                            //Console.WriteLine(rectangleBottom.ToString());
                            //Console.WriteLine(PointToClient(MousePosition).ToString());
                            if (rectangleBottom.Contains(PointToClient(MousePosition)) && n_CursorCount >= 0)
                            {
                                if (!ControlPanel.Visible)
                                {
                                    ControlPanel.Show();
                                    ControlPanel.Activate();
                                }
                            }
                            else if (b_AutoHideTitleAndControlPanel)
                            {
                                ControlPanel.Hide();
                                ControlPanel.dSkinTrackBar_Volumn.Visible = false;
                                axPlayer1.Focus();
                            }
                        }

                        if (n_VRMode != 0)    //已激活VR模式
                        {
                            int X = MousePosition.X;
                            int Y = MousePosition.Y;
                            if (b_VRDrag)
                            {
                                int n_AddX = MousePosition.X - n_VRDragX;
                                int n_AddY = MousePosition.Y - n_VRDragY;

                                double h = 0.0, v = 0.0, d = 0.0;
                                h = d_VRBaseH + n_AddX / 200.0;
                                v = d_VRBaseV + n_AddY / 500.0;
                                d = d_VRBaseD;

                                string str_Position_Changed = h.ToString() + ";" + v.ToString() + ";" + d_VRBaseD.ToString();
                                axPlayer1.SetConfig(2403, str_Position_Changed);
                            }
                        }
                    }
                    break;
                case PublicClass.WM_MOUSEHOVER:

                    break;
                case PublicClass.WM_MOUSELEAVE:
                    //panel_PlayList.Visible = false;
                    break;
                default:
                    break;

            }

            //axPlayer1.Focus();
        }

        //键盘快捷键响应
        public void axPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:
                    if (e.Control)
                        OpenFile();
                    break;
                case Keys.S:
                    if (e.Control)
                        CallSettings();
                    break;
                case Keys.U:
                    if (e.Control)
                        CallTV();
                    break;
                case Keys.F7:
                case Keys.D1:
                    //ControlBox = !ControlBox;
                    //if (ControlBox)
                    //    toolStripMenuItem_Mini.Image = null;
                    //else
                    //    toolStripMenuItem_Mini.Checked = true;
                    //if (this.FormBorderStyle == FormBorderStyle.Sizable)
                    //    this.FormBorderStyle = FormBorderStyle.None;
                    //else
                    //    this.FormBorderStyle = FormBorderStyle.Sizable;
                    break;
                case Keys.Enter:
                case Keys.F11:
                    MaxScreen();
                    break;
                case Keys.F5:
                    axPlayer1.Close();
                    axPlayer1.Open(axPlayer1.GetConfig(4));
                    //AfterOpenFile();
                    ResetControlPanel();
                    break;
                case Keys.Space:
                case Keys.MediaPlayPause:
                    if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                    {
                        OpenFile();
                        break;
                    }
                    if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                    {
                        axPlayer1.Pause();

                        toolStripMenuItem_PlayPause.Text = "播放";
                        Bitmap bmp = (Properties.Resources.Play24);
                        Icon ico = Icon.FromHandle(bmp.GetHicon());
                        buttonPlayPause.Icon = ico;
                        buttonPlayPause.Tooltip = "播放";
                    }
                    else
                    {
                        axPlayer1.Play();

                        toolStripMenuItem_PlayPause.Text = "暂停";
                        Bitmap bmp = (Properties.Resources.Pause24);
                        Icon ico = Icon.FromHandle(bmp.GetHicon());
                        buttonPlayPause.Icon = ico;
                        buttonPlayPause.Tooltip = "暂停";
                    }
                    break;
                case Keys.F8:
                    CallScreenShot();
                    break;
                case Keys.F9:
                    b_EnhanceImageQuality = !b_EnhanceImageQuality;
                    EnhanceImageQuality();
                    break;
                case Keys.F10:
                    str_TopMost = "TopMostWhilePlay";
                    SetTopMost();
                    break;
                case Keys.Escape:
                    {
                        if (b_isFullScreen)
                            MaxScreen();
                    }
                    break;
                case Keys.ShiftKey:
                    EnhanceContrast();
                    break;
                case Keys.Up:
                case Keys.VolumeUp:
                    {
                        VolumnUp();
                    }
                    break;
                case Keys.Down:
                case Keys.VolumeDown:
                    {
                        VolumnDown();
                    }
                    break;
                case Keys.Left:
                    {
                        if (!b_PlayTV)
                        {
                            int nPosition = axPlayer1.GetPosition();
                            if (nPosition - n_FastBack * 1000 > 0)
                                axPlayer1.SetPosition(nPosition - n_FastBack * 1000);
                            else
                                axPlayer1.SetPosition(0);
                        }
                    }
                    break;
                case Keys.Right:
                    {
                        if (!b_PlayTV)
                        {
                            int nPosition = axPlayer1.GetPosition();
                            if (nPosition + n_FastForward * 1000 < axPlayer1.GetDuration())
                                axPlayer1.SetPosition(nPosition + n_FastForward * 1000);
                            else
                                axPlayer1.Close();
                        }
                    }
                    break;
                case Keys.VolumeMute:
                    Mute();
                    break;
                case Keys.MediaNextTrack:
                case Keys.XButton1:
                    PlayNext();
                    break;
                case Keys.MediaPreviousTrack:
                case Keys.XButton2:
                    PlayPrevious();
                    break;
                case Keys.NumPad1:
                    VideoZoomOut();
                    break;
                case Keys.NumPad2:
                    VideoZoomShorter();
                    break;
                case Keys.NumPad3:

                    break;
                case Keys.NumPad4:
                    VideoZoomThinner();
                    break;
                case Keys.NumPad5:
                    VideoZoomReset();
                    break;
                case Keys.NumPad6:
                    VideoZoomFatter();
                    break;
                case Keys.NumPad7:

                    break;
                case Keys.NumPad8:
                    VideoZoomHigher();
                    break;
                case Keys.NumPad9:
                    VideoZoomIn();
                    break;
                default:
                    break;
            }
        }

        //控制播放完毕后的状态
        private void axPlayer1_OnStateChanged(object sender, AxAPlayer3Lib._IPlayerEvents_OnStateChangedEvent e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
            {
                axPlayer1.SetConfig(602, "0");
            }
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY && b_PlayTV)
            {
                ShowTips("当前源已经失效，请尝试切换源");
            }
            else if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
            {
                b_IsPlaying = false;
                axPlayer1.SetConfig(602, "1");
                toolStripMenuItem_dPlayPause.Text = "播放";

                Bitmap bmp = (Properties.Resources.Play24);
                Icon ico = Icon.FromHandle(bmp.GetHicon());
                buttonPlayPause.Icon = ico;
                buttonPlayPause.Tooltip = "播放";

                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Play24;
                ControlPanel.dSkinTrackBar_Progress.Value = 0;
                ControlPanel.dSkinLabel_CurrentTime.Text = "0:00:00";
                ControlPanel.dSkinLabel_TotalTime.Text = "0:00:00";
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }

            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PAUSED && str_TopMost == "TopMostWhilePlay")
            {
                this.TopMost = false;
            }
            else if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY && str_TopMost == "TopMostWhilePlay")
            {
                this.TopMost = true;
            }

        }

        private void axPlayer1_OnBuffer(object sender, AxAPlayer3Lib._IPlayerEvents_OnBufferEvent e)
        {
            if (!b_Close)
            {
                if (axPlayer1.GetBufferProgress() != -1)
                    ShowTips("正在缓冲" + axPlayer1.GetBufferProgress().ToString() + "%");
                else
                    ShowTips("正在播放" + str_NowPlaying);
                Console.WriteLine("正在缓冲" + axPlayer1.GetBufferProgress().ToString() + "%");
            }
        }

        private void axPlayer1_OnOpenSucceeded(object sender, EventArgs e)
        {
            AfterOpenFile();
        }

        private void axPlayer1_OnEvent(object sender, AxAPlayer3Lib._IPlayerEvents_OnEventEvent e)
        {
            //播放完成事件，改事件在播放影片完成时发送，参数：无。
            if (e.nEventCode == 10010)
            {
                if (n_WhatistodoNext != (int)PublicClass.WhtaistodoNext.PS_DoNoThing)
                {
                    //SendWhatistodoNext(n_WhatistodoNext);
                    if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_ExitApp)
                    {
                        QuitApp();
                    }
                    else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_LockPC)
                    {
                        axPlayer1.Pause();
                        DllHelper.LockWorkStation();
                    }
                    else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_LogOff)
                    {
                        CommandHelper.Excute("shutdown /l");
                    }
                    else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_Shutdown)
                    {
                        CommandHelper.Excute("shutdown /s /t 0");
                    }
                    else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_Reboot)
                    {
                        CommandHelper.Excute("shutdown /r /t 0");
                    }
                    else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_TurnOffMonitor)
                    {
                        axPlayer1.Pause();
                        DllHelper.SendMessage(0xFFFF, 0x112, 0xF170, 2);
                    }
                }
                else
                    PlayNext();
            }
        }

        private void axPlayer1_OnDownloadCodec(object sender, AxAPlayer3Lib._IPlayerEvents_OnDownloadCodecEvent e)
        {
            //http://aplayer.open.xunlei.com/bbs/read.php?tid=24449&fpage=8
            axPlayer1.SetConfig(2204, "1");
        }

        private void axPlayer1_MouseCaptureChanged(object sender, EventArgs e)
        {
            ShowTips("...");
        }
        #endregion

        #region 全屏显示的几个函数
        public void MaxScreen()
        {
            if (b_isFullScreen)
            {
                //this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                //axPlayer1.BringToFront();
                //axPlayer1.Location = Nor.Location;
                //axPlayer1.Size = Nor.Size;
                axPlayer1.Location = new Point(1, 1);
                axPlayer1.Size = new Size(this.Width - 2, this.Height - 2);
                //panel_TopBar.Location = new Point(1, 1);
                //panel_TopBar.Size = new Size(this.Width - 2, panel_TopBar.Height);
                toolStripMenuItem_FullScreen.Text = "全屏模式 (Enter/F11)";
                TitleBarPanel.systemButton_FullScreen.Image = global::Aurora_Player.Properties.Resources.FullScreenF;
                TitleBarPanel.systemButton_FullScreen.ToolTip = "全屏模式";
                b_isFullScreen = false;
            }
            else
            {
                Nor = new Rectangle(axPlayer1.Location, axPlayer1.Size);
                axPlayer1.Parent = this;
                //this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //axPlayer1.BringToFront();
                Screen CurrentSC = Screen.FromControl(this);
                this.Location = CurrentSC.WorkingArea.Location;//= new Point(0, 0);
                axPlayer1.Location = new Point(0, 0);
                axPlayer1.Size = Size;
                //panel_TopBar.Location = new Point(0, 0);
                //panel_TopBar.Size = new Size(this.Width, panel_TopBar.Height);
                TitleBarPanel.Visible = false;
                TitleBarPanel.Show(this);
                if (b_AutoHideTitleAndControlPanel)
                    TitleBarPanel.Hide();
                toolStripMenuItem_FullScreen.Text = "退出全屏 (Esc/Enter/F11)";
                TitleBarPanel.systemButton_FullScreen.Image = global::Aurora_Player.Properties.Resources.FullScreenN;
                TitleBarPanel.systemButton_FullScreen.ToolTip = "退出全屏";
                if (PlayListPanel != null)
                    LocateResizePlayListPanel();
                if (TitleBarPanel != null)
                    LocateResizeTitleBarPanel();
                b_isFullScreen = true;
            }

            axPlayer1.Focus();
        }

        public void MaxScreen1()
        {
            if (b_isFullScreen == false)
            {
                //记录播放器尺寸位置
                ptop = axPlayer1.Top;
                pleft = axPlayer1.Left;
                pwidth = axPlayer1.Width;
                pheight = axPlayer1.Height;
                maxForm = new Form();//实例化新窗口设置屏幕设备大小 并置于播放器父窗口
                maxForm.Width = Screen.PrimaryScreen.Bounds.Width;
                maxForm.Height = Screen.PrimaryScreen.Bounds.Height;
                maxForm.FormBorderStyle = FormBorderStyle.None;
                maxForm.Show();
                b_isFullScreen = true;
                //int hDesktop = Win32.FindWindow("Progman",null);
                //hDesktop = Win32.GetWindow(hDesktop,5);
                DllHelper.SetParent((int)axPlayer1.Handle, (int)maxForm.Handle);
                axPlayer1.Left = 0;
                axPlayer1.Top = 0;
                axPlayer1.Width = Screen.PrimaryScreen.Bounds.Width;
                axPlayer1.Height = Screen.PrimaryScreen.Bounds.Height;

                ShowTips("全屏幕");
                toolStripMenuItem_dFullScreen.Text = "退出全屏";
            }
            else
            {
                b_isFullScreen = false;
                DllHelper.SetParent((int)axPlayer1.Handle, (int)this.Handle);
                axPlayer1.Top = ptop;
                axPlayer1.Left = pleft;
                axPlayer1.Width = pwidth;
                axPlayer1.Height = pheight;
                maxForm.Close();

                ShowTips("退出全屏");
                toolStripMenuItem_dFullScreen.Text = "全屏";
            }
            axPlayer1.Focus();
        }

        public void MaxScreen2()
        {
            b_isFullScreen = !b_isFullScreen;//循环。点一次全屏，再点还原。
            int Hwnd = 0;
            Rectangle rect = new Rectangle();
            //Hwnd = FindWindow("Shell_TrayWnd", null);
            Hwnd = DllHelper.FindWindow("Shell_TrayWnd", String.Empty);
            if (Hwnd == 0) return;
            if (b_isFullScreen)
            {
                //ShowWindow(Hwnd, SW_HIDE);
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                DllHelper.SystemParametersInfo(DllHelper.SPI_GETWORKAREA, 0, ref rect, DllHelper.SPIF_UPDATEINIFILE);//get
                DllHelper.SystemParametersInfo(DllHelper.SPI_SETWORKAREA, 0, ref rectFull, DllHelper.SPIF_UPDATEINIFILE);//set
            }
            else
            {
                //ShowWindow(Hwnd, SW_SHOW);
                DllHelper.SystemParametersInfo(DllHelper.SPI_SETWORKAREA, 0, ref rect, DllHelper.SPIF_UPDATEINIFILE);
            }
            if (b_isFullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;//全屏

                ShowTips("全屏幕");
                toolStripMenuItem_dFullScreen.Text = "退出全屏";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;//还原

                ShowTips("退出全屏");
                toolStripMenuItem_dFullScreen.Text = "全屏";
            }
            axPlayer1.Focus();
        }
        #endregion

        #region 音量调节、画质控制

        public void VolumnUp()
        {
            axPlayer1.SetConfig(12, "0");
            int n_Volumn = axPlayer1.GetVolume();
            int n_Step = 5;
            if (n_Volumn < 10)
                n_Step = 1;
            else if (n_Volumn >= 10 && n_Volumn < 20)
                n_Step = 2;
            else if (n_Volumn > 20 && n_Volumn < 100)
                n_Step = 5;
            else if (n_Volumn >= 100 && n_Volumn < 500)
                n_Step = 10;
            else if (n_Volumn >= 500 && n_Volumn <= 1000)
                n_Step = 50;
            axPlayer1.SetVolume(n_Volumn + n_Step);
            if (axPlayer1.GetVolume() <= 100)
                ControlPanel.dSkinTrackBar_Volumn.Value = axPlayer1.GetVolume();
            ShowTips("音量：" + axPlayer1.GetVolume().ToString() + "%");
            toolStripMenuItem_Mute.Text = "静音";
            axPlayer1.Focus();
        }

        public void VolumnDown()
        {
            axPlayer1.SetConfig(12, "0");
            int n_Volumn = axPlayer1.GetVolume();
            int n_Step = 5;
            if (n_Volumn < 10)
                n_Step = 1;
            else if (n_Volumn >= 10 && n_Volumn < 20)
                n_Step = 2;
            else if (n_Volumn > 20 && n_Volumn < 100)
                n_Step = 5;
            else if (n_Volumn >= 100 && n_Volumn < 500)
                n_Step = 10;
            else if (n_Volumn >= 500 && n_Volumn <= 1000)
                n_Step = 50;
            if (n_Volumn - n_Step < 0)
                axPlayer1.SetVolume(0);
            else
                axPlayer1.SetVolume(n_Volumn - n_Step);
            if (axPlayer1.GetVolume() <= 100)
                ControlPanel.dSkinTrackBar_Volumn.Value = axPlayer1.GetVolume();
            ShowTips("音量：" + axPlayer1.GetVolume().ToString() + "%");
            toolStripMenuItem_Mute.Text = "静音";
            axPlayer1.Focus();
        }

        public void Mute()
        {
            if (isMute)
            {
                isMute = (axPlayer1.SetConfig(12, "0") == 1) ? false : true;
                toolStripMenuItem_Mute.Text = "静音";
                ShowTips("取消静音");
            }
            else
            {
                isMute = (axPlayer1.SetConfig(12, "1") == 1) ? true : false;
                toolStripMenuItem_Mute.Text = "取消静音";
                ShowTips("静音");
            }
            axPlayer1.Focus();
        }

        //硬件加速
        private void HardwareAcceleration()
        {
            //Console.WriteLine(axPlayer1.GetConfig(209));
            if (axPlayer1.GetConfig(209) == "0")
            {
                axPlayer1.SetConfig(209, "1");
                string strNowPlay = axPlayer1.GetConfig(4);
                int nNowPosition = axPlayer1.GetPosition();
                axPlayer1.Close();
                //System.Threading.Thread.Sleep(1000);
                axPlayer1.Open(strNowPlay);
                System.Threading.Thread.Sleep(500);
                axPlayer1.SetPosition(nNowPosition);
                axPlayer1.Play();

                //Console.WriteLine(axPlayer1.GetConfig(211));
                if (axPlayer1.GetConfig(211) == "1")     //开启成功
                {
                    //toolStripMenuItem_dHardwareAcceleration.Checked = true;
                    b_HardwareAcceleration = true;
                    toolStripMenuItem_HardwareAcceleration.Text = "硬件加速(加速中)";
                    ShowTips("已开启硬件加速");
                }
                else if (axPlayer1.GetConfig(211) == "2")
                    ShowTips("开启硬件加速出现未知错误");
                else if (axPlayer1.GetConfig(211) == "3")
                    ShowTips("设备不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "4")
                    ShowTips("格式不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "5")
                    ShowTips("操作系统不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "6")
                    ShowTips("解码器不支持硬件加速");
            }
            else
            {
                axPlayer1.SetConfig(209, "0");
                string strNowPlay = axPlayer1.GetConfig(4);
                int nNowPosition = axPlayer1.GetPosition();
                axPlayer1.Close();
                //System.Threading.Thread.Sleep(1000);

                axPlayer1.Open(strNowPlay);
                System.Threading.Thread.Sleep(1000);
                axPlayer1.SetPosition(nNowPosition);
                axPlayer1.Play();

                //toolStripMenuItem_dHardwareAcceleration.Image = null;
                b_HardwareAcceleration = false;
                toolStripMenuItem_HardwareAcceleration.Text = "硬件加速(F7)";
                ShowTips("已关闭硬件加速");
            }

            CheckHardwareAcceleration();
            EnhanceImageQuality();
            UnifyDiffVolumn();
        }

        //画质增强
        public void EnhanceImageQuality()
        {
            CheckEnhanceImageQuality();
            if (b_EnhanceImageQuality)
            {
                System.Threading.Thread.Sleep(500);     //稍微停顿一下，否则打开文件，不会开启
                axPlayer1.SetConfig(305, "1");
                ShowTips("已开启画质增强，按下Shift键可查看画质对比");
                toolStripMenuItem_EnhanceImage.Image = Image_CheckItem;
                b_EnhanceImageQuality = true;
            }
            else
            {
                axPlayer1.SetConfig(305, "0");
                ShowTips("已关闭画质增强");
                toolStripMenuItem_EnhanceImage.Image = null;
                b_EnhanceImageQuality = false;
            }
        }

        public void UnifyDiffVolumn()
        {
            axPlayer1.SetConfig(406, b_UnifyDiffVolumn == true ? "1" : "0");
        }

        //画质对比
        public void EnhanceContrast()
        {
            if (axPlayer1.GetConfig(306) == "0")
                axPlayer1.SetConfig(306, "1");
            else
                axPlayer1.SetConfig(306, "0");
        }

        public void CheckUnifyDiffVolumnEnhanceImageQuality()
        {
            if (b_EnhanceImageQuality && axPlayer1.GetVideoWidth() != 0)
            {
                EnhanceImageQuality();
            }
            UnifyDiffVolumn();//统一音量
        }

        public void CheckEnhanceImageQuality()
        {
            if (b_EnhanceImageQuality)
                toolStripMenuItem_EnhanceImage.Image = Image_CheckItem;
            else
                toolStripMenuItem_EnhanceImage.Image = null;
        }

        public void CheckHardwareAcceleration()
        {
            if (b_HardwareAcceleration)
                toolStripMenuItem_HardwareAcceleration.Image = Image_CheckItem;
            else
                toolStripMenuItem_HardwareAcceleration.Image = null;
        }

        #endregion

        #region OpenFile
        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有媒体文件(*.所有媒体文件)| " + str_Video_filter + ";" + str_Audio_filter + "|视频文件(*.视频文件)|" + str_Video_filter + "|音频文件(*.音频文件)|" + str_Audio_filter + "|字幕文件(*.字幕文件)|" + str_Subtitle_filter + "|图像文件(*.图像文件)|" + str_Image_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strFileExtension = Path.GetExtension(openFileDialog.FileName.ToString()).ToLower();
                if (!str_Video_filter.Contains(strFileExtension) && !str_Audio_filter.Contains(strFileExtension) && !str_Image_filter.Contains(strFileExtension))
                {
                    OpenUnknownFile(strFileExtension);
                    //ShowTips("不支持的文件格式或者文件已损坏");
                    return false;
                }

                //如果是图片
                if (str_Image_filter.Contains(strFileExtension))
                {
                    //pictureBox_Album.Show();
                    //pictureBox_Album.BringToFront();
                    //pictureBox_Album.Dock = DockStyle.Fill;
                    //pictureBox_Album.ImageLocation = openFileDialog.FileName.ToString();
                    return true;
                }
                else if (str_Subtitle_filter.Contains(strFileExtension))
                {
                    axPlayer1.SetConfig(504, "0");
                    axPlayer1.SetConfig(503, openFileDialog.FileName);
                    ShowTips("成功载入字幕");
                    return true;
                }
                else if (str_Audio_filter.Contains(strFileExtension))
                {

                    //return true;
                }

                b_PlayTV = false;
                if (b_IsPlaying)
                    UpdateCurrentPlayingtoLocalList();

                string[] str_Arr = openFileDialog.FileNames;
                AddtoPlayList(str_Arr);

                ResetControlPanel();
                int nPosition = GetOpenedFilePosition(openFileDialog.FileName);
                axPlayer1.SetConfig(102, nPosition.ToString());
                axPlayer1.Close();
                axPlayer1.Open(openFileDialog.FileName);
                TitleBarPanel.Text = Path.GetFileName(openFileDialog.FileName) + " - Aurora Player ";
                this.Text = Path.GetFileName(openFileDialog.FileName) + " - Aurora Player ";
                str_NowPlaying = Path.GetFileName(openFileDialog.FileName);
                ShowTips("正在播放" + openFileDialog.FileName);

                //System.Threading.Thread.Sleep(100);     //稍微停顿一下，否则打开文件，状态是正在打开
                //axPlayer1.SetConfig(207, "1");//去黑边

                if (axPlayer1.GetConfig(7) != "0" && axPlayer1.GetConfig(7) != "1")//播放结果，0-播放完成, 1-主动关闭，其他-播放失败错误代码。
                {
                    ShowTips("不支持的文件格式或者文件已损坏");
                    return false;
                }

                //视频宽度/高度为0，说明是音频
                if (axPlayer1.GetVideoWidth() == 0 && str_Audio_filter.Contains(Path.GetExtension(openFileDialog.FileName).ToLower()))
                {
                    SetAlbumArt(openFileDialog.FileName);
                }
                return true;
            }
            return false;
        }

        public bool OpenFile(string strFullFileName, int nPosition = 0)
        {
            if (!File.Exists(strFullFileName))
            {
                ShowTips("文件\"" + strFullFileName + "\"不存在");
                return false;
            }

            string strFileExtension = Path.GetExtension(strFullFileName).ToLower();
            if (!str_Video_filter.Contains(strFileExtension) && !str_Audio_filter.Contains(strFileExtension) && !str_Image_filter.Contains(strFileExtension))
            {
                OpenUnknownFile(strFileExtension);
                //ShowTips("不支持的文件格式或者文件已损坏");
                return false;
            }

            //如果是图片
            if (str_Image_filter.Contains(strFileExtension))
            {
                //pictureBox_Album.Show();
                //pictureBox_Album.BringToFront();
                //pictureBox_Album.Dock = DockStyle.Fill;
                //pictureBox_Album.ImageLocation = strFullFileName;
                return true;
            }

            b_PlayTV = false;
            if (b_IsPlaying)
                UpdateCurrentPlayingtoLocalList();

            AddtoPlayList(strFullFileName);

            if (nPosition == -1)
                nPosition = GetOpenedFilePosition(strFullFileName);
            axPlayer1.SetConfig(102, nPosition.ToString());
            axPlayer1.Close();
            axPlayer1.Open(strFullFileName);

            ResetControlPanel();
            TitleBarPanel.Text = Path.GetFileName(strFullFileName) + " - Aurora Player ";
            this.Text = Path.GetFileName(strFullFileName) + " - Aurora Player ";
            str_NowPlaying = Path.GetFileName(strFullFileName);
            ShowTips("正在播放" + strFullFileName);
            System.Threading.Thread.Sleep(100);     //稍微停顿一下，否则打开文件，状态是正在打开
            //axPlayer1.SetConfig(207, "1");//去黑边

            if (axPlayer1.GetConfig(7) != "0" && axPlayer1.GetConfig(7) != "1")//播放结果，0-播放完成, 1-主动关闭，其他-播放失败错误代码。
            {
                ShowTips("不支持的文件格式或者文件已损坏");
                return false;
            }

            if (axPlayer1.GetVideoWidth() == 0 && str_Audio_filter.Contains(Path.GetExtension(strFullFileName).ToLower()))    //视频宽度/高度为0，说明是音频
            {
                SetAlbumArt(strFullFileName);
            }
            return true;
        }

        public void AfterOpenFile()
        {
            System.Threading.Thread.Sleep(100);
            SetTopMost();
            CheckUnifyDiffVolumnEnhanceImageQuality();
            toolStripMenuItem_PlayPause.Text = "暂停";

            if (buttonPlayPause != null)
            {
                Bitmap bmp = (Properties.Resources.Pause24);
                Icon ico = Icon.FromHandle(bmp.GetHicon());
                buttonPlayPause.Icon = ico;
                buttonPlayPause.Tooltip = "暂停";
            }

            b_IsPlaying = true;
            timer_Progress.Enabled = true;
            ResetVRMode();
        }

        //各种不认识的文件，打开后给出提示吧
        private void OpenUnknownFile(string strFileExtension)
        {
            switch (strFileExtension)
            {
                case ".txt":
                    ShowTips("这是一个文本文件，Aurora 建议用记事本或者Notepad++等程序打开");
                    break;
                case ".pdf":
                    ShowTips("这是一个PDF文件，Aurora 建议用Adobe Reader或者Foxit Reader等程序打开");
                    break;
                case ".rar":
                case ".zip":
                case ".7z":
                case ".cab":
                case ".tar":
                case ".gzip":
                case ".gz":
                    ShowTips("这是一个压缩文件，Aurora 建议用WinRAR或者7-Zip等程序打开");
                    break;
                case ".doc":
                case ".docx":
                case ".dot":
                case ".dotx":
                case ".rtf":
                    ShowTips("这是一个Word文档，Aurora 建议用Microsoft OFfice、Libre Office或者金山 WPS等程序打开");
                    break;
                case ".xls":
                case ".xlsx":
                case ".xlt":
                case ".xltx":
                case ".csv":
                    ShowTips("这是一个Excel电子表格，Aurora 建议用Microsoft Office、Libre Office或者金山 WPS等程序打开");
                    break;
                case ".ppt":
                case ".pptx":
                case ".pot":
                case ".potx":
                    ShowTips("这是一个PowerPoint文档，Aurora 建议用Microsoft OFfice或者Libre Office等程序打开");
                    break;
                case ".mdb":
                case ".accdb":
                    ShowTips("这是一个数据库文档，Aurora 建议用Microsoft OFfice或者Libre Office等程序打开");
                    break;
                case ".cs":
                case ".resx":
                case ".vb":
                case ".c":
                case ".cpp":
                case ".h":
                    ShowTips("这是一个程序代码文件，Aurora 建议用Visual Studio、Sublime Text或者QT等程序打开");
                    break;
                case ".java":
                    ShowTips("这是一个程序代码文件，Aurora 建议用Android Studio或者MyEclipse等程序打开");
                    break;
                case ".psd":
                case ".psb":
                case ".eps":
                    ShowTips("这是一个Adobe PhotoShop文件，Aurora 建议用Adobe PhotoShop等程序打开");
                    break;
                case ".ai":
                case ".ait":
                case ".idea":
                    ShowTips("这是一个Adobe Illustrator文件，Aurora 建议用Adobe Illustrator等程序打开");
                    break;
                case ".vmx":
                case ".vmtm":
                case ".vmc":
                    ShowTips("这是一个虚拟机文件，Aurora 建议用VMware Workstation或者Vitural PC等程序打开");
                    break;
                case ".iso":
                case ".isz":
                case ".nrg":
                case ".b5t":
                case ".b6t":
                case ".bwt":
                case ".ccd":
                    ShowTips("这是一个镜像文件，Aurora 建议用DAEMON Tools或者Nero Burn等程序打开");
                    break;
                case ".pcb":
                case ".pcbdoc":
                    ShowTips("这是一个PCB电路板文件，Aurora 建议用Altium Designer等程序打开");
                    break;
                case ".prt":
                case ".stp":
                case ".stet":
                case ".igs":
                    ShowTips("这是一个3D建模文件，Aurora 建议用UG NX、PROE、CAXA或者SolidWorks等程序打开");
                    break;
                default:
                    ShowTips("Aurora 暂时不支持此文件格式或者此文件已损坏");
                    break;
            }
        }
        #endregion

        public void OpenFolder()
        {
            string str_Directory = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                str_Directory = folderBrowserDialog1.DirectoryPath;
            }
            int n_Depth = 0;
            if (b_IncludeSubDir)
                n_Depth = -1;
            else
                n_Depth = 0;

            //str_Temp = "[.](flv|mp4|mkv)$"
            string str_Temp = str_Video_filter.Replace(";", "|");
            str_Temp = str_Temp.Replace("*.", "");
            str_Temp = "[.](" + str_Temp + ")$";
            string[] str_ArrFiles;
            str_ArrFiles = DirectoryHelper.GetFiles(str_Directory, str_Temp, n_Depth, false);
            AddtoPlayList(str_ArrFiles);
        }

        private void AddtoPlayList(string[] str_ArrFullFileName)
        {
            for (int i = 0; i < str_ArrFullFileName.Length; i++)
            {
                bool bExistInList = false;
                string strFullFileName = str_ArrFullFileName[i].ToString();
                bExistInList = IsExistInLocalList(strFullFileName);

                if (!bExistInList)
                {
                    string strFileNameAndExtension = Path.GetFileName(strFullFileName);
                    PlayListPanel.dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, strFullFileName, 0);
                    strFullFileName = strFullFileName.Replace("\'", "\'\'");
                    strFileNameAndExtension = strFileNameAndExtension.Replace("\'", "\'\'");
                    string sql = "insert into LocalList (FileName, FileFullName) values ('" + strFileNameAndExtension + "','" + strFullFileName + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
                    command.ExecuteNonQuery();
                }
            }



            //if (PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount == 0)
            //{
            //    for (int i = 0; i < str_ArrFullFileName.Length; i++)
            //    {
            //        string strFileNameAndExtension = GetFileNameAndExtension(str_ArrFullFileName[i].ToString());
            //        PlayListPanel.dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, str_ArrFullFileName[i].ToString(), 0);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < str_ArrFullFileName.Length; i++)
            //    {
            //        for (int j = 0; j < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; j++)
            //        {
            //            if (str_ArrFullFileName[i].ToString() == PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text)
            //            {
            //                break;
            //            }
            //            else
            //            {
            //                string strFileNameAndExtension = GetFileNameAndExtension(str_ArrFullFileName[i].ToString());
            //                PlayListPanel.dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, str_ArrFullFileName[i].ToString(), 0);
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        public void AddtoPlayList(string strFullFileName)
        {
            bool bExistInList = false;
            bExistInList = IsExistInLocalList(strFullFileName);
            if (!bExistInList)
            {
                string strFileNameAndExtension = Path.GetFileName(strFullFileName);
                PlayListPanel.dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, strFullFileName, 0);
                strFullFileName = strFullFileName.Replace("\'", "\'\'");
                strFileNameAndExtension = strFileNameAndExtension.Replace("\'", "\'\'");
                string sql = "insert into LocalList (FileName, FileFullName) values ('" + strFileNameAndExtension + "','" + strFullFileName + "')";
                SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
                command.ExecuteNonQuery();
            }

            //for (int i = 0; i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; i++)
            //{
            //    if (strFullFileName == PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text)
            //        bExistInList = true;
            //}

            //if (!bExistInList)
            //{
            //    string strFileNameAndExtension = GetFileNameAndExtension(strFullFileName);
            //    PlayListPanel.dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, strFullFileName, 0);
            //}
        }

        private bool IsExistInLocalList(string strFullFileName)
        {
            bool bExistInList = false;
            strFullFileName = strFullFileName.Replace("\'", "\'\'");
            string sql = "select count(1) from LocalList where FileFullName ='" + strFullFileName + "'";
            SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
            int nCount = (int)(Int64)command.ExecuteScalar();
            bExistInList = (nCount == 0 ? false : true);
            return bExistInList;
        }

        private int GetOpenedFilePosition(string strFullFileName)
        {
            string strFileName = Path.GetFileName(strFullFileName);
            strFileName = strFileName.Replace("\'", "\'\'");
            string sql = "select * from LocalList where FileName ='" + strFileName + "'";
            SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
            SQLiteDataReader reader = command.ExecuteReader();

            int nPosition = 0;
            while (reader.Read())
            {
                if (reader["Position"] == null || reader["Position"].ToString() == "")
                    nPosition = 0;
                else
                    nPosition = (int)reader["Position"];
            }
            return nPosition;
        }

        //保存播放列表
        private void SaveLocalList()
        {
            //for (int i = 0; i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; i++)
            //{
            //    string FileName = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[1].Text;
            //    string FileFullName = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text;
            //    string FileFullName1 = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text;
            //    string Position = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[3].Text;
            //    FileName = FileName.Replace("\'", "\'\'");
            //    FileFullName = FileFullName.Replace("\'", "\'\'");
            //    string sql = "insert into LocalList (FileName, FileFullName, Position) values ('" + FileName + "','" + FileFullName + "','" + Position + "')";
            //    SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);

            //    bool bExistInList = false;
            //    bExistInList = IsExistInLocalList(FileFullName1);
            //    if (!bExistInList)
            //        command.ExecuteNonQuery();
            //}

            UpdateCurrentPlayingtoLocalList();
        }

        //更新当前播放的文件进度到LocalList中
        private void UpdateCurrentPlayingtoLocalList()
        {
            if (!b_PlayTV)
            {
                int nPosition = axPlayer1.GetPosition();
                if (nPosition == axPlayer1.GetDuration())   //播放结束，设置为0
                    nPosition = 0;
                if (nPosition <= 5000)  //开头小于5s的，从0开始。
                    nPosition = 0;
                if (axPlayer1.GetDuration() - nPosition < 30000) //离结束不到30s，就是结束前30秒开始。
                    nPosition = axPlayer1.GetDuration() - 30000;
                if (nPosition >= axPlayer1.GetDuration() - 5000)   //离结束不到5s，设置为0
                    nPosition = 0;

                nPosition -= 2500;  //和上次关闭前，再重叠2.5s。
                if (nPosition <= 0)
                    nPosition = 0;

                bool bExistInList = false;
                string str_NowPlaying = axPlayer1.GetConfig(4);
                //bExistInList = IsExistInLocalList(str_NowPlaying);
                //if (!bExistInList)
                //{
                //    string strFileNameAndExtension = Path.GetFileName(str_NowPlaying);
                //    str_NowPlaying = str_NowPlaying.Replace("\'", "\'\'");
                //    strFileNameAndExtension = strFileNameAndExtension.Replace("\'", "\'\'");
                //    string sql = "insert into LocalList (FileName, FileFullName) values ('" + strFileNameAndExtension + "','" + str_NowPlaying + "')";
                //    SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
                //    command.ExecuteNonQuery();
                //}
                //else
                {
                    str_NowPlaying = str_NowPlaying.Replace("\'", "\'\'");
                    string sql = "update LocalList set Position = " + nPosition + " where FileFullName = '" + str_NowPlaying + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, SQLiteConn);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SetAlbumArt(string strFullFileName)
        {
            TagLib.File file = TagLib.File.Create(strFullFileName);
            if (file.Tag.Pictures.Length > 0)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                Image image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(256, 256, null, IntPtr.Zero);
                string str_AlbumArt = Application.StartupPath + "\\AlbumArt.jpeg";
                image.Save(str_AlbumArt);
                axPlayer1.SetConfig(1308, str_AlbumArt);
            }
            else
            {
                string str_AlbumArt = Application.StartupPath + "\\BackGroundImage.jpeg";
                axPlayer1.SetConfig(1308, str_AlbumArt);
            }
        }

        public void SetTopMost()
        {
            if (str_TopMost == "TopMostWhilePlay")
            {
                this.TopMost = true;
                toolStripMenuItem_TopMostWhilePlay.Image = Image_CheckItem;
                toolStripMenuItem_Always.Image = toolStripMenuItem_Never.Image = null;
                if (TipPanel != null)
                    ShowTips("已切换到\"播放时置顶\"模式");
            }
            else if (str_TopMost == "Always")
            {
                this.TopMost = true;
                toolStripMenuItem_Always.Image = Image_CheckItem;
                toolStripMenuItem_TopMostWhilePlay.Image = toolStripMenuItem_Never.Image = null;
                if (TipPanel != null)
                    ShowTips("已切换到\"总是置顶\"模式");
            }
            else if (str_TopMost == "Never")
            {
                this.TopMost = false;
                toolStripMenuItem_Never.Image = Image_CheckItem;
                toolStripMenuItem_TopMostWhilePlay.Image = toolStripMenuItem_Always.Image = null;
                if (TipPanel != null)
                    ShowTips("已切换到\"从不置顶\"模式");
            }
        }

        #region 支持拖放
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string str_DragFile = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (str_Subtitle_filter.Contains(Path.GetExtension(str_DragFile).ToLower()))
            {
                axPlayer1.SetConfig(504, "0");
                axPlayer1.SetConfig(503, str_DragFile);
                axPlayer1.SetConfig(504, "1");
                ShowTips("成功载入字幕");
            }
            else
            {
                OpenFile(str_DragFile, -1);
                toolStripMenuItem_dPlayPause.Text = "暂停";
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }
        #endregion

        //操作提示
        public void ShowTips(string strTips)
        {
            TipPanel.timer.Dispose();
            TipPanel.timer = new Timer();
            //TipPanel.timer.Interval = 1000;
            //TipPanel.nTi = 0;
            TipPanel.ShowTips(strTips);
            //TipPanel.Show();
            //TipPanel.Activate();

            //弹出无焦点窗体
            //ShowWindow(TipPanel.Handle, SW_SHOWNOACTIVATE);
            //TipPanel.Owner.Focus();
        }

        #region DSkin右键菜单
        private void dSkinContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dSkinContextMenuStrip1.ItemHover = ItemHoverColor;
            toolStripMenuItem_dOpenFile.BackColor = toolStripMenuItem_dOpenURL.BackColor = Color.White;
            toolStripMenuItem_dOpenBt.BackColor = toolStripMenuItem_dOpenFolder.BackColor = Color.White;
            toolStripMenuItem_dSelectSoundTrack.DropDownItems.Clear();
            LoadSoundTrackPosition();
            AddSoundTrackList();
            QuerySoundOutputMode();
        }

        private void toolStripMenuItem_dOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolStripMenuItem_dOpenURL_Click(object sender, EventArgs e)
        {
            CallTV();
        }

        private void toolStripMenuItem_dOpenBt_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_dOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void toolStripMenuItem_dPlayPause_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void toolStripMenuItem_dMute_Click(object sender, EventArgs e)
        {
            ControlPanel.Mute();
        }

        #region 置顶播放
        private void toolStripMenuItem_dTopMostWhilePlay_Click(object sender, EventArgs e)
        {
            str_TopMost = "TopMostWhilePlay";
            SetTopMost();
        }

        private void toolStripMenuItem_dAlways_Click(object sender, EventArgs e)
        {
            str_TopMost = "Always";
            SetTopMost();
        }

        private void toolStripMenuItem_dNever_Click(object sender, EventArgs e)
        {
            str_TopMost = "Never";
            SetTopMost();
        }
        #endregion

        private void toolStripMenuItem_dHardwareAcceleration_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(axPlayer1.GetConfig(209));
            if (axPlayer1.GetConfig(209) == "0")
            {
                axPlayer1.SetConfig(209, "1");
                string strNowPlay = axPlayer1.GetConfig(4);
                int nNowPosition = axPlayer1.GetPosition();
                axPlayer1.Close();
                //System.Threading.Thread.Sleep(1000);
                axPlayer1.Open(strNowPlay);
                System.Threading.Thread.Sleep(500);
                axPlayer1.SetPosition(nNowPosition);
                axPlayer1.Play();

                //Console.WriteLine(axPlayer1.GetConfig(211));
                if (axPlayer1.GetConfig(211) == "1")     //开启成功
                {
                    //toolStripMenuItem_dHardwareAcceleration.Checked = true;
                    b_HardwareAcceleration = true;
                    toolStripMenuItem_dHardwareAcceleration.Text = "硬件加速(加速中)";
                    ShowTips("已开启硬件加速");
                }
                else if (axPlayer1.GetConfig(211) == "2")
                    ShowTips("开启硬件加速出现未知错误");
                else if (axPlayer1.GetConfig(211) == "3")
                    ShowTips("设备不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "4")
                    ShowTips("格式不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "5")
                    ShowTips("操作系统不支持硬件加速");
                else if (axPlayer1.GetConfig(211) == "6")
                    ShowTips("解码器不支持硬件加速");
            }
            else
            {
                axPlayer1.SetConfig(209, "0");
                string strNowPlay = axPlayer1.GetConfig(4);
                int nNowPosition = axPlayer1.GetPosition();
                axPlayer1.Close();
                //System.Threading.Thread.Sleep(1000);

                axPlayer1.Open(strNowPlay);
                System.Threading.Thread.Sleep(1000);
                axPlayer1.SetPosition(nNowPosition);
                axPlayer1.Play();

                //toolStripMenuItem_dHardwareAcceleration.Image = null;
                b_HardwareAcceleration = false;
                toolStripMenuItem_dHardwareAcceleration.Text = "硬件加速(F7)";
                ShowTips("已关闭硬件加速");
            }

            CheckHardwareAcceleration();
            EnhanceImageQuality();
            UnifyDiffVolumn();
        }

        private void toolStripMenuItem_dScreenShot_Click(object sender, EventArgs e)
        {
            CallScreenShot();
        }

        private void toolStripMenuItem_dEnhanceImage_Click(object sender, EventArgs e)
        {
            b_EnhanceImageQuality = !b_EnhanceImageQuality;
            EnhanceImageQuality();
        }

        private void toolStripMenuItem_dStandard_Click(object sender, EventArgs e)
        {
            ControlBox = true;
        }

        private void toolStripMenuItem_dMini_Click(object sender, EventArgs e)
        {
            ControlBox = false;
            //ControlBox = !ControlBox;
            //if (ControlBox)
            //    toolStripMenuItem_Mini.Image = null;
            //else
            //    toolStripMenuItem_Mini.Checked = true;
        }

        private void toolStripMenuItem_dFullScreen_Click(object sender, EventArgs e)
        {
            MaxScreen();
        }

        private void toolStripMenuItem_dClipBlackBand_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(207) == "0")
            {
                toolStripMenuItem_dClipBlackBand.Image = Image_CheckItem;
                axPlayer1.SetConfig(207, "1");
            }
            else
            {
                toolStripMenuItem_dClipBlackBand.Image = null;
                axPlayer1.SetConfig(207, "0");
            }
        }

        #region 画面旋转
        private void toolStripMenuItem_dFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(302) == "1")
                axPlayer1.SetConfig(302, "0");
            else
                Rotate("FlipH");
        }

        private void toolStripMenuItem_dFlipVertical_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(303) == "1")
                axPlayer1.SetConfig(303, "0");
            else
                Rotate("FlipV");
        }

        private void toolStripMenuItem_dLeft90_Click(object sender, EventArgs e)
        {
            n_RotateAngle -= 90;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_dRight90_Click(object sender, EventArgs e)
        {
            n_RotateAngle += 90;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_d180_Click(object sender, EventArgs e)
        {
            n_RotateAngle += 180;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_dAngleReset_Click(object sender, EventArgs e)
        {
            n_RotateAngle = 0;
            Rotate("0");
            if (axPlayer1.GetConfig(302) == "1")
                axPlayer1.SetConfig(302, "0");
            if (axPlayer1.GetConfig(303) == "1")
                axPlayer1.SetConfig(303, "0");
        }
        #endregion

        #region 画面微调
        private void toolStripMenuItem_dZoonIn_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth + 1).ToString() + ";" + (n_CustomHeight + 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dZoomOut_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth - 1).ToString() + ";" + (n_CustomHeight - 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dFatter_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = n_CustomWidth.ToString() + ";" + (n_CustomHeight - 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dThinner_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = n_CustomWidth.ToString() + ";" + (n_CustomHeight + 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dHigher_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth - 1).ToString() + ";" + n_CustomHeight.ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dShorter_Click(object sender, EventArgs e)
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth + 1).ToString() + ";" + n_CustomHeight.ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void toolStripMenuItem_dSizeReset_Click(object sender, EventArgs e)
        {
            GetVideoOriginalScale();
            str_OriginalVideoScale = n_OriginalWidth.ToString() + ";" + n_OriginalHeight.ToString();
            axPlayer1.SetConfig(204, str_OriginalVideoScale);
        }
        #endregion

        private void toolStripMenuItem_dVideoSetting_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Video");
        }

        #region 循环播放
        private void toolStripMenuItem_dLoopPlay_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(119, "1");
            toolStripMenuItem_dNoLoopPlay.Image = null;
            toolStripMenuItem_dLoopPlay.Image = Image_CheckItem;
        }

        private void toolStripMenuItem_dNoLoopPlay_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(119, "2");
            toolStripMenuItem_dNoLoopPlay.Image = Image_CheckItem;
            toolStripMenuItem_dLoopPlay.Image = null;
        }
        #endregion

        #region 播放速度
        private void toolStripMenuItem_dPlaySpeedFaster_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                return;
            if (n_PlaySpeed < 200)
                n_PlaySpeed += 10;
            else if (n_PlaySpeed >= 200)
                n_PlaySpeed += 50;
            axPlayer1.SetConfig(104, n_PlaySpeed.ToString());
            ShowTips("当前播放速度：" + (n_PlaySpeed / 100.0).ToString("#0.0") + "倍");
        }

        private void toolStripMenuItem_dPlaySpeedSlower_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                return;
            if (n_PlaySpeed <= 10)
                return;
            if (n_PlaySpeed < 200)
                n_PlaySpeed -= 10;
            else if (n_PlaySpeed >= 200)
                n_PlaySpeed -= 50;
            axPlayer1.SetConfig(104, n_PlaySpeed.ToString());
            ShowTips("当前播放速度：" + (n_PlaySpeed / 100.0).ToString("#0.0") + "倍");
        }

        private void toolStripMenuItem_dPlaySpeedNormal_Click(object sender, EventArgs e)
        {
            n_PlaySpeed = 100;
            axPlayer1.SetConfig(104, "100");
            ShowTips("已恢复为正常播放速度");
        }
        #endregion

        #region AB循环
        private void toolStripMenuItem_dSetA_Click(object sender, EventArgs e)
        {
            n_PositionA = axPlayer1.GetPosition();
            axPlayer1.SetConfig(102, n_PositionA.ToString());
        }

        private void toolStripMenuItem_dSetB_Click(object sender, EventArgs e)
        {
            n_PositionB = axPlayer1.GetPosition();
            axPlayer1.SetConfig(103, n_PositionB.ToString());
            axPlayer1.Open(axPlayer1.GetConfig(4));
            axPlayer1.SetConfig(119, "1");
        }

        private void toolStripMenuItem_dPlayAB_Click(object sender, EventArgs e)
        {
            if (n_PositionB == 0)
                return;
            axPlayer1.SetConfig(102, n_PositionA.ToString());
            axPlayer1.SetConfig(103, n_PositionB.ToString());
            axPlayer1.Open(axPlayer1.GetConfig(4));
            axPlayer1.SetConfig(119, "1");
        }

        private void toolStripMenuItem_dStopAB_Click(object sender, EventArgs e)
        {
            int n_Position = axPlayer1.GetPosition();
            axPlayer1.SetPosition(n_Position);
            axPlayer1.Open(axPlayer1.GetConfig(4));
        }
        #endregion

        #region 播放结束操作
        private void toolStripMenuItem_dFinishThenDoNothing_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_DoNoThing;
            toolStripMenuItem_dFinishThenDoNothing.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = null;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
        }

        private void toolStripMenuItem_dFinishThenQuitApp_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_ExitApp;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = null;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
            ShowTips("本集播放完毕后将执行退出Aurora Player操作");
        }

        private void toolStripMenuItem_dFinishThenLockPC_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_LockPC;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = null;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
            ShowTips("本集播放完毕后将执行锁定电脑操作");
        }

        private void toolStripMenuItem_dFinishThenLogOff_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_LogOff;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = null;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
            ShowTips("本集播放完毕后将执行注销电脑操作");
        }

        private void toolStripMenuItem_dFinishThenShutDown_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_Shutdown;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenReboot.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
            ShowTips("本集播放完毕后将执行关闭电脑操作");
        }

        private void toolStripMenuItem_dFinishThenReboot_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_Reboot;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = Image_CheckItem;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = null;
            ShowTips("本集播放完毕后将执行重启电脑操作");
        }

        private void toolStripMenuItem_dFinishThenTurnOffMonitor_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_TurnOffMonitor;
            toolStripMenuItem_dFinishThenDoNothing.Image = null;
            toolStripMenuItem_dFinishThenQuitApp.Image = null;
            toolStripMenuItem_dFinishThenLockPC.Image = null;
            toolStripMenuItem_dFinishThenLogOff.Image = null;
            toolStripMenuItem_dFinishThenShutDown.Image = null;
            toolStripMenuItem_dFinishThenReboot.Image = null;
            toolStripMenuItem_dFinishThenTurnOffMonitor.Image = Image_CheckItem;
            ShowTips("本集播放完毕后将执行关闭显示器操作");
        }

        private void toolStripMenuItem_dSetTask_Click(object sender, EventArgs e)
        {
            SetTask st = new SetTask();
            st.Parent = this.Owner;
            st.StartPosition = FormStartPosition.Manual;
            st.Location = new Point(this.Location.X + this.Width - st.Width - 1, this.Location.Y + this.Height - st.Height - 1);
            st.ShowDialog(this);
        }
        #endregion

        #region 音轨
        private void toolStripMenuItem_dLeftSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "1");
                toolStripMenuItem_dLeftSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_dRightSoundTrack.Image = null;
                toolStripMenuItem_dLRMixedSoundTrack.Image = null;
                toolStripMenuItem_dOriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_dRightSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "2");
                toolStripMenuItem_dLeftSoundTrack.Image = null;
                toolStripMenuItem_dRightSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_dLRMixedSoundTrack.Image = null;
                toolStripMenuItem_dOriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_dLRMixedSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "3");
                toolStripMenuItem_dLeftSoundTrack.Image = null;
                toolStripMenuItem_dRightSoundTrack.Image = null;
                toolStripMenuItem_dLRMixedSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_dOriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_dOriginalSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "0");
                toolStripMenuItem_dLeftSoundTrack.Image = null;
                toolStripMenuItem_dRightSoundTrack.Image = null;
                toolStripMenuItem_dLRMixedSoundTrack.Image = null;
                toolStripMenuItem_dOriginalSoundTrack.Image = Image_CheckItem;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_dSelectSoundTrack_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem_dSelectSoundTrack.DropDownItems.Count > 0)
            {
                int i = toolStripMenuItem_dSelectSoundTrack.DropDownItems.IndexOf((ToolStripMenuItem)sender);
                axPlayer1.SetConfig(403, i.ToString());

                ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                tsmi.Image = Image_CheckItem;
                foreach (ToolStripMenuItem tsmi_tmp in toolStripMenuItem_dSelectSoundTrack.DropDownItems)
                {
                    if (tsmi_tmp.Text == tsmi.Text)
                        tsmi_tmp.Image = Image_CheckItem;
                    else
                        tsmi_tmp.Image = null;
                }
            }
        }

        private void toolStripMenuItem_dImportSoundTrack_Click(object sender, EventArgs e)
        {
            //载入外部音轨
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "音频文件(*.音频文件)|" + str_Audio_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axPlayer1.SetConfig(409, openFileDialog.FileName.ToString());
                ShowTips("成功载入音轨");
            }
        }

        private void toolStripMenuItem_dSingleTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "1");
            toolStripMenuItem_dSingleTrack.Image = Image_CheckItem;
            toolStripMenuItem_dStereoTrack.Image = null;
            toolStripMenuItem_d51Track.Image = null;
            toolStripMenuItem_dSPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_dStereoTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "2");
            toolStripMenuItem_dSingleTrack.Image = null;
            toolStripMenuItem_dStereoTrack.Image = Image_CheckItem;
            toolStripMenuItem_d51Track.Image = null;
            toolStripMenuItem_dSPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_d51Track_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "3");
            toolStripMenuItem_dSingleTrack.Image = null;
            toolStripMenuItem_dStereoTrack.Image = null;
            toolStripMenuItem_d51Track.Image = Image_CheckItem;
            toolStripMenuItem_dSPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_dSPDIFTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "4");
            toolStripMenuItem_dSingleTrack.Image = null;
            toolStripMenuItem_dStereoTrack.Image = null;
            toolStripMenuItem_d51Track.Image = null;
            toolStripMenuItem_dSPDIFTrack.Image = Image_CheckItem;
        }

        private void toolStripMenuItem_dAudioSetting_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Audio");
        }
        #endregion

        #region 字幕
        private void toolStripMenuItem_dLoadSubtitle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "字幕文件(*.字幕文件)|" + str_Subtitle_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axPlayer1.SetConfig(504, "1");
                axPlayer1.SetConfig(503, openFileDialog.FileName.ToString());
                ShowTips("成功载入字幕");
            }
        }

        private void toolStripMenuItem_dHideSubtitle_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(504, "0");
        }

        private void toolStripMenuItem_dSubtitleSetting_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Subtitle");
        }
        #endregion

        private void toolStripMenuItem_dSettings_Click(object sender, EventArgs e)
        {
            CallSettings();
        }

        private void toolStripMenuItem_dDLNA_Click(object sender, EventArgs e)
        {
            CallDLNA();
        }

        #region 文件信息
        private void toolStripMenuItem_dFileInfo_Click(object sender, EventArgs e)
        {
            FileInfoFrm fl = new FileInfoFrm();
            fl.Parent = this.Owner;
            fl.StartPosition = FormStartPosition.CenterParent;
            fl.ShowDialog(this);
        }

        private void toolStripMenuItem_dDeleteFile_Click(object sender, EventArgs e)
        {
            if (!b_PlayTV)
            {
                string str_Url = axPlayer1.GetConfig(4);
                if (str_Url == "")
                    return;
                DialogResult dr = System.Windows.Forms.MessageBox.Show("确定要从磁盘删除 " + str_Url, "Aurora 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    axPlayer1.Close();
                    System.Threading.Thread.Sleep(100);
                    if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                        File.Delete(str_Url);
                }
            }
        }

        private void toolStripMenuItem_dOpenFileFolder_Click(object sender, EventArgs e)
        {
            if (!b_PlayTV)
            {
                string str_Url = axPlayer1.GetConfig(4);
                FileHelper.OpenSpecifiedFolderAndSelectFile(str_Url);
            }
            else
            {
                System.Diagnostics.Process.Start("www.auroraplayer.com");
            }
        }
        #endregion

        private void toolStripMenuItem_dAbout_Click(object sender, EventArgs e)
        {
            CallAbout();
            //AboutMe ab = new AboutMe();
            //ab.Parent = this.Owner;
            //ab.StartPosition = FormStartPosition.CenterParent;
            //ab.ShowDialog(this);
        }

        private void toolStripMenuItem_dDonate_Click(object sender, EventArgs e)
        {
            CallDonate();
        }

        private void toolStripMenuItem_QuitApp_Click(object sender, EventArgs e)
        {
            QuitApp();
        }
        #endregion

        #region  任务栏预览窗口添加按钮
        public ThumbnailToolBarButton buttonPlayPause;
        private ThumbnailToolBarButton buttonPrevious;
        private ThumbnailToolBarButton buttonNext;
        TaskbarManager tbManager = TaskbarManager.Instance;

        public void InitThumbnailToolbarButton()
        {
            Bitmap bmp = (Properties.Resources.Play24);
            Icon ico = Icon.FromHandle(bmp.GetHicon());
            buttonPlayPause = new ThumbnailToolBarButton(ico, "播放");
            buttonPlayPause.Enabled = true;
            buttonPlayPause.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(PlayPause);

            bmp = (Properties.Resources.Previous24);
            ico = Icon.FromHandle(bmp.GetHicon());
            buttonPrevious = new ThumbnailToolBarButton(ico, "上一个");
            buttonPrevious.Enabled = true;
            buttonPrevious.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(PlayPrevious);

            bmp = (Properties.Resources.Next24);
            ico = Icon.FromHandle(bmp.GetHicon());
            buttonNext = new ThumbnailToolBarButton(ico, "下一个");
            buttonNext.Enabled = true;
            buttonNext.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(PlayNext);

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, buttonPrevious, buttonPlayPause, buttonNext);
        }
        #endregion

        //Heart Beat心跳监测程序（一直运行）timer_Progress.Interval = 10
        private void timer_Progress_Tick(object sender, EventArgs e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY || axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PAUSED)
            {
                if (!b_PlayTV)
                {
                    SetControlPanel();
                    TaskbarManager.Instance.SetProgressValue(axPlayer1.GetPosition(), axPlayer1.GetDuration());
                }
                else
                {
                    ResetControlPanel();
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
            }
            else
                return;

            //播放快结束时候showtips，本集播放完成后，在OnEvent自动播放下一集。
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY && !b_PlayTV)
            {
                if (axPlayer1.GetDuration() - axPlayer1.GetPosition() <= 30000)
                {
                    if (n_WhatistodoNext != (int)PublicClass.WhtaistodoNext.PS_DoNoThing)
                    {
                        if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_ExitApp)
                        {
                            ShowTips("本集播放完毕后将执行退出Aurora Player操作");
                        }
                        else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_LockPC)
                        {
                            ShowTips("本集播放完毕后将执行锁定电脑操作");
                        }
                        else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_LogOff)
                        {
                            ShowTips("本集播放完毕后将执行注销电脑操作");
                        }
                        else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_Shutdown)
                        {
                            ShowTips("本集播放完毕后将执行关闭电脑操作");
                        }
                        else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_Reboot)
                        {
                            ShowTips("本集播放完毕后将执行重启电脑操作");
                        }
                        else if (n_WhatistodoNext == (int)PublicClass.WhtaistodoNext.PS_TurnOffMonitor)
                        {
                            ShowTips("本集播放完毕后将执行关闭显示器操作");
                        }
                    }
                    else
                        ShowTips("Aurora 即将播放下一集：" + GetNextFileName());
                }
            }

            //if (axPlayer1.GetVideoWidth() == 0)
            //    TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(pictureBox_Album.Location.X + 4, pictureBox_Album.Location.Y, pictureBox_Album.Size.Width - 1, pictureBox_Album.Size.Height - 4));
            //else
            //    TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(axPlayer1.Location.X, axPlayer1.Location.Y, axPlayer1.Size.Width, axPlayer1.Size.Height));

            if (!b_PlayTV)
            {
                if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                else if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PAUSED)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);
                else if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
            else
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                FLASHWINFO fInfo = new FLASHWINFO();
                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = this.Handle;
                fInfo.dwFlags = FlashWindowHelper.FLASHW_STOP;
                fInfo.uCount = UInt32.MaxValue;
                fInfo.dwTimeout = 0;
                FlashWindowHelper.FlashWindowEx(ref fInfo);
            }

            Rectangle rect_me = new Rectangle(0, 0, this.Width, this.Height);
            if (b_AutoHideTitleAndControlPanel && !rect_me.Contains(PointToClient(MousePosition)))
            {
                TitleBarPanel.Hide();
                ControlPanel.Hide();
                ControlPanel.dSkinTrackBar_Volumn.Visible = false;
                //axPlayer1.Focus();
            }

            //if (b_IsPlaying)
            //{
            //    if (Handle_Aurora != GetForegroundWindow() && isFullScreen)
            //        SetForegroundWindow(Handle_Aurora);//持续使该窗体置为最前
            //}
        }

        private void timer_ShowHideCursor_Tick(object sender, EventArgs e)
        {
            if (axPlayer1.Focused == true && b_IsPlaying == true)
            {
                //鼠标状态计数器>=0的情况下鼠标可见，<0不可见，并不是直接受api函数影响而改变
                long i = getIdleTick();
                //Console.WriteLine(i);
                if (i > 3000)
                {
                    while (n_CursorCount >= 0)
                    {
                        n_CursorCount = DllHelper.ShowCursor(false);
                        if (TitleBarPanel.Visible == true)
                            TitleBarPanel.Visible = false;
                        if (ControlPanel.Visible == true)
                            ControlPanel.Visible = false;
                    }
                }
                else
                {
                    while (n_CursorCount < 0)
                    {
                        n_CursorCount = DllHelper.ShowCursor(true);
                    }
                }
            }
        }

        // 获取闲置时间
        public long getIdleTick()
        {
            DllHelper.LASTINPUTINFO vLastInputInfo = new DllHelper.LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!DllHelper.GetLastInputInfo(ref vLastInputInfo)) return 0;
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        #region 暂停播放上一曲下一曲
        private void PlayPause(object sender, EventArgs e)
        {
            PlayPause();
        }

        public void PlayPause()
        {
            if (toolStripMenuItem_PlayPause.Text == "播放")
            {
                if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                {
                    if (!OpenFile())
                        return;
                }

                toolStripMenuItem_PlayPause.Text = "暂停";
                axPlayer1.Play();

                Bitmap bmp = (Properties.Resources.Pause24);
                Icon ico = Icon.FromHandle(bmp.GetHicon());
                buttonPlayPause.Icon = ico;
                buttonPlayPause.Tooltip = "暂停";

                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Pause24;
            }
            else
            {
                axPlayer1.Pause();
                toolStripMenuItem_PlayPause.Text = "播放";

                Bitmap bmp = (Properties.Resources.Play24);
                Icon ico = Icon.FromHandle(bmp.GetHicon());
                buttonPlayPause.Icon = ico;
                buttonPlayPause.Tooltip = "播放";

                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Play24;
            }
        }

        private void PlayNext(object sender, EventArgs e)
        {
            PlayNext();
        }

        public void PlayNext()
        {
            string strNowPlay = axPlayer1.GetConfig(4);
            for (int i = 0; i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; i++)
            {
                if (strNowPlay == PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text)
                {
                    if (i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount - 1)
                    {
                        if (File.Exists(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i + 1].Cells[2].Text))
                        {
                            OpenFile(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i + 1].Cells[2].Text, -1);
                            //PlayListPanel.dSkinGridList_PlayList_List.Rows[i + 1].IsSelected = true;
                        }
                    }
                    else
                    {
                        OpenFile(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[0].Cells[2].Text, -1);
                        //PlayListPanel.dSkinGridList_PlayList_List.Rows[0].IsSelected = true;
                    }
                }
            }
        }

        private string GetNextFileName()
        {
            string str_NextFileName = "";
            string strNowPlay = axPlayer1.GetConfig(4);
            for (int i = 0; i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; i++)
            {
                if (strNowPlay == PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text)
                {
                    if (i == PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount - 1)
                    {
                        str_NextFileName = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[0].Cells[2].Text;
                        break;
                    }
                    else
                    {
                        str_NextFileName = PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i + 1].Cells[2].Text;
                        break;
                    }
                }
            }
            return Path.GetFileName(str_NextFileName);
        }

        private void PlayPrevious(object sender, EventArgs e)
        {
            PlayPrevious();
        }

        public void PlayPrevious()
        {
            string strNowPlay = axPlayer1.GetConfig(4);
            for (int i = 0; i < PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount; i++)
            {
                if (strNowPlay == PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i].Cells[2].Text)
                {
                    if (i > 0)
                    {
                        if (File.Exists(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i - 1].Cells[2].Text))
                        {
                            OpenFile(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[i - 1].Cells[2].Text, -1);
                            //PlayListPanel.dSkinGridList_PlayList_List.Rows[i -1].IsSelected = true;
                        }
                    }
                    else
                    {
                        OpenFile(PlayListPanel.dSkinGridList_PlayList_LocalList.Rows[PlayListPanel.dSkinGridList_PlayList_LocalList.RowCount - 1].Cells[2].Text, -1);
                        //PlayListPanel.dSkinGridList_PlayList_List.Rows[PlayListPanel.dSkinGridList_PlayList_List.RowCount - 1].IsSelected = true;
                    }
                }
            }
        }

        #endregion

        //退出程序
        public void QuitApp()
        {
            try
            {
                b_Close = true;
                SaveLocalList();

                if (ControlPanel != null)
                    ControlPanel.Dispose();
                if (TipPanel != null)
                    TipPanel.Dispose();
                if (PlayListPanel != null)
                    PlayListPanel.Dispose();
                if (TitleBarPanel != null)
                    TitleBarPanel.Dispose();
                if (TimeLinePanel != null)
                    TimeLinePanel.Dispose();
                if (ad != null)
                    ad.Dispose();
                if (vr != null)
                    vr.Dispose();

                axPlayer1.Close();
                this.Close();
                //Application.Exit();
            }
            catch { return; }
        }

        public void MinimizeApp()
        {
            this.WindowState = FormWindowState.Minimized;
            if (PlayListPanel.Visible)
                PlayListPanel.Visible = false;
        }

        #region CallFrm
        private void CallQuickSetting(string str_Type)
        {
            //OverLayMainFrm(true);
            //QuickSetting x = null;
            //if (!IsOpenForm(x))
            //    x = new QuickSetting(str_Type);
            //x.StartPosition = FormStartPosition.CenterScreen;
            //x.Show(this);

            if (!IsFormOpened(quicksetting))
            {
                quicksetting = new QuickSetting(str_Type);
            }
            quicksetting.Owner = this;
            quicksetting.StartPosition = FormStartPosition.Manual;
            quicksetting.Location = new Point(this.Location.X + this.Width - quicksetting.Width - 1, this.Location.Y + this.Height - quicksetting.Height - 1);
            quicksetting.Visible = false;
            quicksetting.Show();
            //quicksetting.TopMost = true;
        }

        public void CallSettings()
        {
            if (!IsFormOpened(settings))
            {
                settings = new Settings();
            }
            settings.Owner = this;
            settings.StartPosition = FormStartPosition.Manual;
            settings.Location = new Point(this.Location.X + this.Width / 2 - settings.Width / 2, this.Location.Y + this.Height / 2 - settings.Height / 2);
            settings.Visible = false;
            settings.Show();
            //settings.TopMost = true;
        }

        public void CallScreenShot()
        {
            //int nState = axPlayer1.GetState();
            //if (nState == (int)PublicClass.PLAY_STATE.PS_PLAY)
            //    PlayPause();

            if (axPlayer1.GetConfig(701) == "1")
            {
                if (b_ShowScreenShotWindow)
                {
                    if (!IsFormOpened(screenshot))
                    {
                        screenshot = new ScreenShot();
                    }
                    screenshot.Owner = this;
                    screenshot.StartPosition = FormStartPosition.Manual;
                    screenshot.Location = new Point(this.Location.X + this.Width / 2 - screenshot.Width / 2, this.Location.Y + this.Height / 2 - screenshot.Height / 2);
                    screenshot.Visible = false;
                    screenshot.Show();
                    //screenshot.TopMost = true;
                }
                else if (!b_ShowScreenShotWindow)
                {
                    //string str_FilePathName = str_ScreenShotPath + "\\" + Path.GetFileNameWithoutExtension(axPlayer1.GetConfig(4))
                    //+ "-" + DateTime.Now.ToString("yyyymmddhhmmss") + "." + str_ScreenShotType;
                    if (str_ScreenShotPath == "")
                        str_ScreenShotPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    if (!Directory.Exists(str_ScreenShotPath))
                        Directory.CreateDirectory(str_ScreenShotPath);
                    string str_FilePathName = str_ScreenShotPath + "\\" + TitleBarPanel.Text
                    + "-" + DateTime.Now.ToString("yyyymmddhhmmss") + "." + str_ScreenShotType;
                    axPlayer1.SetConfig(708, "90");
                    axPlayer1.SetConfig(702, str_FilePathName);
                    ShowTips("已保存至：" + str_FilePathName);
                }
            }
            else
            {
                ShowTips("截图功能暂不可用或无图像可以截取");
            }

            //if (nState == (int)PublicClass.PLAY_STATE.PS_PLAY)
            //    PlayPause();
        }

        public void CallAbout()
        {
            if (!IsFormOpened(aboutme))
            {
                aboutme = new AboutMe();
            }
            aboutme.Owner = this;
            aboutme.StartPosition = FormStartPosition.Manual;
            aboutme.Location = new Point(this.Location.X + this.Width / 2 - aboutme.Width / 2, this.Location.Y + this.Height / 2 - aboutme.Height / 2);
            aboutme.Visible = false;
            aboutme.Show();
            //aboutme.TopMost = true;
        }

        public void CallDonate()
        {
            Donate dd = new Donate();
            dd.Owner = this;
            dd.StartPosition = FormStartPosition.CenterParent;
            dd.ShowDialog();
        }

        public void CallTV()
        {
            if (!IsFormOpened(tv))
            {
                tv = new TV();
            }
            tv.Owner = this;
            tv.StartPosition = FormStartPosition.Manual;
            tv.Location = new Point(this.Location.X + this.Width - tv.Width - 1, this.Location.Y + this.Height - tv.Height - 1);
            tv.Visible = false;
            tv.Show();
            //tv.TopMost = true;
        }

        public void CallVR()
        {
            if (!IsFormOpened(vr))
            {
                vr = new VR();
            }
            vr.Owner = this;
            vr.StartPosition = FormStartPosition.Manual;
            vr.Location = new Point(this.Location.X + this.Width - vr.Width - 1, this.Location.Y + this.Height - vr.Height - 1);

            //vr.Visible = false;
            if (vr.Visible == false)
                vr.Show();
            else
                vr.Close();
            //vr.TopMost = true;
        }

        private void CallDLNA()
        {
            if (!IsFormOpened(dlna))
            {
                dlna = new DLNA();
            }
            dlna.Parent = this.Owner;
            dlna.StartPosition = FormStartPosition.Manual;
            dlna.Location = new Point(this.Location.X + this.Width - dlna.Width - 1, this.Location.Y + this.Height - dlna.Height - 1);
            dlna.Visible = false;
            dlna.Show(this);
            //dlna.TopMost = true;
        }
        #endregion

        public void InitAuroraPanels()
        {
            TitleBarPanel = new TitleBarFrm();
            InitTitleBarPanel();

            TipPanel = new TipFrm();
            InitTipPanel();

            ControlPanel = new ControlFrm();
            InitControlPanel();
            ResetControlPanel();
            //SetControlPanel();

            PlayListPanel = new PlayListFrm();
            InitPlayListPanel();

            TimeLinePanel = new TimeLineFrm();
            InitTimeLinePanel();
        }

        #region 标题栏面板
        public void InitTitleBarPanel()
        {
            TitleBarPanel.Owner = this;
            TitleBarPanel.Visible = false;
            LocateResizeTitleBarPanel();
            TitleBarPanel.Show();
            if (b_AutoHideTitleAndControlPanel)
                TitleBarPanel.Hide();
        }

        public void LocateResizeTitleBarPanel()
        {
            if (b_isFullScreen)
            {
                TitleBarPanel.Location = new Point(this.Location.X, this.Location.Y);
                TitleBarPanel.Width = this.Width;
            }
            else
            {
                TitleBarPanel.Location = new Point(this.Location.X + 1, this.Location.Y + 1);
                TitleBarPanel.Width = this.Width - 2;
            }
            TitleBarPanel.Visible = (this.WindowState != FormWindowState.Minimized);
        }
        #endregion

        #region 进度条控制面板
        public void InitControlPanel()
        {
            ControlPanel.Visible = false;
            if (b_ControlFrmTransparent)
                ControlPanel.BackColor = Color.Transparent;
            else
            {
                ControlPanel.BackColor = Color.DarkGray;
                ControlPanel.Opacity = 0.7;
            }
            LocateResizeControlPanel();
            ControlPanel.Show(this);
            if (b_AutoHideTitleAndControlPanel)
                ControlPanel.Hide();
            ControlPanel.dSkinTrackBar_Volumn.Value = n_Volumn;
        }

        public void SetControlPanel()
        {
            ControlPanel.dSkinTrackBar_Progress.Minimum = 0;
            ControlPanel.dSkinTrackBar_Progress.Maximum = axPlayer1.GetDuration();
            ControlPanel.dSkinTrackBar_Progress.Value = axPlayer1.GetPosition();
            ControlPanel.dSkinLabel_CurrentTime.Text = FileHelper.GetAccurateTime(axPlayer1.GetPosition());
            ControlPanel.dSkinLabel_TotalTime.Text = FileHelper.GetAccurateTime(axPlayer1.GetDuration());
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Pause24;
            else
                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Play24;
        }

        public void ResetControlPanel()
        {
            //System.Threading.Thread.Sleep(1000);
            ControlPanel.dSkinTrackBar_Progress.Minimum = 0;
            //ControlPanel.dSkinTrackBar_Progress.Maximum = 0;
            ControlPanel.dSkinTrackBar_Progress.Value = 0;
            ControlPanel.dSkinLabel_CurrentTime.Text = "0:00:00";
            ControlPanel.dSkinLabel_TotalTime.Text = "0:00:00";
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Pause24;
            else
                ControlPanel.dSkinButton_PlayPause.Image = Properties.Resources.Play24;
        }

        public void LocateResizeControlPanel()
        {
            ControlPanel.Location = new Point(this.Location.X + 1, this.Location.Y + this.Height - ControlPanel.Height - 1);
            ControlPanel.Width = this.Width - 2;
        }
        #endregion

        #region 提示面板
        public void InitTipPanel()
        {
            TipPanel.Visible = false;
            LocateResizeTipPanel();
            TipPanel.Show(this);
        }

        public void LocateResizeTipPanel()
        {
            TipPanel.Location = new Point(this.Location.X + 25, this.Location.Y + 25);
            TipPanel.Width = this.Width - 27;
        }
        #endregion

        #region 播放列表面板
        public void InitPlayListPanel()
        {
            PlayListPanel.Visible = false;
            LocateResizePlayListPanel();
        }

        public void LocateResizePlayListPanel()
        {
            PlayListPanel.Width = this.Width / 4;
            if (PlayListPanel.Width > 350)
                PlayListPanel.Width = 350;
            else if (PlayListPanel.Width < 142)
                PlayListPanel.Width = 142;
            if (b_isFullScreen)
            {
                PlayListPanel.Height = this.Height;
                PlayListPanel.Location = new Point(this.Location.X + this.Width - PlayListPanel.Width - 1, this.Location.Y);
            }
            else
            {
                PlayListPanel.Height = this.Height - 2;
                PlayListPanel.Location = new Point(this.Location.X + this.Width - PlayListPanel.Width - 1, this.Location.Y + 1);
            }
        }
        #endregion

        #region 时间轴预览面板
        public void InitTimeLinePanel()
        {
            TimeLinePanel.Visible = false;
            LocateResizeTimeLinePanel();
        }

        public void LocateResizeTimeLinePanel()
        {
            Point mp = Control.MousePosition;
            TimeLinePanel.Location = new Point(mp.X - TimeLinePanel.Width / 2, mp.Y - TimeLinePanel.Height - 8);
            //if (mp.X - TimeLinePanel.Width / 2 < this.Location.X)
            //    TimeLinePanel.Location = new Point(this.Location.X, mp.Y - TimeLinePanel.Height);
        }
        #endregion

        private void QuerySoundOutputMode()
        {
            if (axPlayer1.GetConfig(1501) == "1")
            {
                if (axPlayer1.GetConfig(1502) == "1")
                {
                    toolStripMenuItem_SingleTrack.Image = Image_CheckItem;
                    toolStripMenuItem_StereoTrack.Image = null;
                    toolStripMenuItem_51Track.Image = null;
                    toolStripMenuItem_SPDIFTrack.Image = null;
                }
                else if (axPlayer1.GetConfig(1502) == "2")
                {
                    toolStripMenuItem_SingleTrack.Image = null;
                    toolStripMenuItem_StereoTrack.Image = Image_CheckItem;
                    toolStripMenuItem_51Track.Image = null;
                    toolStripMenuItem_SPDIFTrack.Image = null;
                }
                else if (axPlayer1.GetConfig(1502) == "3")
                {
                    toolStripMenuItem_SingleTrack.Image = null;
                    toolStripMenuItem_StereoTrack.Image = null;
                    toolStripMenuItem_51Track.Image = Image_CheckItem;
                    toolStripMenuItem_SPDIFTrack.Image = null;
                }
                else if (axPlayer1.GetConfig(1502) == "4")
                {
                    toolStripMenuItem_SingleTrack.Image = null;
                    toolStripMenuItem_StereoTrack.Image = null;
                    toolStripMenuItem_51Track.Image = null;
                    toolStripMenuItem_SPDIFTrack.Image = Image_CheckItem;
                }
            }
        }

        private void LoadSoundTrackPosition()
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                if (axPlayer1.GetConfig(404) == "0")
                {
                    toolStripMenuItem_LeftSoundTrack.Image = null;
                    toolStripMenuItem_RightSoundTrack.Image = null;
                    toolStripMenuItem_LRMixedSoundTrack.Image = null;
                    toolStripMenuItem_OriginalSoundTrack.Image = Image_CheckItem;
                }
                else if (axPlayer1.GetConfig(404) == "1")
                {
                    toolStripMenuItem_LeftSoundTrack.Image = Image_CheckItem;
                    toolStripMenuItem_RightSoundTrack.Image = null;
                    toolStripMenuItem_LRMixedSoundTrack.Image = null;
                    toolStripMenuItem_OriginalSoundTrack.Image = null;
                }
                else if (axPlayer1.GetConfig(404) == "2")
                {
                    toolStripMenuItem_LeftSoundTrack.Image = null;
                    toolStripMenuItem_RightSoundTrack.Image = Image_CheckItem;
                    toolStripMenuItem_LRMixedSoundTrack.Image = null;
                    toolStripMenuItem_OriginalSoundTrack.Image = null;
                }
                else if (axPlayer1.GetConfig(404) == "3")
                {
                    toolStripMenuItem_LeftSoundTrack.Image = null;
                    toolStripMenuItem_RightSoundTrack.Image = null;
                    toolStripMenuItem_LRMixedSoundTrack.Image = Image_CheckItem;
                    toolStripMenuItem_OriginalSoundTrack.Image = null;
                }
            }
        }

        private void AddSoundTrackList()
        {
            string str_CurretSoundTrackIndex = axPlayer1.GetConfig(403);
            string str_AllSoundTrackList = axPlayer1.GetConfig(402);
            if (str_AllSoundTrackList == "")
                return;
            string[] str_Arr = str_AllSoundTrackList.Split(';');
            for (int i = 0; i < str_Arr.Length; i++)
            {
                string tmp = str_Arr[i];
                if ((tmp.Contains("Cantonese") || tmp.Contains("cantonese")) && !tmp.Contains("粤语"))
                    tmp += " 粤语";
                if ((tmp.Contains("Mandarin") || tmp.Contains("mandarin")) && !tmp.Contains("普通话"))
                    tmp += " 普通话";
                ToolStripMenuItem tsmi = new ToolStripMenuItem(tmp);
                if (toolStripMenuItem_SelectSoundTrack.DropDownItems.Count == str_Arr.Length)
                    continue;
                else
                {
                    toolStripMenuItem_SelectSoundTrack.DropDownItems.Add(tsmi);
                    tsmi.Click += new EventHandler(SelectSoundTrack_Click);     //绑定方法
                    if (i == Convert.ToInt32(str_CurretSoundTrackIndex))
                        tsmi.Image = Image_CheckItem;
                }
            }
        }

        private void SelectSoundTrack_Click(object sender, EventArgs e)
        {
            int i = toolStripMenuItem_SelectSoundTrack.DropDownItems.IndexOf((ToolStripMenuItem)sender);
            axPlayer1.SetConfig(403, i.ToString());

            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            tsmi.Image = Image_CheckItem;
            foreach (ToolStripMenuItem tsmi_tmp in toolStripMenuItem_SelectSoundTrack.DropDownItems)
            {
                if (tsmi_tmp.Text == tsmi.Text)
                    tsmi_tmp.Image = Image_CheckItem;
                else
                    tsmi_tmp.Image = null;
            }
        }

        private void GetVideoOriginalScale()
        {
            str_OriginalVideoScale = axPlayer1.GetConfig(203);
            if (str_OriginalVideoScale == "0;0")
                return;
            string[] strArr = str_OriginalVideoScale.Split(';');
            n_OriginalWidth = Convert.ToInt32(strArr[0]);
            n_OriginalHeight = Convert.ToInt32(strArr[1]);
            d_OriginalVideoScale = Convert.ToDouble(strArr[0]) / Convert.ToDouble(strArr[1]);
        }

        private void GetVideoChangedScale()
        {
            str_CustomVideoScale = axPlayer1.GetConfig(204);
            if (str_CustomVideoScale == "0;0")
                return;
            string[] strArr = str_CustomVideoScale.Split(';');
            n_CustomWidth = Convert.ToInt32(strArr[0]);
            n_CustomHeight = Convert.ToInt32(strArr[1]);
        }

        public void ShowHidePlayListPanel()
        {
            if (PlayListPanel.Visible == false)
            {
                PlayListPanel.Visible = false;
                LocateResizePlayListPanel();
                PlayListPanel.Show(this);
            }
            else
                PlayListPanel.Visible = false;
        }

        public void Rotate(string strAngle)
        {
            if (axPlayer1.GetConfig(301) == "1")
            {
                switch (strAngle)
                {
                    case "FlipH":
                        axPlayer1.SetConfig(302, "1");
                        break;
                    case "FlipV":
                        axPlayer1.SetConfig(303, "1");
                        break;
                    default:
                        axPlayer1.SetConfig(304, strAngle);
                        break;
                }
            }
            else
            {
                ShowTips("视频图像处理功能暂不可用或无视频图像可以处理");
            }
        }

        private void SendWhatistodoNext(int n_WhatistodoNext)
        {
            FinishPlayToDo ff = new FinishPlayToDo();
            ff.Parent = this.Owner;
            ff.StartPosition = FormStartPosition.Manual;
            ff.Location = new Point(this.Location.X + this.Width - ff.Width - 1, this.Location.Y + this.Height - ff.Height - 1);
            ff.n_FinishodoNext = n_WhatistodoNext;
            ff.ShowDialog(this);
        }

        private void SetTask_Tick(object sender, EventArgs e)
        {
            n_SetTaskTimeLeft--;
            Console.WriteLine(n_SetTaskTimeLeft.ToString() + "s      " + n_WhatistodoNext);
            if (n_SetTaskTimeLeft == 30)    //最后30秒弹出提示，此时可以取消计划任务
            {
                SendWhatistodoNext(n_WhatistodoNext);
            }
        }

        //是否需要显示广告
        private void ShowAd()
        {
            DateTime dt1 = Convert.ToDateTime(ini.ReadValue("Settings", "LastAdDate"));
            DateTime dt2 = DateTime.Now;
            TimeSpan sp = dt2.Subtract(dt1);
            int diff = sp.Days;
            if (diff != 0)
            {
                b_ShowAd = true;
                b_ShowAdOnceMore = true;
            }
        }

        //Reset VR Mode
        private void ResetVRMode()
        {
            //axPlayer1.SetConfig(2401, "0");
            n_VRMode = 0;
            if (vr != null)
                vr.SetPictureBorder(0);
            axPlayer1.SetConfig(2402, "0");
        }

        //绘制遮罩层
        public void OverLayMainFrm(bool overlay)
        {
            picture_OverLay.Location = new Point(0, 0);
            picture_OverLay.BringToFront();
            picture_OverLay.Size = this.Size;
            picture_OverLay.BackColor = Color.Transparent;
            if (overlay)
            {
                this.Controls.Add(picture_OverLay);
                picture_OverLay.BringToFront();
            }
            else
            {
                this.Controls.Remove(picture_OverLay);
            }
        }

        public bool IsFormOpened(DSkinForm frm)
        {
            if (frm == null)
            {
                return false;
            }
            else if (frm.IsDisposed)
            {
                return false;
            }
            return true;
        }

        private void LoadPlugins()
        {
            if (File.Exists(Application.StartupPath + "\\plugins\\SpectrumPlugin.dll"))
            {
                axPlayer1.SetConfig(24, Application.StartupPath + "\\plugins\\SpectrumPlugin.dll");
                DllHelper.SetParam((int)this.Handle, 100, 65280, 255);
            }
        }

        #region 炫酷的新版菜单
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItem_SelectSoundTrack.DropDownItems.Clear();
            LoadSoundTrackPosition();
            AddSoundTrackList();
            QuerySoundOutputMode();
        }

        private void toolStripMenuItem_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolStripMenuItem_OpenURL_Click(object sender, EventArgs e)
        {
            CallTV();
        }

        private void toolStripMenuItem_OpenBT_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_OpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void toolStripMenuItem_PlayPause_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void toolStripMenuItem_Mute_Click(object sender, EventArgs e)
        {
            ControlPanel.Mute();
        }

        #region 置顶播放
        private void toolStripMenuItem_TopMostWhilePlay_Click(object sender, EventArgs e)
        {
            str_TopMost = "TopMostWhilePlay";
            SetTopMost();
        }

        private void toolStripMenuItem_Always_Click(object sender, EventArgs e)
        {
            str_TopMost = "Always";
            SetTopMost();
        }

        private void toolStripMenuItem_Never_Click(object sender, EventArgs e)
        {
            str_TopMost = "Never";
            SetTopMost();
        }
        #endregion

        private void toolStripMenuItem_HardwareAcceleration_Click(object sender, EventArgs e)
        {
            HardwareAcceleration();
        }

        private void toolStripMenuItem_ScreenShot_Click(object sender, EventArgs e)
        {
            CallScreenShot();
        }

        private void toolStripMenuItem_EnhanceImage_Click(object sender, EventArgs e)
        {
            b_EnhanceImageQuality = !b_EnhanceImageQuality;
            EnhanceImageQuality();
        }

        private void toolStripMenuItem_FullScreen_Click(object sender, EventArgs e)
        {
            MaxScreen();
        }

        private void toolStripMenuItem_Playlist_Click(object sender, EventArgs e)
        {
            ShowHidePlayListPanel();
        }

        private void toolStripMenuItem_VR_Click(object sender, EventArgs e)
        {
            CallVR();
        }

        private void toolStripMenuItem_DLNA_Click(object sender, EventArgs e)
        {
            CallDLNA();
        }

        private void toolStripMenuItem_ClipBlackBand_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(207) == "0")
            {
                toolStripMenuItem_ClipBlackBand.Image = Image_CheckItem;
                axPlayer1.SetConfig(207, "1");
            }
            else
            {
                toolStripMenuItem_ClipBlackBand.Image = null;
                axPlayer1.SetConfig(207, "0");
            }
        }

        #region 画面旋转
        private void toolStripMenuItem_FlipHorizontal_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(302) == "1")
                axPlayer1.SetConfig(302, "0");
            else
                Rotate("FlipH");
        }

        private void toolStripMenuItem_FlipVertical_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(303) == "1")
                axPlayer1.SetConfig(303, "0");
            else
                Rotate("FlipV");
        }

        private void toolStripMenuItem_Right90_Click(object sender, EventArgs e)
        {
            n_RotateAngle += 90;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_Left90_Click(object sender, EventArgs e)
        {
            n_RotateAngle -= 90;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_180_Click(object sender, EventArgs e)
        {
            n_RotateAngle += 180;
            Rotate(n_RotateAngle.ToString());
        }

        private void toolStripMenuItem_ResetAngle_Click(object sender, EventArgs e)
        {
            n_RotateAngle = 0;
            Rotate("0");
            if (axPlayer1.GetConfig(302) == "1")
                axPlayer1.SetConfig(302, "0");
            if (axPlayer1.GetConfig(303) == "1")
                axPlayer1.SetConfig(303, "0");
        }
        #endregion

        #region 画面微调
        private void toolStripMenuItem_ZoomIn_Click(object sender, EventArgs e)
        {
            VideoZoomIn();
        }

        private void toolStripMenuItem_ZoomOut_Click(object sender, EventArgs e)
        {
            VideoZoomOut();
        }

        private void toolStripMenuItem_Fatter_Click(object sender, EventArgs e)
        {
            VideoZoomFatter();
        }

        private void toolStripMenuItem_Thinner_Click(object sender, EventArgs e)
        {
            VideoZoomThinner();
        }

        private void toolStripMenuItem_Higher_Click(object sender, EventArgs e)
        {
            VideoZoomHigher();
        }

        private void toolStripMenuItem_Shorter_Click(object sender, EventArgs e)
        {
            VideoZoomShorter();
        }

        private void toolStripMenuItem_ResetVideo_Click(object sender, EventArgs e)
        {
            VideoZoomReset();
        }

        private void VideoZoomIn()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth + 1).ToString() + ";" + (n_CustomHeight + 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomOut()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth - 1).ToString() + ";" + (n_CustomHeight - 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomFatter()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = n_CustomWidth.ToString() + ";" + (n_CustomHeight - 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomThinner()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = n_CustomWidth.ToString() + ";" + (n_CustomHeight + 1).ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomHigher()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth - 1).ToString() + ";" + n_CustomHeight.ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomShorter()
        {
            GetVideoChangedScale();
            str_CustomVideoScale = (n_CustomWidth + 1).ToString() + ";" + n_CustomHeight.ToString();
            axPlayer1.SetConfig(204, str_CustomVideoScale);
        }

        private void VideoZoomReset()
        {
            GetVideoOriginalScale();
            str_OriginalVideoScale = n_OriginalWidth.ToString() + ";" + n_OriginalHeight.ToString();
            axPlayer1.SetConfig(204, str_OriginalVideoScale);
        }

        #endregion

        private void toolStripMenuItem_VideoSettings_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Video");
        }

        #region 循环播放
        private void toolStripMenuItem_LoopPlay_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(119, "1");
            toolStripMenuItem_NoLoopPlay.Image = null;
            toolStripMenuItem_LoopPlay.Image = Image_CheckItem;
        }

        private void toolStripMenuItem_NoLoopPlay_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(119, "2");
            toolStripMenuItem_NoLoopPlay.Image = Image_CheckItem;
            toolStripMenuItem_LoopPlay.Image = null;
        }
        #endregion

        #region 播放速度
        private void toolStripMenuItem_PlaySpeedFaster_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                return;
            if (n_PlaySpeed < 200)
                n_PlaySpeed += 10;
            else if (n_PlaySpeed >= 200)
                n_PlaySpeed += 50;
            axPlayer1.SetConfig(104, n_PlaySpeed.ToString());
            ShowTips("当前播放速度：" + (n_PlaySpeed / 100.0).ToString("#0.0") + "倍");
        }

        private void toolStripMenuItem_PlaySpeedSlower_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                return;
            if (n_PlaySpeed <= 10)
                return;
            if (n_PlaySpeed < 200)
                n_PlaySpeed -= 10;
            else if (n_PlaySpeed >= 200)
                n_PlaySpeed -= 50;
            axPlayer1.SetConfig(104, n_PlaySpeed.ToString());
            ShowTips("当前播放速度：" + (n_PlaySpeed / 100.0).ToString("#0.0") + "倍");
        }

        private void toolStripMenuItem_PlaySpeedNormal_Click(object sender, EventArgs e)
        {
            n_PlaySpeed = 100;
            axPlayer1.SetConfig(104, "100");
            ShowTips("已恢复为正常播放速度");
        }
        #endregion

        #region AB循环
        private void toolStripMenuItem_SetA_Click(object sender, EventArgs e)
        {
            n_PositionA = axPlayer1.GetPosition();
            axPlayer1.SetConfig(102, n_PositionA.ToString());
        }

        private void toolStripMenuItem_SetB_Click(object sender, EventArgs e)
        {
            n_PositionB = axPlayer1.GetPosition();
            axPlayer1.SetConfig(103, n_PositionB.ToString());
            axPlayer1.Open(axPlayer1.GetConfig(4));
            axPlayer1.SetConfig(119, "1");
        }

        private void toolStripMenuItem_PlayAB_Click(object sender, EventArgs e)
        {
            if (n_PositionB == 0)
                return;
            axPlayer1.SetConfig(102, n_PositionA.ToString());
            axPlayer1.SetConfig(103, n_PositionB.ToString());
            axPlayer1.Open(axPlayer1.GetConfig(4));
            axPlayer1.SetConfig(119, "1");
        }

        private void toolStripMenuItem_StopAB_Click(object sender, EventArgs e)
        {
            int n_Position = axPlayer1.GetPosition();
            axPlayer1.SetPosition(n_Position);
            axPlayer1.Open(axPlayer1.GetConfig(4));
        }
        #endregion

        #region 播放结束操作
        private void toolStripMenuItem_FinishThenDoNothing_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_DoNoThing;
            toolStripMenuItem_FinishThenDoNothing.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = null;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
        }

        private void toolStripMenuItem_FinishThenQuitApp_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_ExitApp;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = null;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
            ShowTips("本片播放完毕后将执行退出Aurora Player操作");
        }

        private void toolStripMenuItem_FinishThenLockPC_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_LockPC;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = null;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
            ShowTips("本片播放完毕后将执行锁定电脑操作");
        }

        private void toolStripMenuItem_FinishThenLogOff_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_LogOff;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = null;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
            ShowTips("本片播放完毕后将执行注销电脑操作");
        }

        private void toolStripMenuItem_FinishThenShutdown_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_Shutdown;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenReboot.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
            ShowTips("本片播放完毕后将执行关闭电脑操作");
        }

        private void toolStripMenuItem_FinishThenReboot_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_Reboot;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = Image_CheckItem;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = null;
            ShowTips("本片播放完毕后将执行重启电脑操作");
        }

        private void toolStripMenuItem_FinishThenTurnOffMonitor_Click(object sender, EventArgs e)
        {
            n_WhatistodoNext = (int)PublicClass.WhtaistodoNext.PS_TurnOffMonitor;
            toolStripMenuItem_FinishThenDoNothing.Image = null;
            toolStripMenuItem_FinishThenQuitApp.Image = null;
            toolStripMenuItem_FinishThenLockPC.Image = null;
            toolStripMenuItem_FinishThenLogOff.Image = null;
            toolStripMenuItem_FinishThenShutdown.Image = null;
            toolStripMenuItem_FinishThenReboot.Image = null;
            toolStripMenuItem_FinishThenTurnOffMonitor.Image = Image_CheckItem;
            ShowTips("本片播放完毕后将执行关闭显示器操作");
        }
        #endregion

        private void toolStripMenuItem_SetTask_Click(object sender, EventArgs e)
        {
            SetTask st = new SetTask();
            st.Owner = this;
            st.StartPosition = FormStartPosition.Manual;
            st.Location = new Point(this.Location.X + this.Width - st.Width - 1, this.Location.Y + this.Height - st.Height - 1);
            st.ShowDialog();
        }

        #region 音轨
        private void toolStripMenuItem_LeftSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "1");
                toolStripMenuItem_LeftSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_RightSoundTrack.Image = null;
                toolStripMenuItem_LRMixedSoundTrack.Image = null;
                toolStripMenuItem_OriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_RightSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "2");
                toolStripMenuItem_LeftSoundTrack.Image = null;
                toolStripMenuItem_RightSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_LRMixedSoundTrack.Image = null;
                toolStripMenuItem_OriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_LRMixedSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "3");
                toolStripMenuItem_LeftSoundTrack.Image = null;
                toolStripMenuItem_RightSoundTrack.Image = null;
                toolStripMenuItem_LRMixedSoundTrack.Image = Image_CheckItem;
                toolStripMenuItem_OriginalSoundTrack.Image = null;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_OriginalSoundTrack_Click(object sender, EventArgs e)
        {
            if (axPlayer1.GetConfig(401) == "1")
            {
                axPlayer1.SetConfig(404, "0");
                toolStripMenuItem_LeftSoundTrack.Image = null;
                toolStripMenuItem_RightSoundTrack.Image = null;
                toolStripMenuItem_LRMixedSoundTrack.Image = null;
                toolStripMenuItem_OriginalSoundTrack.Image = Image_CheckItem;
            }
            else
                ShowTips("声音处理功能暂不可用");
        }

        private void toolStripMenuItem_SelectSoundTrack_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_ImportSoundTrack_Click(object sender, EventArgs e)
        {
            //载入外部音轨
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "音频文件(*.音频文件)|" + str_Audio_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axPlayer1.SetConfig(409, openFileDialog.FileName.ToString());
                ShowTips("成功载入音轨");
            }
        }

        private void toolStripMenuItem_SingleTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "1");
            toolStripMenuItem_SingleTrack.Image = Image_CheckItem;
            toolStripMenuItem_StereoTrack.Image = null;
            toolStripMenuItem_51Track.Image = null;
            toolStripMenuItem_SPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_StereoTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "2");
            toolStripMenuItem_SingleTrack.Image = null;
            toolStripMenuItem_StereoTrack.Image = Image_CheckItem;
            toolStripMenuItem_51Track.Image = null;
            toolStripMenuItem_SPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_51Track_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "3");
            toolStripMenuItem_SingleTrack.Image = null;
            toolStripMenuItem_StereoTrack.Image = null;
            toolStripMenuItem_51Track.Image = Image_CheckItem;
            toolStripMenuItem_SPDIFTrack.Image = null;
        }

        private void toolStripMenuItem_SPDIFTrack_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(1502, "4");
            toolStripMenuItem_SingleTrack.Image = null;
            toolStripMenuItem_StereoTrack.Image = null;
            toolStripMenuItem_51Track.Image = null;
            toolStripMenuItem_SPDIFTrack.Image = Image_CheckItem;
        }

        private void toolStripMenuItem_SoundSettings_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Audio");
        }
        #endregion

        #region 字幕
        private void toolStripMenuItem_LoadSubtitle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "字幕文件(*.字幕文件)|" + str_Subtitle_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axPlayer1.SetConfig(504, "1");
                axPlayer1.SetConfig(503, openFileDialog.FileName.ToString());
                ShowTips("成功载入字幕");
            }
        }

        private void toolStripMenuItem_HideSubtitle_Click(object sender, EventArgs e)
        {
            axPlayer1.SetConfig(504, "0");
        }

        private void toolStripMenuItem_SubtitleSetting_Click(object sender, EventArgs e)
        {
            CallQuickSetting("Subtitle");
        }
        #endregion

        private void toolStripMenuItem_Settings_Click(object sender, EventArgs e)
        {
            CallSettings();
        }

        #region 文件信息
        private void toolStripMenuItem_FileInfo_Click(object sender, EventArgs e)
        {
            FileInfoFrm fl = new FileInfoFrm();
            fl.Owner = this;
            fl.StartPosition = FormStartPosition.CenterParent;
            fl.ShowDialog();
        }

        private void toolStripMenuItem_OpenFileFolder_Click(object sender, EventArgs e)
        {
            if (!b_PlayTV)
            {
                string str_Url = axPlayer1.GetConfig(4);
                FileHelper.OpenSpecifiedFolderAndSelectFile(str_Url);
            }
            else
            {
                System.Diagnostics.Process.Start("www.auroraplayer.com");
            }
        }

        private void toolStripMenuItem_DeleteFile_Click(object sender, EventArgs e)
        {
            if (!b_PlayTV)
            {
                string str_Url = axPlayer1.GetConfig(4);
                if (str_Url == "")
                    return;
                DialogResult dr = System.Windows.Forms.MessageBox.Show("确定要从磁盘删除 " + str_Url, "Aurora 提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    axPlayer1.Close();
                    System.Threading.Thread.Sleep(100);
                    if (axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                        File.Delete(str_Url);
                }
            }
        }
        #endregion

        private void toolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            CallAbout();
        }

        private void toolStripMenuItem_Donate_Click(object sender, EventArgs e)
        {
            CallDonate();
        }

        private void toolStripMenuItem_WatchAd_Click(object sender, EventArgs e)
        {
            //CallAd();
        }

        private void toolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            QuitApp();
        }
        #endregion








    }
}
