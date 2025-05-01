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
    public partial class frmKisiselBilgiDuzenleme: Form
    {
        public frmKisiselBilgiDuzenleme()
        {
            InitializeComponent();
        }
        public string gelenKisiTcNumarası = "";
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmKisiselBilgiDuzenleme_Load(object sender, EventArgs e)
        {
            txtTcKimlik.Text = gelenKisiTcNumarası;
            kisiBilgiGetir();
            if (lblCinsiyetKontrol.Text == "False")
            {
                rbErkek.Checked = true;
                rbKadin.Checked = false;
            }
            else
            {
                rbErkek.Checked = false;
                rbKadin.Checked = true;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTcKimlik.Text != "" && txtAd.Text != "" && txtSoyad.Text != "" && txtTelNo.Text != "" && txtMail.Text != "" && txtDogumTarihi.Text != "" && txtAciklama.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Tbl_Kisiler SET kisiAd=@kisiAd, kisiSoyad=@kisiSoyad,kisiMail=@kisiMail, kisiTel=@kisiTel, kisiDogumT=@kisiDogumT, kisiAciklama=@kisiAciklama, kisiCinsiyet=@kisiCinsiyet  WHERE kisiTc=@p2", baglanti);
                komut.Parameters.AddWithValue("@p2", gelenKisiTcNumarası);
                komut.Parameters.AddWithValue("@kisiAd", txtAd.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiSoyad", txtSoyad.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiMail", txtMail.Text);
                komut.Parameters.AddWithValue("@kisiTel", txtTelNo.Text);
                komut.Parameters.AddWithValue("@kisiDogumT", txtDogumTarihi.Text);
                komut.Parameters.AddWithValue("@kisiAciklama", txtAciklama.Text.ToUpper());
                komut.Parameters.AddWithValue("@kisiCinsiyet", lblCinsiyetKontrol.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                kisiBilgiGetir();
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
        void kisiBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenKisiTcNumarası);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtAd.Text = oku["kisiAd"].ToString();
                txtSoyad.Text = oku["kisiSoyad"].ToString();
                txtMail.Text = oku["kisiMail"].ToString();
                txtTelNo.Text = oku["kisiTel"].ToString();
                txtDogumTarihi.Text = oku["kisiDogumT"].ToString();
                txtAciklama.Text = oku["kisiAciklama"].ToString();
                lblCinsiyetKontrol.Text = oku["kisiCinsiyet"].ToString();

            }
            baglanti.Close();

        }

        private void rbErkek_CheckedChanged(object sender, EventArgs e)
        {
            lblCinsiyetKontrol.Text = "False";
        }

        private void rbKadin_CheckedChanged(object sender, EventArgs e)
        {
            lblCinsiyetKontrol.Text = "True ";
        }
    }
}
