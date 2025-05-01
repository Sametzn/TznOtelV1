using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TznOtelV1
{
    public partial class frmPersonelKayit2: Form
    {
        public frmPersonelKayit2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string tc, ad, soyad, dogumt, mail, tel, aciklama, cinsiyet;
        string kullaniciadi, parola, soru, cevap;
        bool parola1Gizli = true;
        bool parola2Gizli = true;
        bool tcKontrol = false;
        bool kullaniciAdiKontrol = false;
        public string gOtelKodu = "";

        void tcKontrolMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                tcKontrol = true;
            }
            else
                tcKontrol = false;
            baglanti.Close();

        }
        void kullaniciAdiKontrolMetodu()

        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiKul=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", kullaniciadi);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kullaniciAdiKontrol = true;
            }
            else
                kullaniciAdiKontrol = false;
            baglanti.Close();

        }
        void kisiKayitMetodu()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Kisiler (kisiTc,kisiAd,kisiSoyad,kisiCinsiyet,kisiDogumT,kisiTel,kisiMail,kisiAciklama,kisiKul,kisiParola,kisiSoru,kisiCevap,kisiYetki) VALUES (@kisiTc,@kisiAd,@kisiSoyad,@kisiCinsiyet,@kisiDogumT,@kisiTel,@kisiMail,@kisiAciklama,@kisiKul,@kisiParola,@kisiSoru,@kisiCevap,@kisiYetki)", baglanti);
            komut.Parameters.AddWithValue("@kisiTc", tc);
            komut.Parameters.AddWithValue("@kisiAd", ad);
            komut.Parameters.AddWithValue("@kisiSoyad", soyad);
            komut.Parameters.AddWithValue("@kisiCinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@kisiDogumT", dogumt);
            komut.Parameters.AddWithValue("@kisiTel", tel);
            komut.Parameters.AddWithValue("@kisiMail", mail);
            komut.Parameters.AddWithValue("@kisiAciklama", aciklama);
            komut.Parameters.AddWithValue("@kisiKul", kullaniciadi);
            komut.Parameters.AddWithValue("@kisiParola", parola);
            komut.Parameters.AddWithValue("@kisiSoru", soru);
            komut.Parameters.AddWithValue("@kisiCevap", cevap);
            komut.Parameters.AddWithValue("@kisiYetki", "0");
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }
        void calisanlarListesi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", gOtelKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblPersoneller.Text = oku["otelPersonel"].ToString();
            }
            baglanti.Close();
        }

        private void btnKaydiTamamla_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "" && txtParola.Text != "" && txtCevap.Text != "")
            {
                // Şifre şartları kontrolü
                string pass = txtParola.Text;
                bool uzunlukUygun = pass.Length >= 5;
                bool buyukHarfVar = pass.Any(char.IsUpper);
                bool ozelKarakterVar = pass.Any(ch => !char.IsLetterOrDigit(ch));
                bool sayiVar = pass.Any(char.IsDigit);
                

                if (!uzunlukUygun || !buyukHarfVar || !ozelKarakterVar || !sayiVar)
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.TopMost = true;

                    StringBuilder sb = new StringBuilder();

                    if (!uzunlukUygun)
                        sb.AppendLine("Parola en az 5 karakter olmalıdır.");
                    if (!buyukHarfVar)
                        sb.AppendLine("Parola en az bir büyük harf içermelidir.");
                    if (!ozelKarakterVar)
                        sb.AppendLine("Parola en az bir özel karakter içermelidir.");
                    if (!sayiVar)
                        sb.AppendLine("Parola en az bir rakam içermelidir.");

                    frm.label1.Text = sb.ToString().Trim();
                    return;
                }

                if (txtParola.Text.Equals(txtParolaTkr.Text))
                {
                    kullaniciadi = txtKullaniciAdi.Text;
                    parola = txtParola.Text;
                    soru = lblSecilenSoru.Text;
                    cevap = txtCevap.Text;

                    tcKontrolMetodu();
                    kullaniciAdiKontrolMetodu();

                    if (kullaniciAdiKontrol == false && tcKontrol == false)
                    {
                        calisanlarListesi();
                        kisiKayitMetodu();
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("UPDATE Tbl_Oteller SET otelPersonel=@p1 WHERE otelKodu=@p2", baglanti);
                        if (lblPersoneller.Text == "")
                        {
                            komut.Parameters.AddWithValue("p1", tc);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("p1", lblPersoneller.Text + "," + tc);
                        }

                        komut.Parameters.AddWithValue("p2", gOtelKodu);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        Temizle();
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.TopMost = true;
                        frm.label1.Text = "PERSONEL KAYIT İŞLEMİ BAŞARILI İLE GERÇEKLEŞTİRİLDİ";
                        calisanlarListesi();

                    }
                    else
                    {
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.TopMost = true;
                        frm.label1.Text = kullaniciAdiKontrol ? "Kayıtlı Kullanıcı Adı Mevcut" : "Kayıtlı Tc Kimlik Mevcut";
                    }
                }
                else
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.TopMost = true;
                    frm.label1.Text = "Girilen Parolalar Uyuşmuyor";
                }
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.TopMost = true;
                frm.label1.Text = "Lütfen tüm alanları doldurun.";
            }
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbGeri_Click(object sender, EventArgs e)
        {
            frmPersonelKayit frm = new frmPersonelKayit();
            frm.txtTcKimlik.Text = this.tc;
            frm.txtAd.Text = this.ad;
            frm.txtSoyad.Text = this.soyad;
            frm.txtDogumTarihi.Text = this.dogumt;
            frm.txtMail.Text = this.mail;
            frm.txtTelNo.Text = this.tel;
            frm.txtAciklama.Text = this.aciklama;
            frm.lblCinsiyetKontrol.Text = this.cinsiyet;
            frm.Show();
            this.Close();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
   

        private void frmPersonelKayit2_Load(object sender, EventArgs e)
        {
            calisanlarListesi();
            lblSecilenSoru.Text = rbSoru1.Text;
            txtParola.UseSystemPasswordChar = true;
            txtParolaTkr.UseSystemPasswordChar = true;

            btnshow.Image = Properties.Resources.show16px;
            btnshow1.Image = Properties.Resources.show16px;

            // Durum değişkenini ayarla
            parola1Gizli = true;
            parola2Gizli = true;
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



        private void rbSoru3_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru3.Text;
        }

        private void rbSoru2_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru2.Text;
        }

        private void rbSoru1_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenSoru.Text = rbSoru1.Text;
        }
        void Temizle()
        {
            txtKullaniciAdi.Text = "";
            txtParola.Text = "";
            txtParolaTkr.Text = "";
            txtCevap.Text = "";
            rbSoru1.Checked = true;
            rbSoru2.Checked = false;
            rbSoru3.Checked = false;
            lblSecilenSoru.Text = rbSoru1.Text;
        }
       
      
    }
}
