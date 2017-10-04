using System;
using System.Windows.Forms;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class TipFrm : DSkinForm
    {
        public TipFrm()
        {
            InitializeComponent();
            timer = new Timer();
        }

        private void TipFrm_Shown(object sender, EventArgs e)
        {
            nTi = 0;
        }

        MainForm mainfrm;

        //操作提示
        public int nTi = 0;
        public Timer timer = null;
        public void ShowTips(string strTips)
        {
            try
            {
                //Console.WriteLine("start");
                this.Visible = true;
                dSkinLabel_Tip.Text = strTips;
                //this.Refresh();
                nTi = 0;
                timer.Enabled = true;
                timer.Interval = 1000;
                timer.Tick += new EventHandler(TimerTick);
                timer.Start();
            }
            catch{ return; }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //Console.WriteLine(nTi.ToString() + ",  " + DateTime.Now.ToString());
            if (nTi > 6000)
            {
                this.Hide();
                timer.Enabled = false;
                timer.Stop();
                nTi = 0;
            }
            else
            {
                nTi += 1000;
            }
        }

        private void TipFrm_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            dSkinLabel_Tip.ForeColor = mainfrm.FocusColor;
        }
    }
}
