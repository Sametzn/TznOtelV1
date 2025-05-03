using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TznOtelV1
{
    public partial class frmAyrilanKisiler: Form
    {
        public frmAyrilanKisiler()
        {
            InitializeComponent();
        }
        private void frmAyrilanKisiler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'tznOtelVTDataSet.Tbl_Ayrilanlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_AyrilanlarTableAdapter.Fill(this.tznOtelVTDataSet.Tbl_Ayrilanlar);

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
