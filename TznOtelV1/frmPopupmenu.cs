using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TznOtelV1
{
    public partial class frmPopupmenu : Form
    {
        public frmPopupmenu()
        {
            InitializeComponent();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 20)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
