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
    public partial class frmKonaklayanDetay: Form
    {
        public frmKonaklayanDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string gelenmusteritcno = "";
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTcNo.Text != "" && txtUyruk.Text != "" && txtAd.Text != "" && txtSoyad.Text != "" && txtTelNo.Text != "" && txtMail.Text != "" && txtDogumT.Text != "" && txtAciklama.Text != "" && txtMail.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Tbl_Musteriler SET kisiUyruk=@kisiUyruk, kisiAd=@kisiAd, kisiSoyad=@kisiSoyad,girisT=@girisT,cikisT=@cikisT,kisiMail=@kisiMail, kisiTel=@kisiTel, kisiDogumT=@kisiDogumT, aciklama=@aciklama, kisiCinsiyet=@kisiCinsiyet , kisiCocuk=@kisiCocuk WHERE kisiTc=@p2", baglanti);
                komut.Parameters.AddWithValue("@p2", gelenmusteritcno);
                komut.Parameters.AddWithValue("@kisiUyruk", txtUyruk.Text);
                komut.Parameters.AddWithValue("@kisiAd", txtAd.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiSoyad", txtSoyad.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiMail", txtMail.Text);
                komut.Parameters.AddWithValue("@kisiTel", txtTelNo.Text);
                komut.Parameters.AddWithValue("@girisT", txtGirisT.Text);
                komut.Parameters.AddWithValue("@cikisT", txtCikisT.Text);
                komut.Parameters.AddWithValue("@kisiCocuk", lblcocuk.Text);
                komut.Parameters.AddWithValue("@kisiDogumT", txtDogumT.Text);
                komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiCinsiyet", lblcinsiyet.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "KAYIT BAŞARILI BİR ŞEKİLDE DÜZENLENDİ";
                frm.Show();
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "LÜTFEN TÜM ALANLARI DOLDURUNUZ";
                frm.Show();
            }
        }

      private void cinsiyetclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblcinsiyet.Text = btn.Text;

            //döngü ile gruplandırma işlemi

            if (lblcinsiyet.Text == "ERKEK")
            {
                lblcinsiyet.Text = "0";
                pb1.Visible = true;
                pb2.Visible = false;
            }
            else
            {
                lblcinsiyet.Text = "1";
                pb1.Visible = false;
                pb2.Visible = true;
            }
        }
        private void cocukclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblcocuk.Text = btn.Text;

            //döngü ile gruplandırma işlemi

            if (lblcocuk.Text == "VAR")
            {
                lblcocuk.Text = "1";
                pb3.Visible = true;
                pb4.Visible = false;
            }
            else
            {
                lblcocuk.Text = "0";
                pb3.Visible = false;
                pb4.Visible = true;
            }
        }


        private void frmKonaklayanDetay_Load(object sender, EventArgs e)
        {
            kisiBilgiGetir();
        }
        void kisiBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Musteriler WHERE kisiTc=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenmusteritcno);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtTcNo.Text = oku["kisiTc"].ToString();
                txtUyruk.Text = oku["kisiUyruk"].ToString().ToUpper();
                txtAd.Text = oku["kisiAd"].ToString().ToUpper();
                txtSoyad.Text = oku["kisiSoyad"].ToString().ToUpper(); ;
                txtDogumT.Text = oku["kisiDogumT"].ToString();
                txtMail.Text = oku["kisiMail"].ToString();
                txtTelNo.Text = oku["kisiTel"].ToString();
                txtGirisT.Text= oku["girisT"].ToString();
                txtCikisT.Text = oku["cikisT"].ToString();
                txtAciklama.Text = oku["aciklama"].ToString();
                lblcinsiyet.Text = oku["kisiCinsiyet"].ToString();
                if (lblcinsiyet.Text=="0")
                {
                    pb1.Visible = true;
                    pb2.Visible = false;
                }
                else
                {
                    pb1.Visible = false;
                    pb2.Visible = true;
                }
                
                lblcocuk.Text = oku["kisiCocuk"].ToString();
                if (lblcocuk.Text=="0")
                {
                    pb4.Visible = true;
                    pb3.Visible = false;
                }
                else
                {
                    pb4.Visible = false;
                    pb3.Visible = true;
                }
            }
            baglanti.Close();

        }

        private void frmKonaklayanDetay_Activated(object sender, EventArgs e)
        {
            kisiBilgiGetir();
        }
    }
}
