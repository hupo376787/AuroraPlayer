using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class ScreenShot : DSkinForm
    {
        public ScreenShot()
        {
            InitializeComponent();
        }

        MainForm mainfrm;
        IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");
        string str_FilePathName = "";
        Image img = null;

        private void ScreenShot_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //this.BackgroundImage = mainform.BackImageCurrent;
            dSkinComboBox_FileType.AddItem("jpg");
            dSkinComboBox_FileType.AddItem("bmp");
            dSkinComboBox_FileType.AddItem("png");
            dSkinComboBox_FileType.SelectedIndex = 0;
            dSkinComboBox_FileType.InnerListBox.ScrollBarWidth = 11;
            dSkinComboBox_FileType.InnerListBox.InnerScrollBar.Fillet = true;

            if (mainfrm.str_ScreenShotPath == "")
                dSkinTextBox_SavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            else
                dSkinTextBox_SavePath.Text = mainfrm.str_ScreenShotPath;
            GetScreenShot();
            img = Image.FromFile(str_FilePathName);
            dSkinLabel_Tip.BackColor = Color.Transparent;
            dSkinLabel_Tip.ForeColor = Color.Yellow;
            dSkinLabel_Tip.Text = "图像分辨率：" + mainfrm.axPlayer1.GetVideoWidth().ToString() + " x " + mainfrm.axPlayer1.GetVideoHeight().ToString();
            dSkinLabel_Tip.Location = new Point(dSkinPictureBox_Preview.Location.X + 10, dSkinPictureBox_Preview.Location.Y + 10);
            dSkinPictureBox_Preview.SizeMode = PictureBoxSizeMode.Zoom;
            dSkinPictureBox_Preview.Image = img;
            dSkinCheckBox_NoShowWindow.CheckFlagColor = mainfrm.FocusColor;
        }

        private void GetScreenShot()
        {
            //str_FilePathName = Application.StartupPath + "\\" + Path.GetFileNameWithoutExtension(mainfrm.axPlayer1.GetConfig(4))
            //    + "-" + DateTime.Now.ToString("yyyymmddhhmmss") + "." + mainfrm.str_ScreenShotType;
            str_FilePathName = Application.StartupPath + "\\" + mainfrm.TitleBarPanel.Text
                + "-" + DateTime.Now.ToString("yyyymmddhhmmss") + "." + mainfrm.str_ScreenShotType;
            mainfrm.axPlayer1.SetConfig(708, "90");
            mainfrm.axPlayer1.SetConfig(702, str_FilePathName);
        }

        private void ScreenShot_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                img.Dispose();
                File.Delete(str_FilePathName);
            }
            catch { }
        }

        private void dSkinButton_SelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                mainfrm.str_ScreenShotPath = dSkinTextBox_SavePath.Text = folderBrowserDialog1.DirectoryPath;
                ini.WriteValue("Settings", "ScreenShotPath", dSkinTextBox_SavePath.Text);
            }
        }

        private void dSkinButton_Save_Click(object sender, EventArgs e)
        {
            string tmp = mainfrm.str_ScreenShotPath + "\\" + mainfrm.TitleBarPanel.Text
                    + "-" + DateTime.Now.ToString("yyyymmddhhmmss") + "." + mainfrm.str_ScreenShotType;
            img.Save(tmp);
            //File.Copy(str_FilePathName, tmp, true);
            dSkinLabel_Tip.Text = "已保存至：" + tmp;
        }

        private void dSkinButton_CopytoClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(img);
            dSkinLabel_Tip.Text = "已复制到剪切板";
        }

        private void dSkinComboBox_FileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dSkinComboBox_FileType.SelectedIndex;
            mainfrm.str_ScreenShotType = dSkinComboBox_FileType.Items[index].Text;
        }

        private void dSkinCheckBox_NoShowWindow_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteValue("Settings", "ShowScreenShotWindow", dSkinCheckBox_NoShowWindow.Checked == true ? "False" : "True");
            mainfrm.b_ShowScreenShotWindow = !dSkinCheckBox_NoShowWindow.Checked;
        }

        private void dSkinPictureBox_Preview_MouseDown(object sender, MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
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

        private void dSkinTextBox_SavePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
