using System;
using System.Drawing;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class TimeLineFrm : DSkinForm
    {
        public TimeLineFrm()
        {
            InitializeComponent();
        }

        //MainForm mainfrm;

        private void TimeLineFrm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(70, 30);
            this.Opacity = 0.7;
            //mainfrm = (MainForm)this.Owner;
        }

    }
}
