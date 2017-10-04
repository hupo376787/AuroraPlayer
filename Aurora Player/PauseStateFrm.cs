using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class PauseStateFrm : DSkinForm
    {
        public PauseStateFrm()
        {
            InitializeComponent();
        }

        private void PauseStateFrm_Load(object sender, EventArgs e)
        {
            dSkinPictureBox_Pause.Image = Properties.Resources.AP;
        }

        private void dSkinPictureBox_Pause_MouseHover(object sender, EventArgs e)
        {
            dSkinPictureBox_Pause.Image = Properties.Resources.AP_Hover;
        }

        private void dSkinPictureBox_Pause_MouseDown(object sender, MouseEventArgs e)
        {
            dSkinPictureBox_Pause.Image = Properties.Resources.AP_Press;
        }

        private void dSkinPictureBox_Pause_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox_Pause.Image = Properties.Resources.AP;
        }
    }
}
