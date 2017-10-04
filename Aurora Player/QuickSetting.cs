using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.DirectUI;
using DSkin.Controls;

namespace Aurora_Player
{
    public partial class QuickSetting : DSkinForm
    {
        public QuickSetting(string str_Type)
        {
            InitializeComponent();
            if(str_Type == "Subtitle")
                dSkinTabControl1.SelectedTab = dSkinTabPage_Subtitle;
            else if (str_Type == "Video")
                dSkinTabControl1.SelectedTab = dSkinTabPage_Video;
            else if (str_Type == "Audio")
                dSkinTabControl1.SelectedTab = dSkinTabPage_Audio;
        }

        MainForm mainfrm;

        private void QuickSetting_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;

            dSkinComboBox_Channel.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_Output.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_Scale.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_SubtilteList.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_SubtitleFontSize.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_SubtitleFont.InnerListBox.InnerScrollBar.Fillet = true;
            dSkinComboBox_Track.InnerListBox.InnerScrollBar.Fillet = true;
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
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            SetFocusColor(mainfrm.FocusColor);

            dSkinComboBox_SubtilteList.AddItem(Path.GetFileName(mainfrm.axPlayer1.GetConfig(503)));
            dSkinComboBox_SubtilteList.SelectedIndex = Convert.ToInt32(mainfrm.axPlayer1.GetConfig(506));

            for (int i = 1; i <= 88; i++)
            {
                dSkinComboBox_SubtitleFontSize.AddItem(i.ToString("#00"));
            }
            dSkinComboBox_SubtitleFontSize.SelectedIndex = mainfrm.n_FontSize - 1;
            dSkinComboBox_SubtitleFont.AddItem("宋体"); dSkinComboBox_SubtitleFont.AddItem("黑体"); dSkinComboBox_SubtitleFont.AddItem("楷体");
            dSkinComboBox_SubtitleFont.AddItem("幼圆"); dSkinComboBox_SubtitleFont.AddItem("隶书"); dSkinComboBox_SubtitleFont.AddItem("宋体");
            for(int j = 0; j < dSkinComboBox_SubtitleFont.Items.Count; j++)
            {
                if (dSkinComboBox_SubtitleFont.Items[j].Text == mainfrm.str_Font)
                    dSkinComboBox_SubtitleFont.SelectedIndex = j;
            }

            dSkinLabel_SubtitleFontColor.ForeColor = mainfrm.SubtitleColor;
            dSkinTextBox_SubtitleDelayTime.Text = (mainfrm.n_SubtitleDelay / 1000.0).ToString("#0.0");

            string tmp = mainfrm.axPlayer1.GetConfig(507);
            string tt = tmp.Substring(tmp.LastIndexOf(';') + 1);
            dSkinTrackBar_SubtitlePosition.Value = 100 - Convert.ToInt32(tt);


            dSkinTrackBar_Brightness.Value = mainfrm.n_Brightness;
            dSkinTrackBar_Contrast.Value = mainfrm.n_Contrast;
            dSkinTrackBar_Saturation.Value = mainfrm.n_Saturation;
            dSkinTrackBar_Hue.Value = mainfrm.n_Hue;
            dSkinCheckBox_EnhanceImageQuality.Checked = mainfrm.b_EnhanceImageQuality;
            dSkinComboBox_Scale.AddItem("原始比例"); dSkinComboBox_Scale.AddItem("4:3");
            dSkinComboBox_Scale.AddItem("16:9"); dSkinComboBox_Scale.AddItem("2.35:1");
            dSkinComboBox_Scale.AddItem("21:9");
            for (int i = 0; i < dSkinComboBox_Scale.Items.Count; i++)
            {
                string ss = dSkinComboBox_Scale.Items[i].Text.Replace(":", ";");
                if (ss == mainfrm.axPlayer1.GetConfig(203))
                {
                    dSkinComboBox_Scale.SelectedIndex = i;
                    break;
                }
            }


            dSkinComboBox_Channel.AddItem("原始声道"); dSkinComboBox_Channel.AddItem("左声道");
            dSkinComboBox_Channel.AddItem("右声道"); dSkinComboBox_Channel.AddItem("左右混合声道");
            for (int i = 0; i < dSkinComboBox_Channel.Items.Count; i++)
            {
                if (i.ToString() == mainfrm.axPlayer1.GetConfig(404))
                    dSkinComboBox_Channel.SelectedIndex = i;
            }

            dSkinComboBox_Output.AddItem("单声道"); dSkinComboBox_Output.AddItem("立体声");
            dSkinComboBox_Output.AddItem("5.1声道"); dSkinComboBox_Output.AddItem("SPDIF声道");
            for (int i = 0; i < dSkinComboBox_Output.Items.Count; i++)
            {
                if (i == (Convert.ToInt32(mainfrm.axPlayer1.GetConfig(1502)) - 1))
                {
                    dSkinComboBox_Output.SelectedIndex = i;
                    break;
                }
            }

