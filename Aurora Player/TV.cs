using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class TV : DSkinForm
    {
        public TV()
        {
            InitializeComponent();
            duiTextBox_TVUrl.Focus();
        }

        MainForm mainfrm;
        IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");

        private void TV_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //this.BackgroundImage = main.BackImageCurrent;

            //dSkinContextMenuStrip1.BackgroundImage = this.BackgroundImage;
            //dSkinContextMenuStrip1.BackgroundImageLayout = ImageLayout.Stretch;
            //dSkinContextMenuStrip1.ItemSplitter = mainfrm.FocusColor;
            //dSkinContextMenuStrip1.ItemHover = mainfrm.FocusColor;

            dSkinContextMenuStrip1.ItemHover = mainfrm.ItemHoverColor;
        }

        private void dSkinButton_GO_Click(object sender, EventArgs e)
        {
            if(!InternetHelper.IsHostAlive())
            {
                mainfrm.ShowTips("哦哦，Aurora 未检测到有网络连接");
                return;
            }

            mainfrm.axPlayer1.Close();
            mainfrm.b_PlayTV = true;
            mainfrm.axPlayer1.Open(duiTextBox_TVUrl.Text.Trim());
            //mainfrm.ResetControlPanel();
            //mainfrm.AfterOpenFile();
            mainfrm.ResetControlPanel();
            //mainfrm.Text = "Aurora Player";
            mainfrm.str_NowPlaying = duiTextBox_TVUrl.Text.Trim();
            mainfrm.ShowTips("正在播放:" + duiTextBox_TVUrl.Text.Trim());
            mainfrm.TitleBarPanel.Text = "Aurora Player";
            ini.WriteValue("Settings", "LastTVUrl", duiTextBox_TVUrl.Text.Trim());
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

        private void TV_Shown(object sender, EventArgs e)
        {
            duiTextBox_TVUrl.Text = ini.ReadValue("Settings", "LastTVUrl");
        }

        private void toolStripMenuItem_Undo_Click(object sender, EventArgs e)
        {
            duiTextBox_TVUrl.Undo();
        }

        private void toolStripMenuItem_Cut_Click(object sender, EventArgs e)
        {
            try
            {
                if (duiTextBox_TVUrl.SelectedText != "")
                {
                    Clipboard.SetDataObject(duiTextBox_TVUrl.SelectedText);
                    duiTextBox_TVUrl.Text = duiTextBox_TVUrl.Text.Replace(duiTextBox_TVUrl.SelectedText, "");
                }
                else
                {
                    Clipboard.SetDataObject(duiTextBox_TVUrl.Text);
                    duiTextBox_TVUrl.Text = "";
                }
            }
            catch { }
        }

        private void toolStripMenuItem_Copy_Click(object sender, EventArgs e)
        {
            if (duiTextBox_TVUrl.SelectedText != "")
                Clipboard.SetDataObject(duiTextBox_TVUrl.SelectedText);
            else
                Clipboard.SetDataObject(duiTextBox_TVUrl.Text);
        }

        private void toolStripMenuItem_Paste_Click(object sender, EventArgs e)
        {
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    if (duiTextBox_TVUrl.SelectedText != "")
                    {
                        SendKeys.Send("^v");
                    }
                    else
                    {
                        if (duiTextBox_TVUrl.CaretIndex != duiTextBox_TVUrl.Text.Length)
                            duiTextBox_TVUrl.Text = duiTextBox_TVUrl.Text.Substring(0, duiTextBox_TVUrl.CaretIndex) +
                            (String)iData.GetData(DataFormats.Text) + duiTextBox_TVUrl.Text.Substring(duiTextBox_TVUrl.CaretIndex + 1);
                        else
                            duiTextBox_TVUrl.Text = duiTextBox_TVUrl.Text.Substring(0, duiTextBox_TVUrl.CaretIndex) + (String)iData.GetData(DataFormats.Text);
                    }
                }
            }
            catch { }
        }

        private void toolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (duiTextBox_TVUrl.SelectedText != "")
                    duiTextBox_TVUrl.Text = duiTextBox_TVUrl.Text.Replace(duiTextBox_TVUrl.SelectedText, "");
                else
                    duiTextBox_TVUrl.Text = "";
            }
            catch { }
        }

        private void toolStripMenuItem_All_Click(object sender, EventArgs e)
        {
            duiTextBox_TVUrl.SelectAll();
        }

        private void duiTextBox_TVUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dSkinButton_GO_Click(sender, e);
        }

        private void duiButton_Clear_MouseDown(object sender, DSkin.DirectUI.DuiMouseEventArgs e)
        {
            duiTextBox_TVUrl.Text = "";
        }

        private void toolStripMenuItem_DelPasteGo_Click(object sender, EventArgs e)
        {
            duiTextBox_TVUrl.Text = "";
            SendKeys.Send("^v");
            dSkinButton_GO_Click(sender, e);
        }
    }
}
