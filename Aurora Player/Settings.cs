using System;
using System.Drawing;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;
using DSkin.DirectUI;
using DSkin.Imaging;
using DSkin.Common;
using System.Collections.Generic;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;

namespace Aurora_Player
{
    public partial class Settings : DSkinForm
    {
        public Settings()
        {
            InitializeComponent();
            AnchorLables = new DSkinLabel[] { dSkinLabel_General, dSkinLabel_Play, dSkinLabel_Volumn, dSkinLabel_Video, dSkinLabel_Subtitle,
                dSkinLabel_Association, dSkinLabel_BackGround, dSkinLabel_ScreenShot, dSkinLabel_Donate, dSkinLabel_Update, dSkinLabel_Other };
            TrackBars = new DSkinTrackBar[] { dSkinTrackBar_BackColorOpacity, dSkinTrackBar_BackImageOpacity, dSkinTrackBar_MainFrmOpacity,
                dSkinTrackBar_Brightness, dSkinTrackBar_Contrast, dSkinTrackBar_Hue, dSkinTrackBar_HumanVolumn, dSkinTrackBar_Saturation,
                dSkinTrackBar_SoundBalance };
            DSkinCheckBox[] dcb = new DSkinCheckBox[] { dSkinCheckBox_CreateShortcutToDesktop, dSkinCheckBox_EnableDWM, dSkinCheckBox_EnhanceImageQuality,
                dSkinCheckBox_ImageFuzzy, dSkinCheckBox_LockToTaskbar, dSkinCheckBox_PauseWhileMinimize, dSkinCheckBox_ShowScreenShotWindow,
                dSkinCheckBox_UnifyDiffVolumn, dSkinCheckBox_IncludeSubDir, dSkinCheckBox_ControlFrmTransparent, dSkinCheckBox_AutoMatchNetSubtitle,
                dSkinCheckBox_AutoMatchLocalSubtitle, dSkinCheckBox_AutoHideTitleAndControlPanel, dSkinCheckBox_ShowAdOnceMore};
            for (int i = 1; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                CheckBoxs.Add(cb);
            }
            CheckBoxs.AddRange(dcb);
            duiScrollBar_LinkFile.ValueChanged += new System.EventHandler(this.duiScrollBar_LinkFile_ValueChanged);
        }
        
        MainForm mainFrm;
        IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");

        bool b_SelectVideo = false;
        bool b_SelectAudio = false;
        bool b_SelectSubtitle = false;

        DSkinTrackBar[] TrackBars;
        List<DSkinCheckBox> CheckBoxs = new List<DSkinCheckBox>();

        //锚点标签控件数组,用于标记panel滚动的制定位置
        DSkinLabel[] AnchorLables;

        //被选中的项目的背景色
        Color SelectedBackColor = Color.FromArgb(240, 240, 240, 240);
        //项目正常的背景色
        Color NormalBackColor = Color.FromArgb(10, 240, 240, 240);
        //鼠标移入项目的背景色
        Color HoverBackColor = Color.FromArgb(100, 240, 240, 240);

        #region 设置菜单封装方法及事件
        Font font = new Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="name">菜单名称</param>
        /// <param name="top">标签Top</param>
        public void AddItems(string name, int top)
        {
            DuiLabel item = new DuiLabel();
            item.Text = name;
            item.Size = new System.Drawing.Size(MenuList.Width, 35);
            item.TextAlign = ContentAlignment.MiddleLeft;
            item.TextPadding = 10;
            item.Tag = top;
            item.TextAlign = ContentAlignment.MiddleCenter;
            item.Font = font;
            item.MouseUp += ItemsMouseUp;
            item.MouseEnter += delegate
            {//鼠标移入效果
                if (item.BackColor != SelectedBackColor)
                {
                    item.BackColor = HoverBackColor;
                }
            };
            item.MouseLeave += delegate
            {//鼠标移出效果
                if (item.BackColor != SelectedBackColor)
                {
                    item.BackColor = NormalBackColor;
                }
            };
            MenuList.Items.Add(item);
            MenuList.LayoutContent();
        }

        /// <summary>
        /// 菜单列表项点击选中时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseUp(object sender, MouseEventArgs e)
        {
            //PnlInfo.VerticalScroll.Value = ((int)((DuiBaseControl)sender).Tag);
            PnlInfo.AutoScrollPosition = new Point(0, (int)((DuiBaseControl)sender).Tag - 10);
            PnlInfo.VScrollBar.Value = PnlInfo.VerticalScroll.Value;//同步滚动条
        }
        #endregion

