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
    public partial class frmOtelKayitEkrani: Form
    {
        public frmOtelKayitEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbBireysel_CheckedChanged(object sender, EventArgs e)
        {
            lblOtelTuru.Text = "0";
        }
        private void rbOrtak_CheckedChanged(object sender, EventArgs e)
        {
            lblOtelTuru.Text = "1";
        }
        private void frmOtelKayitEkrani_Load(object sender, EventArgs e)
        {
            kodOlustur();
            if (lblIstemTuru.Text == "1")
            {
                label1.Text = "OTEL BİLGİ DÜZENLEME EKRANI";
                pnlUstmenu.BackColor = Color.FromArgb(242,167,75);
                pbLogo.BackColor = Color.FromArgb(242, 167, 75);
                btnTemizle.Visible = false;
                btnGirisYap.Width = 498;
                btnGirisYap.Location = new Point(10, 290);
                btnGirisYap.Text = "GÜNCELLE";

                bilgiGetir();
            }
            
        }
        void bilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelSahip LIKE '%" + lblKisiTc.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtOtelAdi.Text = oku["otelAdi"].ToString();
                txtAciklama.Text = oku["otelAciklama"].ToString();
                lblOtelKod.Text = oku["otelKodu"].ToString();
                lblOtelTuru.Text = oku["otelTipi"].ToString();
                lblOrtakSayisi.Text = oku["otelSahip"].ToString();
                if (lblOtelTuru.Text == "0")
                {
                    rbBireysel.Checked = true;
                    rbOrtak.Checked = false;
                }
                else
                {
                    rbBireysel.Checked = false;
                    rbOrtak.Checked = true;
                }
            }
            baglanti.Close();
            int sayi = lblOrtakSayisi.Text.Split(',').Count();
            lblOrtakSayisi.Text = sayi.ToString();
            if (Convert.ToInt16(lblOrtakSayisi.Text)>1)
            {
                rbBireysel.Enabled = false;
                rbOrtak.Checked = true;
                lblOtelTuru.Text = "1";
            }
        }
        
        void kodOlustur() {
            Random rastgele = new Random();
            string semboller = "ABCDEFGHIJKLM29386231985462349851234567890NOPRSTUVYZ";
            string olusankod = "";
            for (int i = 1; i <= 10; i++)
            {
                olusankod += semboller[rastgele.Next(semboller.Length)];
            }
            lblOtelKod.Text = olusankod.ToString();
        }

        bool otelKoduKontrol = false;

        void otelKoduKontrolMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKod.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                otelKoduKontrol = true;
            }
            else
                otelKoduKontrol = false;
            baglanti.Close();

        }
        void otelKayitMetodu()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Oteller (otelKodu, otelAdi, otelTipi, otelSahip, otelAciklama) VALUES (@otelKodu, @otelAdi, @otelTipi, @otelSahip, @otelAciklama)", baglanti);
            komut.Parameters.AddWithValue("@otelKodu", lblOtelKod.Text.ToString());
            komut.Parameters.AddWithValue("@otelAdi", txtOtelAdi.Text.ToUpper());
            komut.Parameters.AddWithValue("@otelTipi", lblOtelTuru.Text.ToString());
            komut.Parameters.AddWithValue("@otelSahip", lblKisiTc.Text.ToString());
            komut.Parameters.AddWithValue("@otelAciklama", txtAciklama.Text.ToUpper());
            komut.ExecuteNonQuery();
            baglanti.Close();
            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "OTEL KAYIT İŞLEMİ BAŞARILI İLE GERÇEKLEŞTİRİLDİ";
            frm.TopMost = true;
        }
        void bilgiGuncelle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Oteller SET  otelAdi=@otelAdi, otelTipi=@otelTipi, otelAciklama=@otelAciklama WHERE otelKodu=@otelKodu",baglanti);
            komut.Parameters.AddWithValue("@otelKodu", lblOtelKod.Text.ToString());
            komut.Parameters.AddWithValue("@otelAdi", txtOtelAdi.Text.ToUpper());
            komut.Parameters.AddWithValue("@otelTipi", lblOtelTuru.Text.ToString());
            komut.Parameters.AddWithValue("@otelAciklama", txtAciklama.Text.ToUpper());
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtOtelAdi.Text != "" && txtAciklama.Text != "" && lblKisiTc.Text != "" && lblOtelKod.Text != "") 
            {
                if (lblIstemTuru.Text=="0")
                {
                    otelKoduKontrolMetodu();
                    if (otelKoduKontrol == true)
                    {
                        kodOlustur();
                        otelKayitMetodu();
                        this.Close();
                    }
                    else
                    {
                        otelKayitMetodu();
                        this.Close();
                    }
                }
                else
                {
                    //Güncelleme komutu yazılacak
                    bilgiGuncelle();
                    bilgiGetir();
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.label1.Text = "OTEL BİLGİLERİ GÜNCELLEME İŞLEMİ BAŞARILI";
                }

            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "Lütfen Tüm Alanları Eksiksiz Doldurun";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAciklama.Text = "";
            txtOtelAdi.Text = "";
            rbBireysel.Checked = true;
            rbOrtak.Checked = false;
            kodOlustur();
            lblOtelTuru.Text = "0";
            txtOtelAdi.Focus();
        }
    }
}
