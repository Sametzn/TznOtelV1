using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class frmOrtaklar: Form
    {
        public frmOrtaklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string gelenOtelKodu ="";
        private void frmOrtaklar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", gelenOtelKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblortakKisiTcler.Text = oku["otelSahip"].ToString();
            }
            baglanti.Close();
            foreach (string kisiTc in lblortakKisiTcler.Text.Split(','))
            {
                ortaklarsablon sablon = new ortaklarsablon();
                sablon.lblKisiTcNo.Text = kisiTc;
                sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                sablon.lblOtelKodu.Text = gelenOtelKodu;
                pnlKisiListesi.Controls.Add(sablon);

            }


        }



    }
}
