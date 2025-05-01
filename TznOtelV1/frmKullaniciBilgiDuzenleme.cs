using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TznOtelV1;

namespace TznOtelV1
{
    public partial class frmKullaniciBilgiDuzenleme: Form
    {
        public frmKullaniciBilgiDuzenleme()
        {
            InitializeComponent();
        }
        bool parola1Gizli = true;
        bool parola2Gizli = true;
        bool parola3Gizli = true;
        public string gelenKisiTcNumarası = "";
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");

        private void frmKullaniciBilgiDuzenleme_Load(object sender, EventArgs e)
        {

            kisiBilgiGetir();
            txtParola.UseSystemPasswordChar = true;
            txtParolaTkr.UseSystemPasswordChar = true;
            txtCevap.UseSystemPasswordChar = true;

            btnshow.Image = Properties.Resources.show16px;
            btnshow1.Image = Properties.Resources.show16px;
            btnshow3.Image = Properties.Resources.show16px;

            // Durum değişkenini ayarla
            parola1Gizli = true;
            parola2Gizli = true;
            parola3Gizli = true;
        }
        void kisiBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenKisiTcNumarası);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtKullaniciAdi.Text = oku["kisiKul"].ToString();
                lblkisikuladi.Text = oku["kisiKul"].ToString();
                txtParola.Text = oku["kisiParola"].ToString();
                lblSecilenSoru.Text = oku["kisiSoru"].ToString();
                txtCevap.Text = oku["kisiCevap"].ToString();
                if (lblSecilenSoru.Text == rbSoru1.Text)
                {
                    rbSoru1.Checked = true;
                    rbSoru2.Checked = false;
                    rbSoru3.Checked = false;
                }
                if (lblSecilenSoru.Text == rbSoru2.Text)
                {
                    rbSoru1.Checked = false;
                    rbSoru2.Checked = true;
                    rbSoru3.Checked = false;
                }
                if (lblSecilenSoru.Text == rbSoru3.Text)
                {
                    rbSoru1.Checked = false;
                    rbSoru2.Checked = false;
                    rbSoru3.Checked = true;
                }

            }
            baglanti.Close();
        }
 
      
        bool kulAdiKontrol = false;
        void kullaniciAdiKontrolMetodu()

        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiKul=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kulAdiKontrol = true;
            }
            else
                kulAdiKontrol = false;
            baglanti.Close();

        }

        private void btn_cıkıs_Click_1(object sender, EventArgs e)
        {
            if (label7.Text == "1")
            {
                Application.Restart();
            }
            else
            {
                this.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (txtKullaniciAdi.Text != "" && txtParola.Text != "" && txtParolaTkr.Text != "" && txtCevap.Text != "")
            {
                if (txtParola.Text.Equals(txtParolaTkr.Text))
                {
                    if (lblkisikuladi.Text == txtKullaniciAdi.Text)
                    {

                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("UPDATE Tbl_Kisiler SET kisiParola=@kisiParola, kisiSoru=@kisiSoru, kisiCevap=@kisiCevap WHERE kisiTc=@p2", baglanti);
                            komut.Parameters.AddWithValue("@p2", gelenKisiTcNumarası);
                            komut.Parameters.AddWithValue("@kisiParola", txtParola.Text);
                            komut.Parameters.AddWithValue("@kisiSoru", lblSecilenSoru.Text);
                            komut.Parameters.AddWithValue("@kisiCevap", txtCevap.Text);
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            kisiBilgiGetir();
                            frmPopupmenu frm = new frmPopupmenu();
                            frm.label1.Text = "GÜNCELLEME İŞLEMİ BAŞARILI";
                            frm.Show();
                    }
                    else
                    {
                        kullaniciAdiKontrolMetodu();
                        if (kulAdiKontrol == true)
                        {
                            frmPopupmenu frm = new frmPopupmenu();
                            frm.label1.Text = "GİRİLEN KULLANICI ADI KULLANILMAKTADIR";
                            frm.Show();
                        }
                        else
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("UPDATE Tbl_Kisiler SET kisiKul=@kisiKul,kisiParola=@kisiParola, kisiSoru=@kisiSoru, kisiCevap=@kisiCevap WHERE kisiTc=@p2", baglanti);
                            komut.Parameters.AddWithValue("@p2", gelenKisiTcNumarası);
                            komut.Parameters.AddWithValue("@kisiKul", txtKullaniciAdi.Text);
                            komut.Parameters.AddWithValue("@kisiParola", txtParola.Text);
                            komut.Parameters.AddWithValue("@kisiSoru", lblSecilenSoru.Text);
                            komut.Parameters.AddWithValue("@kisiCevap", txtCevap.Text);
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            kisiBilgiGetir();
                            frmPopupmenu frm = new frmPopupmenu();
                            frm.label1.Text = "GÜNCELLEME İŞLEMİ BAŞARILI";
                            frm.Show();
                            label7.Text = "1";
                        }
                    }


                }
                else
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.label1.Text = "GİRİLEN ŞİFRELER UYUŞMUYOR";
                    frm.Show();
                }

            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "LÜTFEN TÜM ALANLARI DOLDURUNUZ";
                frm.Show();
            }
        }

        private void rbSoru1_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru1.Text;
        }

        private void rbSoru2_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru2.Text;
        }

        private void rbSoru3_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru3.Text;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            parola1Gizli = !parola1Gizli;

            txtParola.UseSystemPasswordChar = parola1Gizli;

            btnshow.Image = parola1Gizli
                ? Properties.Resources.show16px
                : Properties.Resources.hide16px;
        }

        private void btnshow1_Click(object sender, EventArgs e)
        {
            parola2Gizli = !parola2Gizli;

            txtParolaTkr.UseSystemPasswordChar = parola2Gizli;

            btnshow1.Image = parola2Gizli
                ? Properties.Resources.show16px
                : Properties.Resources.hide16px;
        }

        private void btnshow3_Click(object sender, EventArgs e)
        {
            parola3Gizli = !parola3Gizli;

            txtCevap.UseSystemPasswordChar = parola3Gizli;

            btnshow3.Image = parola3Gizli
                ? Properties.Resources.show16px
                : Properties.Resources.hide16px;
        }
    }
}
//kullaniciAdiKontrolMetodu();
//if (kulAdiKontrol == true)
//{
//    frmPopupmenu frm = new frmPopupmenu();
//    frm.label1.Text = "GİRİLEN KULLANICI ADI KULLANILMAKTADIR";
//    frm.Show();
//}
//else
//{
//    baglanti.Open();
//    SqlCommand komut = new SqlCommand("UPDATE Tbl_Kisiler SET kisiKul=@kisiKul,kisiParola=@kisiParola, kisiSoru=@kisiSoru, kisiCevap=@kisiCevap WHERE kisiTc=@p2", baglanti);
//    komut.Parameters.AddWithValue("@p2", gelenKisiTcNumarası);
//    komut.Parameters.AddWithValue("@kisiKul", txtKullaniciAdi.Text);
//    komut.Parameters.AddWithValue("@kisiParola", txtParola.Text);
//    komut.Parameters.AddWithValue("@kisiSoru", lblSecilenSoru.Text);
//    komut.Parameters.AddWithValue("@kisiCevap", txtCevap.Text);
//    komut.ExecuteNonQuery();
//    baglanti.Close();
//    kisiBilgiGetir();
//    frmPopupmenu frm = new frmPopupmenu();
//    frm.label1.Text = "GÜNCELLEME İŞLEMİ BAŞARILI";
//    frm.Show();
//    label7.Text = "1";
//}
