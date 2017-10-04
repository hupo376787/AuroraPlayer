using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;

namespace Aurora_Player
{
    public partial class VR : DSkinForm
    {
        public VR()
        {
            InitializeComponent();
        }

        MainForm mainfrm;

        private Color EnterUpColor = Color.LightBlue;
        private Color TransColor = Color.Transparent;
        private Color DownColor = Color.SkyBlue;

        private void VR_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.Opacity = 0.7;
            switch(mainfrm.n_VRMode)
            {
                case 0:
                    dSkinPictureBox_VR0.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 1:
                    dSkinPictureBox_VR1.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 3:
                    dSkinPictureBox_VR3.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 4:
                    dSkinPictureBox_VR4.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 7:
                    dSkinPictureBox_VR7.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 9:
                    dSkinPictureBox_VR9.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 11:
                    dSkinPictureBox_VR11.Borders.AllColor = mainfrm.FocusColor;
                    break;
                case 15:
                    dSkinPictureBox_VR15.Borders.AllColor = mainfrm.FocusColor;
                    break;
                default:
                    break;
            }
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

        private void dSkinPictureBox_VR0_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR0.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR1_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR1.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR3_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR3.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR4_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR4.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR7_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR7.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR9_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR9.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR11_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR11.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR15_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox_VR15.BackColor = EnterUpColor;
        }


        private void dSkinPictureBox_VR0_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR0.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR1_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR1.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR3_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR3.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR4_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR4.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR7_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR7.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR9_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR9.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR11_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR11.BackColor = TransColor;
        }

        private void dSkinPictureBox_VR15_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_VR15.BackColor = TransColor;
        }


        private void dSkinPictureBox_VR0_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR0.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR1_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR1.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR3_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR3.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR4_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR4.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR7_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR7.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR9_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR9.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR11_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR11.BackColor = EnterUpColor;
        }

        private void dSkinPictureBox_VR15_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_VR15.BackColor = EnterUpColor;
        }


        private void dSkinPictureBox_VR0_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "0");
            dSkinPictureBox_VR0.BackColor = DownColor;
            mainfrm.n_VRMode = 0;
            SetPictureBorder(0);
            mainfrm.axPlayer1.SetConfig(2402, "0");
        }

        private void dSkinPictureBox_VR1_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR1.BackColor = DownColor;
            mainfrm.n_VRMode = 1;
            SetPictureBorder(1);
            mainfrm.axPlayer1.SetConfig(2402, "1");
        }

        private void dSkinPictureBox_VR3_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR3.BackColor = DownColor;
            mainfrm.n_VRMode = 3;
            SetPictureBorder(3);
            mainfrm.axPlayer1.SetConfig(2402, "3");
        }

        private void dSkinPictureBox_VR4_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR4.BackColor = DownColor;
            mainfrm.n_VRMode = 4;
            SetPictureBorder(4);
            mainfrm.axPlayer1.SetConfig(2402, "4");
        }

        private void dSkinPictureBox_VR7_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR7.BackColor = DownColor;
            mainfrm.n_VRMode = 7;
            SetPictureBorder(7);
            mainfrm.axPlayer1.SetConfig(2402, "7");
        }

        private void dSkinPictureBox_VR9_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR9.BackColor = DownColor;
            mainfrm.n_VRMode = 9;
            SetPictureBorder(9);
            mainfrm.axPlayer1.SetConfig(2402, "9");
        }

        private void dSkinPictureBox_VR11_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR11.BackColor = DownColor;
            mainfrm.n_VRMode = 11;
            SetPictureBorder(11);
            mainfrm.axPlayer1.SetConfig(2402, "11");
        }

        private void dSkinPictureBox_VR15_MouseDown(object sender, MouseEventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            dSkinPictureBox_VR15.BackColor = DownColor;
            mainfrm.n_VRMode = 15;
            SetPictureBorder(15);
            mainfrm.axPlayer1.SetConfig(2402, "15");
        }

        public void SetPictureBorder(int n_VRMode)
        {
            if(mainfrm.axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_READY)
            {
                mainfrm.n_VRMode = 0;
                return;
            }
            DSkinPictureBox[] dp = new DSkinPictureBox [] { dSkinPictureBox_VR0, dSkinPictureBox_VR1, dSkinPictureBox_VR3, dSkinPictureBox_VR4
            , dSkinPictureBox_VR7, dSkinPictureBox_VR9, dSkinPictureBox_VR11, dSkinPictureBox_VR15};

            foreach (DSkinPictureBox dpb in dp)
            {
                dpb.Borders.AllColor = Color.Transparent;
            }

            foreach (DSkinPictureBox dpb in dp)
            {
                string str_temp = dpb.Name.Replace("dSkinPictureBox_VR", "");
                if(n_VRMode == Convert.ToInt32(str_temp))
                {
                    dpb.Borders.AllColor = mainfrm.FocusColor;
                    break;
                }
            }
        }

        private void BeginVR()
        {
            mainfrm.axPlayer1.SetConfig(2401, "1");
            int n_Position = mainfrm.axPlayer1.GetPosition();
            string str_URL = mainfrm.axPlayer1.GetConfig(4);
            mainfrm.axPlayer1.Close();
            mainfrm.axPlayer1.SetConfig(102, n_Position.ToString());
            mainfrm.axPlayer1.Open(str_URL);
            //mainfrm.AfterOpenFile();
        }

    }
}
