using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TznOtelV1
{
    public partial class konaklayanSablon: UserControl
    {
        public konaklayanSablon()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            
            frmKonaklayanCikis detay = new frmKonaklayanCikis();
            detay.gelenmusteritcno = lblTcNo.Text;
            detay.ShowDialog();
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            frmKonaklayanDetay detay = new frmKonaklayanDetay();
            detay.gelenmusteritcno = lblTcNo.Text;
            detay.ShowDialog();
        }

        private void btnUzat_Click(object sender, EventArgs e)
        {
            frmUzatmaEkrani detay = new frmUzatmaEkrani();
            detay.cikistarihi = lblcikisT.Text;
            detay.giristarihi = lblgirisT.Text;
            detay.ShowDialog();
        }
    }
}