        /// <summary>
        /// 添加列表菜单项
        /// </summary>
        /// <param name="itemsname">列表菜单名称数组集合</param>
        public void AddListItems(string[] itemsname)
        {
            for (int i = 0; i < itemsname.Length; i++)
            {
                AddItems(itemsname[i], AnchorLables[i].Top);
            }
        }

        /// <summary>
        /// 滚动条的值发生改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollBarValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < AnchorLables.Length; i++)
            {
                Control label = AnchorLables[i];
                if (label.Top >= -5 || i == AnchorLables.Length - 1)
                {
                    foreach (DuiBaseControl item in MenuList.Items)
                    {
                        item.BackColor = NormalBackColor;
                    }
                    MenuList.Items[i].BackColor = SelectedBackColor;
                    break;
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            mainFrm = (MainForm)this.Owner;
            AddListItems(new[] { "常规", "播放", "声音", "画面", "字幕", "关联", "背景", "截图", "赞助", "更新", "其他" });
            MenuList.Items[0].Focus();
            MenuList.Items[0].BackColor = SelectedBackColor;

            Thread thread = new Thread(LoadPrepare);
            thread.Start();

            PnlInfo.Refresh();
        }

        private void LoadPrepare()
        {
            MethodInvoker invoke = new MethodInvoker(LoadPrepare1);
            BeginInvoke(invoke);
        }

        private void LoadPrepare1()
        {
            for (int i = 1; i <= 60; i++)
            {
                DuiLabel dl = new DuiLabel();
                dl.TextAlign = ContentAlignment.MiddleLeft;
                dl.TextInnerPadding = new Padding(18, 0, 0, 0);
                dl.Text = i.ToString();
                dSkinComboBox_FastBack.Items.Add(dl);

                DuiLabel dll = new DuiLabel();
                dll.TextAlign = ContentAlignment.MiddleLeft;
                dll.TextInnerPadding = new Padding(18, 0, 0, 0);
                dll.Text = i.ToString();
                dSkinComboBox_FastForward.Items.Add(dll);
            }

            PnlInfo.VScrollBar.Fillet = true;
            PnlInfo.VScrollBar.Width = 9;
            dSkinComboBox_FastBack.InnerListBox.ScrollBarWidth = 11;
            dSkinComboBox_FastForward.InnerListBox.ScrollBarWidth = 11;
            dSkinPanel_LinkFile.VScrollBar.Fillet = true;
            dSkinComboBox_FastBack.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_FastForward.InnerListBox.InnerScrollBar.Fillet = true;
            PnlInfo.VScrollBar.ValueChanged += ScrollBarValueChanged;


            duiScrollBar_LinkFile.Minimum = 0;
            duiScrollBar_LinkFile.Maximum = 750;
            duiScrollBar_LinkFile.SmallChange = 25;
            duiScrollBar_LinkFile.LargeChange = 100;
            dSkinPanel_LinkFile.VerticalScroll.Minimum = 0;
            dSkinPanel_LinkFile.VerticalScroll.Maximum = 750;

            ReadSettings();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteValue("Settings", "BackGroundImage", dSkinTextBox_BackGround.Text);
        }

        //读取ini配置
        private void ReadSettings()
        {
            dSkinCheckBox_ControlFrmTransparent.Checked = mainFrm.b_ControlFrmTransparent;
            dSkinCheckBox_IncludeSubDir.Checked = mainFrm.b_IncludeSubDir;
            dSkinCheckBox_AutoHideTitleAndControlPanel.Checked = mainFrm.b_AutoHideTitleAndControlPanel;
            dSkinCheckBox_AutoMatchLocalSubtitle.Checked = mainFrm.b_AutoMatchLocalSubtitle;
            dSkinCheckBox_AutoMatchNetSubtitle.Checked = mainFrm.b_AutoMatchNetSubtitle;
            dSkinCheckBox_UnifyDiffVolumn.Checked = mainFrm.b_UnifyDiffVolumn;
            dSkinCheckBox_EnhanceImageQuality.Checked = mainFrm.b_EnhanceImageQuality;
            dSkinCheckBox_PauseWhileMinimize.Checked = mainFrm.b_PauseWhileMinimize;
            dSkinCheckBox_ShowScreenShotWindow.Checked = mainFrm.b_ShowScreenShotWindow;
            dSkinTrackBar_SoundBalance.Value = mainFrm.n_SoundBalance;
            dSkinTrackBar_HumanVolumn.Value = mainFrm.n_HumanVolumn;
            dSkinTrackBar_Brightness.Value = mainFrm.n_Brightness;
            dSkinTrackBar_Contrast.Value = mainFrm.n_Contrast;
            dSkinTrackBar_Saturation.Value = mainFrm.n_Saturation;
            dSkinTrackBar_Hue.Value = mainFrm.n_Hue;
            dSkinCheckBox_CreateShortcutToDesktop.Checked = Convert.ToBoolean(ini.ReadValue("Settings", "ShowDesktopShortcut"));
            dSkinCheckBox_LockToTaskbar.Checked = Convert.ToBoolean(ini.ReadValue("Settings", "ShowTaskbarShortcut"));
            dSkinTextBox_SavePath.Text = mainFrm.str_ScreenShotPath;
            dSkinCheckBox_ShowAdOnceMore.Checked = mainFrm.b_ShowAdOnceMore;

            dSkinTextBox_BackGround.Text = ini.ReadValue("Settings", "BackGroundImage");

            int nFastForward = Convert.ToInt32(ini.ReadValue("Settings", "FastForward"));
            dSkinComboBox_FastForward.SelectedIndex = nFastForward - 1;
            int nFastBack = Convert.ToInt32(ini.ReadValue("Settings", "FastBack"));
            dSkinComboBox_FastBack.SelectedIndex = nFastBack - 1;

            string str_LinkFile = ini.ReadValue("Settings", "LinkFile");
            string[] str_ArrLinkFile = str_LinkFile.Split(';');
            for (int i = 0; i < str_ArrLinkFile.Length; i++)
            {
                string str_ControlName = str_ArrLinkFile[i];
                if (str_ControlName == "") continue;
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                cb.Checked = true;
            }

            this.EnabledDWM = dSkinCheckBox_EnableDWM.Checked = mainFrm.b_EnableDWM;
            dSkinCheckBox_ImageFuzzy.Checked = mainFrm.b_ImageFuzzy;
            dSkinTrackBar_BackColorOpacity.Value = mainFrm.n_BackColorTransparency;
            dSkinTrackBar_BackImageOpacity.Value = mainFrm.n_BackImageTransparency;
            dSkinTrackBar_MainFrmOpacity.Value = mainFrm.n_MainFrmOpacity;

            dSkinPictureBox_SelectFocusColor.BackColor = mainFrm.FocusColor;
            SetFocusColor(mainFrm.FocusColor); 
        }

        #region 改变窗体背景
        protected override void OnLayeredPaintBackground(PaintEventArgs e)
        {
            base.OnLayeredPaintBackground(e);

            //SetForeColor(this, mainFrm.BackImageCurrent);

            if (mainFrm.BackImageCurrent != null)
            {
                if (mainFrm.n_BackImageTransparency <= 1)
                {
                    return;
                }
                if (mainFrm.n_BackImageTransparency == 100)
                {
                    e.Graphics.DrawImage(mainFrm.BackImageCurrent, 0, 0, this.Width, this.Height);
                    return;
                }
                e.Graphics.DrawImage(mainFrm.BackImageCurrent, new Rectangle(0, 0, this.Width, this.Height),
                    0, 0, mainFrm.BackImageCurrent.Width, mainFrm.BackImageCurrent.Height, GraphicsUnit.Pixel,
                    DSkin.ImageEffects.ChangeOpacity((float)(1.0 * mainFrm.n_BackImageTransparency / 100)));
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }
        #endregion

        private void dSkinCheckBox_EnhanceImageQuality_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_EnhanceImageQuality = dSkinCheckBox_EnhanceImageQuality.Checked;
            mainFrm.axPlayer1.SetConfig(305, mainFrm.b_EnhanceImageQuality == true ? "1" : "0");
            //mainFrm.EnhanceImageQuality();
            //mainFrm.toolStripMenuItem_dEnhanceImage.Checked = dSkinCheckBox_EnhanceImageQuality.Checked;
            mainFrm.CheckEnhanceImageQuality();
        }

        private void dSkinCheckBox_PauseWhileMinimize_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_PauseWhileMinimize = dSkinCheckBox_PauseWhileMinimize.Checked;
        }

