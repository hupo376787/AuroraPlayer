using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aurora_Player
{
    public partial class AuroraControl : DSkin.Controls.DSkinUserControl
    {
        public AuroraControl()
        {
            InitializeComponent();
        }

        private void AuroraControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void AuroraControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void AuroraControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

        private void dSkinPictureBox_VR_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void dSkinPictureBox_VR_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void dSkinPictureBox_VR_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

        private void duiTextBox_VR_MouseDown(object sender, DSkin.DirectUI.DuiMouseEventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

        private void duiTextBox_VR_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void duiTextBox_VR_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void AuroraControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void dSkinPictureBox_VR_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void duiTextBox_VR_MouseUp(object sender, DSkin.DirectUI.DuiMouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

    }
}
