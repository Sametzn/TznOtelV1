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
    public partial class frmKonaklayanlarListesi: Form
    {
        public frmKonaklayanlarListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void konaklayanGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Musteriler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                konaklayanSablon konak = new konaklayanSablon();
                konak.lblAdSoyad.Text = oku["kisiAd"].ToString() + " " + oku["kisiSoyad"].ToString();
                konak.lblTcNo.Text = oku["kisiTc"].ToString();
                konak.lblgirisT.Text = oku["girisT"].ToString();
                konak.lblcikisT.Text = oku["cikisT"].ToString();
                konak.lblOdaNo.Text = oku["odaNo"].ToString();

                // Giriş ve çıkış tarihlerini alalım
                DateTime girisTarihi = Convert.ToDateTime(oku["girisT"]);
                DateTime cikisTarihi = Convert.ToDateTime(oku["cikisT"]);

                // Gün farkını hesaplayalım
                TimeSpan fark = cikisTarihi - girisTarihi;
                int gunSayisi = fark.Days;

                // Eğer gün sayısı 0 ise, 1 olarak kabul edelim
                if (gunSayisi == 0)
                {
                    gunSayisi = 1;
                }

                // lblgun textine gün sayısını atalım
                konak.lblgun.Text = gunSayisi.ToString();

                flpmisafir.Controls.Add(konak);
            }
            baglanti.Close();
        }



        private void frmKonaklayanlarListesi_Load(object sender, EventArgs e)
        {
            konaklayanGetir();
        }

        private void frmKonaklayanlarListesi_Activated(object sender, EventArgs e)
        {
            flpmisafir.Controls.Clear();
            konaklayanGetir();
        }
    }
}