            dSkinCheckBox_UnifyDiffVolumn.Checked = mainfrm.b_UnifyDiffVolumn;
            dSkinTextBox_DelayTime_Audio.Text = (mainfrm.n_AudioDelay / 1000.0).ToString("#0.0");

            string str_CurretSoundTrackIndex = mainfrm.axPlayer1.GetConfig(403);
            string str_AllSoundTrackList = mainfrm.axPlayer1.GetConfig(402);
            if (str_AllSoundTrackList != "")
            {
                string[] str_Arr = str_AllSoundTrackList.Split(';');
                for (int i = 0; i < str_Arr.Length; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(str_Arr[i]);
                    if (dSkinComboBox_Track.Items.Count == str_Arr.Length)
                        continue;
                    else
                    {
                        dSkinComboBox_Track.AddItem(str_Arr[i]);
                    }
                }
                for (int i = 0; i < dSkinComboBox_Track.Items.Count; i++)
                {
                    if (i.ToString() == mainfrm.axPlayer1.GetConfig(403))
                        dSkinComboBox_Track.SelectedIndex = i;
                }
            }
        }

        private void QuickSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainfrm.OverLayMainFrm(false);
        }

        private void SetFocusColor(Color color)
        {
            dSkinTabControl1.SelectedBackColors[1] = mainfrm.FocusColor;
            dSkinCheckBox_UnifyDiffVolumn.CheckFlagColor = mainfrm.FocusColor;
            dSkinCheckBox_EnhanceImageQuality.CheckFlagColor = mainfrm.FocusColor;

            DSkinTextureBrush dbrush = new DSkinTextureBrush();
            dbrush.Brush = new SolidBrush(color);
            dSkinTrackBar_SubtitlePosition.PointButtonNormalColor = dSkinTrackBar_SubtitlePosition.PointButtonHoverColor = dSkinTrackBar_SubtitlePosition.PointButtonBorderColor = color;
            dSkinTrackBar_SubtitlePosition.MainLineBrushUp = dbrush;
            dSkinTrackBar_Brightness.PointButtonNormalColor = dSkinTrackBar_Brightness.PointButtonHoverColor = dSkinTrackBar_Brightness.PointButtonBorderColor = color;
            dSkinTrackBar_Brightness.MainLineBrushUp = dbrush;
            dSkinTrackBar_Contrast.PointButtonNormalColor = dSkinTrackBar_Contrast.PointButtonHoverColor = dSkinTrackBar_Contrast.PointButtonBorderColor = color;
            dSkinTrackBar_Contrast.MainLineBrushUp = dbrush;
            dSkinTrackBar_Saturation.PointButtonNormalColor = dSkinTrackBar_Saturation.PointButtonHoverColor = dSkinTrackBar_Saturation.PointButtonBorderColor = color;
            dSkinTrackBar_Saturation.MainLineBrushUp = dbrush;
            dSkinTrackBar_Hue.PointButtonNormalColor = dSkinTrackBar_Hue.PointButtonHoverColor = dSkinTrackBar_Hue.PointButtonBorderColor = color;
            dSkinTrackBar_Hue.MainLineBrushUp = dbrush;
        }

        private void dSkinTabPage_Subtitle_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinTabPage_Video_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        private void dSkinTabPage_Audio_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
        }

        #region 字幕
        private void dSkinButton_LoadSubtitle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "字幕文件(*.字幕文件)|" + mainfrm.str_Subtitle_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainfrm.axPlayer1.SetConfig(504, "1");
                mainfrm.axPlayer1.SetConfig(503, openFileDialog.FileName.ToString());
                mainfrm.ShowTips("成功载入字幕");
            }

            dSkinComboBox_SubtilteList.AddItem(Path.GetFileName(openFileDialog.FileName.ToString()));
            dSkinComboBox_SubtilteList.SelectedIndex = 1;
        }

        private void dSkinComboBox_SubtitleFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = mainfrm.n_FontSize;
            n = Convert.ToInt32( dSkinComboBox_SubtitleFontSize.Text);
            mainfrm.axPlayer1.SetConfig(508, mainfrm.str_Font + ";" + n.ToString() + ";" + ColorHelper.RGBtoInt(mainfrm.SubtitleColor).ToString() + ";1");
            mainfrm.n_FontSize = n;
        }

        private void dSkinComboBox_SubtitleFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = mainfrm.n_FontSize;
            mainfrm.str_Font = dSkinComboBox_SubtitleFont.Text;
            mainfrm.axPlayer1.SetConfig(508, mainfrm.str_Font + ";" + n.ToString() + ";" + ColorHelper.RGBtoInt(mainfrm.SubtitleColor).ToString() + ";1");
        }

        private void dSkinLabel_SubtitleFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowHelp = false;
            cd.FullOpen = true;
            cd.Color = mainfrm.SubtitleColor;
            cd.CustomColors = new int[] { 173239, 6916092, 15195440, 16107657, 1836924, 3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, 3102017, 7324121, 14993507, 11730944 };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                dSkinLabel_SubtitleFontColor.ForeColor = cd.Color;
                mainfrm.axPlayer1.SetConfig(508, mainfrm.str_Font + ";" + mainfrm.n_FontSize.ToString() + ";" + ColorHelper.RGBtoInt(cd.Color).ToString() + ";1");
                mainfrm.SubtitleColor = cd.Color;
            }
        }

        private void dSkinButton_SubtitleDelayReset_Click(object sender, EventArgs e)
        {
            mainfrm.n_SubtitleDelay = 0;
            dSkinTextBox_SubtitleDelayTime.Text = "0";
            mainfrm.axPlayer1.SetConfig(509, "0;1000;1000");
        }

        private void dSkinButton_SubtitleDelayNegtive_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_SubtitleDelay;
            n -= 100;
            dSkinTextBox_SubtitleDelayTime.Text = (n / 1000.0).ToString("#0.0");
            mainfrm.axPlayer1.SetConfig(509, (n * -1).ToString() + ";1000;1000");
            mainfrm.n_SubtitleDelay = n;
        }

        private void dSkinButton_SubtitleDelayPositive_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_SubtitleDelay;
            n += 100;
            dSkinTextBox_SubtitleDelayTime.Text = (n / 1000.0).ToString("#0.0");
            mainfrm.axPlayer1.SetConfig(509, (n * -1).ToString() + ";1000;1000");
            mainfrm.n_SubtitleDelay = n;
        }

        private void dSkinTextBox_SubtitleDelayTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = mainfrm.n_SubtitleDelay = (int)Convert.ToDouble(dSkinTextBox_SubtitleDelayTime.Text) * -1000;
                mainfrm.axPlayer1.SetConfig(509, n.ToString() + ";1000;1000");
            }
            catch { }
        }

        private void dSkinTextBox_SubtitleDelayTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && this.dSkinTextBox_SubtitleDelayTime.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 127))
            {
                e.Handled = true;
            }
        }

        private void dSkinTrackBar_SubtitlePosition_ValueChanged(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(507, "1;50;" + (100 - dSkinTrackBar_SubtitlePosition.Value).ToString());
        }

        #endregion

        #region 画面
        private void dSkinTrackBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(214, dSkinTrackBar_Brightness.Value.ToString());
            mainfrm.n_Brightness = dSkinTrackBar_Brightness.Value;
        }

        private void dSkinTrackBar_Contrast_ValueChanged(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(215, dSkinTrackBar_Contrast.Value.ToString());
            mainfrm.n_Contrast = dSkinTrackBar_Contrast.Value;
        }

        private void dSkinTrackBar_Saturation_ValueChanged(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(216, dSkinTrackBar_Saturation.Value.ToString());
            mainfrm.n_Saturation = dSkinTrackBar_Saturation.Value;
        }

        private void dSkinTrackBar_Hue_ValueChanged(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(217, dSkinTrackBar_Hue.Value.ToString());
            mainfrm.n_Hue = dSkinTrackBar_Hue.Value;
        }

        private void dSkinComboBox_Scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dSkinComboBox_Scale.Text == "原始比例")
                mainfrm.axPlayer1.SetConfig(204, mainfrm.axPlayer1.GetConfig(203));
            else if (dSkinComboBox_Scale.Text == "4:3")
                mainfrm.axPlayer1.SetConfig(204, "4:3");
            else if (dSkinComboBox_Scale.Text == "16:9")
                mainfrm.axPlayer1.SetConfig(204, "16:9");
            else if (dSkinComboBox_Scale.Text == "2.35:1")
                mainfrm.axPlayer1.SetConfig(204, "2.35:1");
            else if (dSkinComboBox_Scale.Text == "21:9")
                mainfrm.axPlayer1.SetConfig(204, "21:9");

            mainfrm.str_CustomVideoScale = dSkinComboBox_Scale.Text;
        }

        private void dSkinButton_Clockwise_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_RotateAngle;
            n += 90;
            mainfrm.Rotate(n.ToString());
            mainfrm.n_RotateAngle = n;
        }

        private void dSkinButton_Eastern_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_RotateAngle;
            n -= 90;
            mainfrm.Rotate(n.ToString());
            mainfrm.n_RotateAngle = n;
        }

        private void dSkinCheckBox_EnhanceImageQuality_CheckedChanged(object sender, EventArgs e)
        {
            mainfrm.b_EnhanceImageQuality = dSkinCheckBox_EnhanceImageQuality.Checked;
            mainfrm.axPlayer1.SetConfig(305, mainfrm.b_EnhanceImageQuality == true ? "1" : "0");
            //mainFrm.EnhanceImageQuality();
            //mainfrm.toolStripMenuItem_dEnhanceImage.Checked = dSkinCheckBox_EnhanceImageQuality.Checked;
            mainfrm.CheckEnhanceImageQuality();
        }

        private void dSkinButton_ImageReset_Click(object sender, EventArgs e)
        {
            dSkinTrackBar_Brightness.Value = 50;
            dSkinTrackBar_Contrast.Value = 50;
            dSkinTrackBar_Saturation.Value = 50;
            dSkinTrackBar_Hue.Value = 50;
            dSkinCheckBox_EnhanceImageQuality.Checked = false;
            dSkinComboBox_Scale.SelectedIndex = 0;

            mainfrm.n_RotateAngle = 0;
            mainfrm.Rotate("0");
        }
        #endregion

        #region 声音
        private void dSkinComboBox_Channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainfrm.axPlayer1.GetConfig(401) == "1")
            {
                mainfrm.axPlayer1.SetConfig(404, dSkinComboBox_Channel.SelectedIndex.ToString());
            }
            else
                mainfrm.ShowTips("声音处理功能暂不可用");
        }

        private void dSkinComboBox_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainfrm.axPlayer1.GetConfig(1501) == "1")
            {
                mainfrm.axPlayer1.SetConfig(1502, (dSkinComboBox_Output.SelectedIndex + 1).ToString());
            }
        }

        private void dSkinComboBox_Track_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainfrm.axPlayer1.GetConfig(401) == "1")
            {
                mainfrm.axPlayer1.SetConfig(403, dSkinComboBox_Track.SelectedIndex.ToString());
            }
            else
                mainfrm.ShowTips("声音处理功能暂不可用");
        }

        private void dSkinButton_ImportAudio_Click(object sender, EventArgs e)
        {
            //载入外部音轨
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "音频文件(*.音频文件)|" + mainfrm.str_Audio_filter + "|所有文件(*.所有文件)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainfrm.axPlayer1.SetConfig(409, openFileDialog.FileName);
                dSkinComboBox_Track.AddItem(Path.GetFileNameWithoutExtension(openFileDialog.FileName));
                mainfrm.axPlayer1.SetConfig(403, (dSkinComboBox_Track.Items.Count - 1).ToString());
                mainfrm.ShowTips("成功载入音轨");
            }
        }

        private void dSkinButton_DelayNegtive_Audio_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_AudioDelay;
            n -= 100;
            dSkinTextBox_DelayTime_Audio.Text = (n / 1000.0).ToString("#0.0");
            mainfrm.axPlayer1.SetConfig(405, (n * -1).ToString());
            mainfrm.n_AudioDelay = n;
        }

        private void dSkinTextBox_DelayTime_Audio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = mainfrm.n_AudioDelay = (int)Convert.ToDouble(dSkinTextBox_DelayTime_Audio.Text) * -1000;
                mainfrm.axPlayer1.SetConfig(405, n.ToString());
            }
            catch { }
        }

        private void dSkinTextBox_DelayTime_Audio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && this.dSkinTextBox_DelayTime_Audio.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 127))
            {
                e.Handled = true;
            }
        }

        private void dSkinButton_DelayPositive_Audio_Click(object sender, EventArgs e)
        {
            int n = mainfrm.n_AudioDelay;
            n += 100;
            dSkinTextBox_DelayTime_Audio.Text = (n / 1000.0).ToString("#0.0");
            mainfrm.axPlayer1.SetConfig(405, (n * -1).ToString());
            mainfrm.n_AudioDelay = n;
        }

        private void dSkinButton_ResetAudio_Click(object sender, EventArgs e)
        {
            mainfrm.n_AudioDelay = 0;
            dSkinTextBox_DelayTime_Audio.Text = "0";
            mainfrm.axPlayer1.SetConfig(405, "0");
        }

        private void dSkinCheckBox_UnifyDiffVolumn_CheckedChanged(object sender, EventArgs e)
        {
            mainfrm.b_UnifyDiffVolumn = dSkinCheckBox_UnifyDiffVolumn.Checked;
            mainfrm.UnifyDiffVolumn();
        }
        #endregion

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
