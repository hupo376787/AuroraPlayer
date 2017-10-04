using System;
using System.Drawing;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;

namespace Aurora_Player
{
    public partial class ControlFrm : DSkinForm
    {
        MainForm mainfrm;
        int n_VolumnBeforeMute;
        ToolTip tip = new ToolTip();

        public ControlFrm()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this.ControlFrm_MouseWheel);
            dSkinTrackBar_Progress.MouseWheel += new MouseEventHandler(this.ControlFrm_MouseWheel);
        }

        private void ControlFrm_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            //this.EnabledDWM = main.b_EnableDWM;
            AdjustLocation();
            mainfrm.LocateResizeControlPanel();
            dSkinTrackBar_Volumn.Visible = false;
            dSkinTrackBar_Volumn.Value = mainfrm.n_Volumn;
            
            SetFocusColor();
        }

        private void ControlFrm_MouseWheel(object sender, MouseEventArgs e)
        {
            mainfrm.MainForm_MouseWheel(sender, e);
        }

        public void SetFocusColor()
        {
            DSkinTextureBrush dbrush = new DSkinTextureBrush();
            dbrush.Brush = new SolidBrush(mainfrm.FocusColor);
            foreach (Control ctl in this.Controls)
            {
                if (ctl is DSkinTrackBar)
                {
                    DSkinTrackBar tb = (DSkinTrackBar)ctl;
                    tb.PointButtonNormalColor = tb.PointButtonHoverColor = tb.PointButtonBorderColor = mainfrm.FocusColor;
                    tb.MainLineBrushUp = dbrush;
                }
                else if (ctl is DSkinButton)
                {
                    DSkinButton bt = (DSkinButton)ctl;
                    bt.PressColor = bt.PressColor = bt.PressColor = bt.PressColor = bt.PressColor = mainfrm.FocusColor;
                    bt.HoverColor = bt.HoverColor = bt.HoverColor = bt.HoverColor = bt.HoverColor = mainfrm.FocusColor;
                }
            }
        }

        private void ControlFrm_Resize(object sender, EventArgs e)
        {
            AdjustLocation();
            if(mainfrm != null)
                mainfrm.LocateResizeControlPanel();
        }

        private void ControlFrm_SizeChanged(object sender, EventArgs e)
        {
            AdjustLocation();
            if (mainfrm != null)
                mainfrm.LocateResizeControlPanel();
        }

        private void AdjustLocation()
        {
            int n_Dist = this.Width / 10;
            dSkinButton_PlayPause.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 + n_Dist / 2, dSkinButton_PlayPause.Location.Y);
            dSkinButton_Previous.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 - n_Dist / 2, dSkinButton_PlayPause.Location.Y);
            dSkinButton_Next.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 + n_Dist * 3 / 2, dSkinButton_PlayPause.Location.Y);
            dSkinButton_Volumn.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 + n_Dist * 5 /2 , dSkinButton_PlayPause.Location.Y);
            dSkinButton_PlayList.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 - n_Dist * 3 / 2, dSkinButton_PlayPause.Location.Y);
            dSkinButton_VR.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 - n_Dist * 5 / 2, dSkinButton_PlayPause.Location.Y);
            dSkinTrackBar_Volumn.Location = new Point(this.Width / 2 - dSkinButton_PlayPause.Width / 2 + n_Dist * 5 / 2 + dSkinButton_Volumn.Width, dSkinButton_PlayPause.Location.Y + dSkinButton_PlayPause.Height / 2 - dSkinTrackBar_Volumn.Height / 2);
            dSkinTrackBar_Volumn.Width = this.Width / 7;
            //dSkinLabel_CurrentTime.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //dSkinLabel_TotalTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dSkinLabel_CurrentTime.Location = new Point(dSkinTrackBar_Progress.Location.X + 9, dSkinTrackBar_Progress.Location.Y + 25);
            dSkinLabel_TotalTime.Location = new Point(dSkinTrackBar_Progress.Location.X - 7 + dSkinTrackBar_Progress.Width - dSkinLabel_TotalTime.Width, dSkinTrackBar_Progress.Location.Y + 25);
        }

        private void dSkinTrackBar_Progress_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(main.timer_Progress.Enabled.ToString() + "Click");
        }

        private void dSkinTrackBar_Progress_MouseUp(object sender, MouseEventArgs e)
        {
            if(!mainfrm.b_PlayTV)
            {
                mainfrm.axPlayer1.SetPosition(dSkinTrackBar_Progress.Value);
                mainfrm.timer_Progress.Enabled = true;
            }
            //Console.WriteLine(main.timer_Progress.Enabled.ToString());
        }

        private void dSkinTrackBar_Progress_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.timer_Progress.Enabled = false;
            //Console.WriteLine(main.timer_Progress.Enabled.ToString());
        }

        private void dSkinTrackBar_Progress_MouseClick(object sender, MouseEventArgs e)
        {
            mainfrm.timer_Progress.Enabled = false;
        }

        private void dSkinTrackBar_Progress_MouseEnter(object sender, EventArgs e)
        {
            dSkinTrackBar_Progress.PointButtonBorderColor = Color.White;
            dSkinTrackBar_Progress.PointButtonBorderWidth = 2;
            dSkinTrackBar_Progress.PointButtonSize = new Size(15, 15);
        }

        private void dSkinTrackBar_Progress_MouseLeave(object sender, EventArgs e)
        {
            dSkinTrackBar_Progress.PointButtonBorderColor = mainfrm.FocusColor;
            dSkinTrackBar_Progress.PointButtonBorderWidth = 1;
            dSkinTrackBar_Progress.PointButtonSize = new Size(14, 14);

            mainfrm.TimeLinePanel.Visible = false;
        }

        private void dSkinButton_PlayList_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.ShowHidePlayListPanel();
        }

        private void dSkinButton_Previous_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.PlayPrevious();
        }

        private void dSkinButton_PlayPause_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.PlayPause();
        }

        private void dSkinButton_Next_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.PlayNext();
        }

        private void dSkinButton_VR_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.CallVR();
        }

        private void dSkinTrackBar_Volumn_MouseEnter(object sender, EventArgs e)
        {
            dSkinTrackBar_Volumn.PointButtonBorderColor = Color.White;
            dSkinTrackBar_Volumn.PointButtonBorderWidth = 2;
            dSkinTrackBar_Volumn.PointButtonSize = new Size(10, 10);
        }

        private void dSkinTrackBar_Volumn_MouseLeave(object sender, EventArgs e)
        {
            dSkinTrackBar_Volumn.PointButtonBorderColor = mainfrm.FocusColor;
            dSkinTrackBar_Volumn.PointButtonBorderWidth = 1;
            dSkinTrackBar_Volumn.PointButtonSize = new Size(9, 9);
        }

        private void dSkinTrackBar_Volumn_ValueChanged(object sender, EventArgs e)
        {
            if(mainfrm.axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                mainfrm.axPlayer1.SetVolume(dSkinTrackBar_Volumn.Value);
            mainfrm.ShowTips("音量：" + dSkinTrackBar_Volumn.Value.ToString() + "%");
            SetVolumnIcon();
        }

        private void SetVolumnIcon()
        {
            if (dSkinTrackBar_Volumn.Value == 0)
                dSkinButton_Volumn.Image = Properties.Resources.Volumn0_24;
            else if (dSkinTrackBar_Volumn.Value > 0 && dSkinTrackBar_Volumn.Value <= 33)
                dSkinButton_Volumn.Image = Properties.Resources.Volumn1_24;
            else if (dSkinTrackBar_Volumn.Value > 33 && dSkinTrackBar_Volumn.Value <= 66)
                dSkinButton_Volumn.Image = Properties.Resources.Volumn2_24;
            else if (dSkinTrackBar_Volumn.Value > 66)
                dSkinButton_Volumn.Image = Properties.Resources.Volumn3_24;
        }

        private void dSkinButton_Volumn_MouseEnter(object sender, EventArgs e)
        {
            SetVolumnIcon();
            dSkinTrackBar_Volumn.Visible = true;
            //tip.SetToolTip(dSkinButton_Volumn, "音量");
            tip.Show("音量", this, dSkinButton_Volumn.Location.X - 5, dSkinButton_Volumn.Location.Y - 25);
        }

        private void dSkinButton_Volumn_MouseLeave(object sender, EventArgs e)
        {
            SetVolumnIcon();
            tip.Hide(this);
        }

        private void dSkinButton_Volumn_MouseDown(object sender, MouseEventArgs e)
        {
            Mute();
        }

        public void Mute()
        {
            if (dSkinTrackBar_Volumn.Value != 0)
            {
                n_VolumnBeforeMute = dSkinTrackBar_Volumn.Value;
                dSkinTrackBar_Volumn.Value = 0;
                dSkinButton_Volumn.Image = Properties.Resources.Volumn_1_24;
            }
            else
            {
                dSkinTrackBar_Volumn.Value = n_VolumnBeforeMute;
            }
            mainfrm.Mute();
            SetVolumnIcon();
        }

        private void dSkinTrackBar_Progress_MouseMove(object sender, MouseEventArgs e)
        {
            int x_mouse = e.X - 10;
            int x_trackbar_max = dSkinTrackBar_Progress.Width - 21;
            int aa = mainfrm.axPlayer1.GetDuration();
            //Console.WriteLine((x_mouse + "," + main.axPlayer1.GetDuration() + "," + x_trackbar_max));
            double dTemp = x_mouse * 1.0 / x_trackbar_max;
            //Console.WriteLine(dTemp);
            Int64 n_Progress = (Int64)(dTemp * mainfrm.axPlayer1.GetDuration());
            string str_Progress = FileHelper.GetAccurateTime(n_Progress);
            //Console.WriteLine(FileHelper.GetAccurateTime(n_Progress);

            mainfrm.LocateResizeTimeLinePanel();
            mainfrm.TimeLinePanel.TopMost = true;
            if(mainfrm.axPlayer1.GetConfig(4) != "" && !mainfrm.b_PlayTV && mainfrm.b_IsPlaying)
            {
                mainfrm.TimeLinePanel.dSkinLabel_Preview.Text = str_Progress;
                mainfrm.TimeLinePanel.Show();
            }
        }

        private void ControlFrm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            mainfrm.axPlayer1_PreviewKeyDown(sender, e);
        }

        private void ControlFrm_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Clicks == 1)
            //{
            //    if (!mainfrm.b_isFullScreen)
            //    {
            //        DllHelper.ReleaseCapture();
            //        DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
            //    }
            //}
        }

        private void dSkinButton_PlayPause_MouseEnter(object sender, EventArgs e)
        {
            //tip.SetToolTip(dSkinButton_PlayPause, "播放/暂停");
            tip.Show("播放/暂停", this, dSkinButton_PlayPause.Location.X - 20, dSkinButton_PlayPause.Location.Y - 25);
        }

        private void dSkinButton_VR_MouseEnter(object sender, EventArgs e)
        {
            //tip.SetToolTip(dSkinButton_VR, "虚拟现实");
            tip.Show("虚拟现实", this, dSkinButton_VR.Location.X - 17, dSkinButton_VR.Location.Y - 25);
        }

        private void dSkinButton_PlayList_MouseEnter(object sender, EventArgs e)
        {
            //tip.SetToolTip(dSkinButton_PlayList, "播放列表");
            tip.Show("播放列表", this, dSkinButton_PlayList.Location.X - 17, dSkinButton_PlayList.Location.Y - 25);
        }

        private void dSkinButton_Previous_MouseEnter(object sender, EventArgs e)
        {
            //tip.SetToolTip(dSkinButton_Previous, "上一个");
            tip.Show("上一个", this, dSkinButton_Previous.Location.X - 12, dSkinButton_Previous.Location.Y - 25);
        }

        private void dSkinButton_Next_MouseEnter(object sender, EventArgs e)
        {
            //tip.SetToolTip(dSkinButton_Next, "下一个");
            tip.Show("下一个", this, dSkinButton_Next.Location.X - 12, dSkinButton_Next.Location.Y - 25);
        }

        private void dSkinButton_VR_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(this);
        }

        private void dSkinButton_PlayList_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(this);
        }

        private void dSkinButton_Previous_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(this);
        }

        private void dSkinButton_PlayPause_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(this);
        }

        private void dSkinButton_Next_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(this);
        }

        private void ControlFrm_MouseEnter(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void ControlFrm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:
                    if (e.Control)
                        mainfrm.OpenFile();
                    break;
                case Keys.S:
                    if (e.Control)
                        mainfrm.CallSettings();
                    break;
                case Keys.U:
                    if (e.Control)
                        mainfrm.CallTV();
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
                    mainfrm.MaxScreen();
                    break;
                case Keys.F5:
                    mainfrm.axPlayer1.Close();
                    mainfrm.axPlayer1.Open(mainfrm.axPlayer1.GetConfig(4));
                    //AfterOpenFile();
                    mainfrm.ResetControlPanel();
                    break;
                case Keys.Space:
                case Keys.MediaPlayPause:
                    if (mainfrm.axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
                    {
                        mainfrm.OpenFile();
                        break;
                    }
                    if (mainfrm.axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
                    {
                        mainfrm.axPlayer1.Pause();

                        mainfrm.toolStripMenuItem_PlayPause.Text = "播放";
                        Bitmap bmp = (Properties.Resources.Play24);
                        Icon ico = Icon.FromHandle(bmp.GetHicon());
                        mainfrm.buttonPlayPause.Icon = ico;
                        mainfrm.buttonPlayPause.Tooltip = "播放";
                    }
                    else
                    {
                        mainfrm.axPlayer1.Play();

                        mainfrm.toolStripMenuItem_PlayPause.Text = "暂停";
                        Bitmap bmp = (Properties.Resources.Pause24);
                        Icon ico = Icon.FromHandle(bmp.GetHicon());
                        mainfrm.buttonPlayPause.Icon = ico;
                        mainfrm.buttonPlayPause.Tooltip = "暂停";
                    }
                    break;
                case Keys.F8:
                    mainfrm.CallScreenShot();
                    break;
                case Keys.F9:
                    mainfrm.b_EnhanceImageQuality = !mainfrm.b_EnhanceImageQuality;
                    mainfrm.EnhanceImageQuality();
                    break;
                case Keys.F10:
                    mainfrm.str_TopMost = "TopMostWhilePlay";
                    mainfrm.SetTopMost();
                    break;
                case Keys.Escape:
                    {
                        if (mainfrm.b_isFullScreen)
                            mainfrm.MaxScreen();
                    }
                    break;
                case Keys.ShiftKey:
                    mainfrm.EnhanceContrast();
                    break;
                case Keys.Up:
                case Keys.VolumeUp:
                    {
                        mainfrm.VolumnUp();
                    }
                    break;
                case Keys.Down:
                case Keys.VolumeDown:
                    {
                        mainfrm.VolumnDown();
                    }
                    break;
                case Keys.Left:
                    //{
                    //    if (!mainfrm.b_PlayTV)
                    //    {
                    //        int nPosition = axPlayer1.GetPosition();
                    //        if (nPosition - n_FastBack * 1000 > 0)
                    //            axPlayer1.SetPosition(nPosition - n_FastBack * 1000);
                    //        else
                    //            axPlayer1.SetPosition(0);
                    //    }
                    //}
                    break;
                case Keys.Right:
                    //{
                    //    if (!b_PlayTV)
                    //    {
                    //        int nPosition = axPlayer1.GetPosition();
                    //        if (nPosition + n_FastForward * 1000 < axPlayer1.GetDuration())
                    //            axPlayer1.SetPosition(nPosition + n_FastForward * 1000);
                    //        else
                    //            axPlayer1.Close();
                    //    }
                    //}
                    break;
                case Keys.VolumeMute:
                    Mute();
                    break;
                default:
                    break;
            }
        }
    }
}
