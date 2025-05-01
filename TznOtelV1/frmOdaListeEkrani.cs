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
    public partial class frmOdaListeEkrani : Form
    {
        public frmOdaListeEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    void odaListesiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Odalar order by odaAdi ASC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                odaSablon oda = new odaSablon();
                oda.lblOdaKodu.Text = oku["odaKodu"].ToString();
                oda.lblOdaAdi.Text = oku["odaAdi"].ToString();
                oda.lblOdaFiyati.Text = oku["odaFiyati"].ToString() + " " + "₺";
                oda.lblOdaTuru.Text = oku["odaTuru"].ToString();
                oda.lblOdaDurumu.Text = oku["odaDurumu"].ToString();
                odaListePaneli.Controls.Add(oda);
            }
            baglanti.Close();
        }


        private void frmOdaListeEkrani_Load(object sender, EventArgs e)
        {
            odaListesiGetir();
        }

        private void frmOdaListeEkrani_Activated(object sender, EventArgs e)
        {
            odaListePaneli.Controls.Clear();
            odaListesiGetir();
        }
    } 
}
