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
    public partial class EndUserLicense : DSkinForm
    {
        public EndUserLicense()
        {
            InitializeComponent();
        }

        private void EndUserLicense_Load(object sender, EventArgs e)
        {
            duiTextBox1.InnerScrollBar.Fillet = true;
        }
    }
}