        private void dSkinCheckBox_ShowScreenShotWindow_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_ShowScreenShotWindow = dSkinCheckBox_ShowScreenShotWindow.Checked;
        }

        private void dSkinCheckBox_UnifyDiffVolumn_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_UnifyDiffVolumn = dSkinCheckBox_UnifyDiffVolumn.Checked;
            //mainFrm.axPlayer1.SetConfig(406, mainFrm.b_UnifyDiffVolumn == true ? "1" : "0");
            mainFrm.UnifyDiffVolumn();
        }

        private void dSkinComboBox_FastBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.WriteValue("Settings", "FastBack", (dSkinComboBox_FastBack.SelectedIndex + 1).ToString());
        }

        private void dSkinComboBox_FastForward_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.WriteValue("Settings", "FastForward", (dSkinComboBox_FastForward.SelectedIndex + 1).ToString());
        }

        private void dSkinButton_BackGround_Click(object sender, EventArgs e)
        {
            bool bbb = dSkinCheckBox_ImageFuzzy.Checked;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.All Types)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo fl = new System.IO.FileInfo(openFileDialog.FileName);
                if (fl.Length > 1024 * 1024)
                {
                    //System.Windows.Forms.MessageBox.Show("请选择1M以内的横向图片");
                    AuroraMessageBox msg = null;
                    msg = new AuroraMessageBox();
                    msg.strCaption = "Aurora智能提示";
                    msg.strMessage = "请选择1M以内的横向图片";
                    msg.strButtonText = "确定";
                    msg.StartPosition = FormStartPosition.Manual;
                    msg.Location = new Point(this.Location.X + this.Width / 2 - msg.Width / 2, this.Location.Y + this.Height / 2 - msg.Height / 2);
                    msg.ShowDialog();
                    return;
                }
                mainFrm.str_BackGroundImage = dSkinTextBox_BackGround.Text = openFileDialog.FileName;
                mainFrm.SetPlayerBackground();
                mainFrm.ItemHoverColor = SkinTools.GetImageAverageColor(Image.FromFile(openFileDialog.FileName));
                HSL hsl = ColorConverterEx.ColorToHSL(mainFrm.ItemHoverColor);
                //hsl.Luminance += 0.2;
                //if (hsl.Luminance >= 1)
                //    hsl.Luminance = 0.99;
                hsl.Saturation += 0.2;
                if (hsl.Saturation >= 1)
                    hsl.Saturation = 0.99;
                mainFrm.ItemHoverColor = ColorConverterEx.HSLToColor(hsl);
                dSkinCheckBox_ImageFuzzy.Checked = !bbb;
                dSkinCheckBox_ImageFuzzy.Checked = bbb;
                this.Invalidate();
            }
        }

        private void dSkinButton_ClearBackGround_Click(object sender, EventArgs e)
        {
            mainFrm.str_BackGroundImage = dSkinTextBox_BackGround.Text = "";
            mainFrm.SetPlayerBackground();
            this.Invalidate();
        }

        #region 拖动窗体
        private void PnlInfo_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_LinkFile_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void dSkinPanel_General_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Play_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Audio_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Video_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Subtitle_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_BackGround_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }


        private void dSkinPanel_ScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Donate_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Update_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinPanel_Other_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }
        #endregion

        private void dSkinTrackBar_VolumnBalance_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(13, dSkinTrackBar_SoundBalance.Value.ToString());
            mainFrm.n_SoundBalance = dSkinTrackBar_SoundBalance.Value;
        }

        private void dSkinButton_BalanceReset_Click(object sender, EventArgs e)
        {
            dSkinTrackBar_SoundBalance.Value = 50;
            dSkinTrackBar_HumanVolumn.Value = 20;
            dSkinCheckBox_UnifyDiffVolumn.Checked = true;
        }

        private void dSkinTrackBar_HumanVolumn_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(1503, dSkinTrackBar_HumanVolumn.Value.ToString());
            mainFrm.n_HumanVolumn = dSkinTrackBar_HumanVolumn.Value;
        }

        private void dSkinTrackBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(214, dSkinTrackBar_Brightness.Value.ToString());
            mainFrm.n_Brightness = dSkinTrackBar_Brightness.Value;
        }

        private void dSkinTrackBar_Contrast_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(215, dSkinTrackBar_Contrast.Value.ToString());
            mainFrm.n_Contrast = dSkinTrackBar_Contrast.Value;
        }

        private void dSkinTrackBar_Saturation_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(216, dSkinTrackBar_Saturation.Value.ToString());
            mainFrm.n_Saturation = dSkinTrackBar_Saturation.Value;
        }

        private void dSkinTrackBar_Hue_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.axPlayer1.SetConfig(217, dSkinTrackBar_Hue.Value.ToString());
            mainFrm.n_Hue = dSkinTrackBar_Hue.Value;
        }

        private void dSkinButton_ImageReset_Click(object sender, EventArgs e)
        {
            dSkinTrackBar_Brightness.Value = 50;
            dSkinTrackBar_Contrast.Value = 50;
            dSkinTrackBar_Saturation.Value = 50;
            dSkinTrackBar_Hue.Value = 50;
            dSkinCheckBox_EnhanceImageQuality.Checked = false;
        }

        #region 文件关联打钩
        private void dSkinButton_LinkFile_Click(object sender, EventArgs e)
        {
            //LinkFile.SetLink(".rmvb", "Aurora Player.rmvb", Application.StartupPath + "\\Resource\\rmvb.ico", Application.ExecutablePath);
            string str_SetLink = "";
            string str_DelLink = "";
            for (int i = 1; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (cb.Text == "Windows媒体" || cb.Text == "Real媒体" || cb.Text == "MPEG1/2媒体" || cb.Text == "MPEG4媒体" || cb.Text == "3GPP媒体" ||
                        cb.Text == "Apple媒体" || cb.Text == "Flash媒体" || cb.Text == "CD/DVD媒体" || cb.Text == "其它视频文件" || cb.Text == "音频文件" ||
                        cb.Text == "多媒体光碟" || cb.Text == "字幕文件")
                    continue;
                else if (cb.Checked)
                {
                    str_SetLink += cb.Text + ";";
                }
                else if (!cb.Checked)
                {
                    str_DelLink += cb.Text + ";";
                }
            }

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.Arguments = str_SetLink + "-" + str_DelLink;
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.CreateNoWindow = false;
            proc.FileName = Application.StartupPath + "\\Aurora_Player_Assist.exe";
            if (!IsRunAsAdmin())
            {
                // Launch as administrator
                proc.Verb = "runas";
            }
            try
            {
                Process.Start(proc);
            }
            catch
            {
                // The user refused the elevation.
                // Do nothing and return directly ...
                return;
            }

            string str_LinkFile = "";
            for (int i = 1; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (cb.Checked)
                {
                    str_LinkFile += str_ControlName + ";";
                }
            }
            ini.WriteValue("Settings", "LinkFile", str_LinkFile);

            //for (int i = 1; i <= 114; i++)
            //{
            //    string str_ControlName = "dSkinCheckBox" + i.ToString();
            //    DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
            //    if (cb.Text == "Windows媒体" || cb.Text == "Real媒体" || cb.Text == "MPEG1/2媒体" || cb.Text == "MPEG4媒体" || cb.Text == "3GPP媒体" ||
            //        cb.Text == "Apple媒体" || cb.Text == "Flash媒体" || cb.Text == "CD/DVD媒体" || cb.Text == "其它视频文件" || cb.Text == "音频文件" ||
            //        cb.Text == "多媒体光碟" || cb.Text == "字幕文件")
            //        continue;
            //    else if(cb.Checked)
            //    {
            //        string str_temp = cb.Text.Replace(".", "");
            //        string str_ico = Application.StartupPath + "\\Resource\\" + str_temp + ".ico";
            //        if (!System.IO.File.Exists(str_ico))
            //            str_ico = Application.StartupPath + "\\Resource\\movies_256x256.ico"; ;
            //        LinkFile.SetLink(cb.Text, "Aurora Player" + cb.Text, str_ico, Application.ExecutablePath);
            //    }
            //    else if(!cb.Checked)
            //    {
            //        LinkFile.DelLink("Aurora Player" + cb.Text);
            //    }
            //}
        }

        private void dSkinButton_SelectAll_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                cb.Checked = true;
            }
        }

        private void dSkinButton_SelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                cb.Checked = false;
            }
        }

        private void dSkinButton_SelevtVideo_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 73; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (!b_SelectVideo)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
            if (!b_SelectVideo)
            {
                dSkinCheckBox102.Checked = true;
                dSkinCheckBox103.Checked = true;
            }
            else
            {
                dSkinCheckBox102.Checked = false;
                dSkinCheckBox103.Checked = false;
            }
            b_SelectVideo = !b_SelectVideo;
        }

        private void dSkinButton_SelectAudio_Click(object sender, EventArgs e)
        {
            for (int i = 74; i <= 101; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (!b_SelectAudio)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
            b_SelectAudio = !b_SelectAudio;
        }

        private void dSkinButton_SelectSubtitle_Click(object sender, EventArgs e)
        {
            for (int i = 104; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if(!b_SelectSubtitle)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
            b_SelectSubtitle = !b_SelectSubtitle;
        }

        private void dSkinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 2; i <= 6; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if(dSkinCheckBox1.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 8; i <= 15; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox7.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 17; i <= 33; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox16.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox34_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 35; i <= 40; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox34.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox41_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 42; i <= 45; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox41.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox46_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 47; i <= 48; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox46.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox49_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 50; i <= 53; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox49.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox54_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 55; i <= 56; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox54.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox57_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 58; i <= 73; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox57.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox74_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 75; i <= 101; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox74.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }

        private void dSkinCheckBox102_CheckedChanged(object sender, EventArgs e)
        {
            if (dSkinCheckBox102.Checked)
                dSkinCheckBox103.Checked = true;
            else
                dSkinCheckBox103.Checked = false;
        }

        private void dSkinCheckBox104_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 105; i <= 114; i++)
            {
                string str_ControlName = "dSkinCheckBox" + i.ToString();
                DSkinCheckBox cb = (DSkinCheckBox)this.dSkinPanel_LinkFile.Controls.Find(str_ControlName, false)[0];
                if (dSkinCheckBox104.Checked)
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }
        #endregion

        private void dSkinCheckBox_CreateShortcutToDesktop_CheckedChanged(object sender, EventArgs e)
        {
            CommandHelper.CreateShortcutToDesktop(dSkinCheckBox_CreateShortcutToDesktop.Checked);
            if(dSkinCheckBox_CreateShortcutToDesktop.Checked)
                ini.WriteValue("Settings", "ShowDesktopShortcut", "true");
            else
                ini.WriteValue("Settings", "ShowDesktopShortcut", "false");
        }

        private void dSkinCheckBox_LockToTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            CommandHelper.LockToTaskbar(dSkinCheckBox_LockToTaskbar.Checked);
            if (dSkinCheckBox_LockToTaskbar.Checked)
                ini.WriteValue("Settings", "ShowTaskbarShortcut", "true");
            else
                ini.WriteValue("Settings", "ShowTaskbarShortcut", "false");
        }

        private void dSkinTrackBar_BackImageOpacity_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.n_BackImageTransparency = dSkinTrackBar_BackImageOpacity.Value;
            this.Invalidate();
        }

        private void dSkinTrackBar_BackColorOpacity_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.n_BackColorTransparency = dSkinTrackBar_BackColorOpacity.Value;
            this.BackColor = Color.FromArgb(dSkinTrackBar_BackColorOpacity.Value, this.BackColor);
        }

        private void dSkinTrackBar_MainFrmOpacity_ValueChanged(object sender, EventArgs e)
        {
            mainFrm.n_MainFrmOpacity = dSkinTrackBar_MainFrmOpacity.Value;
            mainFrm.Opacity = dSkinTrackBar_MainFrmOpacity.Value / 100.0;
        }

        private void dSkinCheckBox_EnableDWM_CheckedChanged(object sender, EventArgs e)
        {
            //((DSkinForm)this.Owner).EnabledDWM = dSkinCheckBox_EnableDWM.Checked;
            this.EnabledDWM = dSkinCheckBox_EnableDWM.Checked;
            mainFrm.b_EnableDWM = dSkinCheckBox_EnableDWM.Checked; ;
        }

        private void dSkinCheckBox_ImageFuzzy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dSkinCheckBox_ImageFuzzy.Checked)
                {
                    mainFrm.BackImageCurrent = (Bitmap)((MainForm)this.Owner).BackImage.Clone();
                    Rectangle rect = new Rectangle(0, 0, mainFrm.BackImageCurrent.Width, mainFrm.BackImageCurrent.Height);
                    DSkin.ImageEffects.GaussianBlur(mainFrm.BackImageCurrent, ref rect, 20, false);
                    //DSkin.ImageEffects.MaSaiKe(mainFrm.BackImageCurrent, 20);

                    Bitmap bt = (Bitmap)((MainForm)this.Owner).BackImage.Clone();
                    Rectangle rect1 = new Rectangle(0, 0, mainFrm.BackImageCurrent.Width, mainFrm.BackImageCurrent.Height);
                    DSkin.ImageEffects.GaussianBlur(bt, ref rect1, 20, false);
                    //DSkin.ImageEffects.MaSaiKe(mainFrm.BackImageCurrent, 20);
                }
                else
                {
                    mainFrm.BackImageCurrent = mainFrm.BackImage;
                    //this.BackgroundImage = mainFrm.BackImage;
                }
                this.Invalidate();
                mainFrm.b_ImageFuzzy = dSkinCheckBox_ImageFuzzy.Checked;
            }
            catch { }
        }

        private void dSkinPictureBox_SelectFocusColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowHelp = false;
            cd.FullOpen = true;
            cd.Color = mainFrm.FocusColor;
            cd.CustomColors = new int[] { 173239, 6916092, 15195440, 16107657, 1836924, 3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, 3102017, 7324121, 14993507, 11730944 };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                dSkinPictureBox_SelectFocusColor.BackColor = cd.Color;
                mainFrm.FocusColor = cd.Color;
                SetFocusColor(cd.Color);
            }
        }

        //设置Aurora焦点色
        public void SetFocusColor(Color color)
        {
            DSkinTextureBrush dbrush = new DSkinTextureBrush();
            dbrush.Brush = new SolidBrush(color);
            foreach (DSkinTrackBar tb in TrackBars)
            {
                tb.PointButtonNormalColor = tb.PointButtonHoverColor = tb.PointButtonBorderColor = color;
                tb.MainLineBrushUp = dbrush;
            }
            foreach(DSkinCheckBox cb in CheckBoxs)
            {
                cb.CheckFlagColor = color;
            }

            TipFrm tip = mainFrm.TipPanel;
            tip.dSkinLabel_Tip.ForeColor = color;

            ControlFrm ctl = mainFrm.ControlPanel;
            ctl.SetFocusColor();

            mainFrm.BackColor = color;
            mainFrm.PlayListPanel.dSkinTabControl1.SelectedBackColors[1] = color;

            mainFrm.dSkinContextMenuStrip1.ItemHover = mainFrm.ItemHoverColor;
            mainFrm.PlayListPanel.dSkinContextMenuStrip_LocalList.ItemHover = mainFrm.PlayListPanel.dSkinContextMenuStrip_TV.ItemHover = mainFrm.ItemHoverColor;
        }

        internal bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void dSkinButton_SelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                mainFrm.str_ScreenShotPath = dSkinTextBox_SavePath.Text = folderBrowserDialog1.DirectoryPath;
                ini.WriteValue("Settings", "ScreenShotPath", dSkinTextBox_SavePath.Text);
            }
        }

        #region Other
        private void dSkinCheckBox_IncludeSubDir_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_IncludeSubDir = dSkinCheckBox_IncludeSubDir.Checked;
        }

        private void dSkinCheckBox_ControlFrmTransparent_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_ControlFrmTransparent = dSkinCheckBox_ControlFrmTransparent.Checked;
        }

        private void dSkinCheckBox_AutoHideTitleAndControlPanel_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_AutoHideTitleAndControlPanel = dSkinCheckBox_AutoHideTitleAndControlPanel.Checked;

        }
        #endregion

        #region Subtitle
        private void dSkinCheckBox_AutoMatchLocalSubtitle_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_AutoMatchLocalSubtitle = dSkinCheckBox_AutoMatchLocalSubtitle.Checked;
        }
        
        private void dSkinCheckBox_AutoMatchNetSubtitle_CheckedChanged(object sender, EventArgs e)
        {
            mainFrm.b_AutoMatchNetSubtitle = dSkinCheckBox_AutoMatchNetSubtitle.Checked;
        }
        #endregion

        private void duiScrollBar_LinkFile_ValueChanged(object sender, EventArgs e)
        {
            dSkinPanel_LinkFile.VerticalScroll.Value = duiScrollBar_LinkFile.Value;
        }

        #region Donate
        private void dSkinPictureBox_Donate_Click(object sender, EventArgs e)
        {
            mainFrm.CallDonate();
        }

        private void dSkinCheckBox_EnableShowAd_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteValue("Settings", "ShowAdOnceMore", (dSkinCheckBox_ShowAdOnceMore.Checked).ToString());
        }


        #endregion

        private void dSkinButton_CheckUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\AuroraUpdate.exe");
        }

    }
}