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
    public partial class kisiSablon: UserControl
    {
        public kisiSablon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void kisiSablon_Load(object sender, EventArgs e)
        {
            kisiBilgiGetir();
            onaylamaKontrolMetodu();
            tumKisiListesi();
            if (gelenBizimTc == Tc.Text)
            {
                this.Hide();
            }
        }
        public string referansTc = "";
        void kisiBilgiGetir()
        {
         baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblKisiTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAdSoyad.Text = oku["kisiAd"].ToString() + " " + oku["kisiSoyad"].ToString();
                Ad.Text = oku["kisiAd"].ToString();
                Soyad.Text = oku["kisiSoyad"].ToString();
                Tc.Text = oku["kisiTc"].ToString();
                lblTelNo.Text = oku["kisiTel"].ToString();
                lblDogumT.Text = oku["kisiDogumT"].ToString();
                lblMail.Text = oku["kisiMail"].ToString();
                if (oku["kisiCinsiyet"].ToString() == "False")
                {
                    lblCinsiyet.Text = "ERKEK";
                }
                else
                {
                    lblCinsiyet.Text = "KADIN";
                }
            }
            baglanti.Close();
            referansTcGetir();
            referansAdSoyadGetir();
        }
        void referansAdSoyadGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblReferansTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblReferansAdSoyad.Text = oku["kisiAd"].ToString() + " " + oku["kisiSoyad"].ToString();
            }
            baglanti.Close();
        }
        void referansTcGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kodlar WHERE kisiTc=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblKisiTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblReferansTc.Text = oku["olusturanTc"].ToString();
            }
            baglanti.Close();
        }
        void onaylamaKontrolMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Islemler WHERE kisiTc=@p1 AND onaylayan=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", Tc.Text);
            komut.Parameters.AddWithValue("@p2", gelenBizimTc);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                this.Hide();
            }
            baglanti.Close();
        }
        private void btnOnayla_MouseMove(object sender, MouseEventArgs e)
        {
            lblAdSoyad.Text = lblReferansAdSoyad.Text;
            lblKisiTc.Text = lblReferansTc.Text;
            this.BackColor = Color.FromArgb(255, 192, 128);
            lblAdSoyad.ForeColor = Color.Black;
            lblKisiTc.ForeColor = Color.Black;
        }
        public string otelKodu = "";
        void tumKisiListesi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", otelKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblTumKisiler.Text = oku["otelSahip"].ToString();
            }
            baglanti.Close();
        }
        private void btnOnayla_MouseLeave(object sender, EventArgs e)
        {
            lblAdSoyad.Text = Ad.Text+" "+Soyad.Text;
            lblKisiTc.Text = Tc.Text;
            this.BackColor = Color.FromArgb(17, 55, 64);
            lblAdSoyad.ForeColor = Color.White;
            lblKisiTc.ForeColor = Color.White;
        }
        string islemTuru = "";
        public string gelenKod = "";
        public string gelenBizimTc = "";
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            islemTuru = "1";
            onaylamaMetodu();
            onaylamaKontrolMetodu();

            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("UPDATE Tbl_Oteller SET otelSahip=@p1 WHERE otelKodu=@p2", baglanti);
            //komut.Parameters.AddWithValue("p1",lblTumKisiler.Text+","+Tc.Text);
            //komut.Parameters.AddWithValue("p2",otelKodu);
            //komut.ExecuteNonQuery();
            //baglanti.Close();

            //ilk olarak bize buy sayılar ve kontrol gerekli olduğu için öncelikle sayımızı arttırmamız gerekiyor

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Kodlar SET onaySayisi+=1 WHERE otelKodu=@p2", baglanti);
            komut2.Parameters.AddWithValue("p2", otelKodu);
            komut2.ExecuteNonQuery();
            baglanti.Close();


            //otel sahibi ekleme işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Oteller SET Tbl_Oteller.otelSahip=@p1 FROM Tbl_Oteller INNER JOIN Tbl_Kodlar ON Tbl_Oteller.otelKodu=Tbl_Kodlar.otelKodu WHERE Tbl_Oteller.otelKodu=@p2 AND Tbl_Kodlar.ortakSayisi=Tbl_Kodlar.onaySayisi", baglanti);
            komut.Parameters.AddWithValue("p1", lblTumKisiler.Text + "," + Tc.Text);
            komut.Parameters.AddWithValue("p2", otelKodu);
            komut.ExecuteNonQuery();
            baglanti.Close();


            //delete komutu yazılacak
            baglanti.Open();
            SqlCommand silme = new SqlCommand("DELETE FROM Tbl_Kodlar WHERE ortakSayisi=onaySayisi",baglanti);
            silme.ExecuteNonQuery();
            baglanti.Close();



            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "ONAY VERİLDİ";

        }
        private void btnIptalEt_Click(object sender, EventArgs e)
        {
            islemTuru = "0";
            onaylamaMetodu();
            onaylamaKontrolMetodu();

            baglanti.Open();
            SqlCommand silme = new SqlCommand("DELETE FROM Tbl_Kodlar WHERE otelKodu=@p1", baglanti);
            silme.Parameters.AddWithValue("@p1", otelKodu);
            silme.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand silme2 = new SqlCommand("DELETE FROM Tbl_Islemler WHERE otelKodu=@p1 AND kisiTc=@p2 ", baglanti);
            silme2.Parameters.AddWithValue("@p1", otelKodu);
            silme2.Parameters.AddWithValue("@p2", Tc.Text);
            silme2.ExecuteNonQuery();
            baglanti.Close();
            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "ORTAKLIK REDDEDİLDİ";
            this.Hide();
        }
        void onaylamaMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Islemler (otelKodu, kisiTc, onaylayan, tur, zaman) VALUES (@otelKodu, @kisiTc, @onaylayan, @tur, @zaman)",baglanti);
            komut.Parameters.AddWithValue("@otelKodu",gelenKod);
            komut.Parameters.AddWithValue("@kisiTc", Tc.Text);
            komut.Parameters.AddWithValue("@onaylayan", gelenBizimTc);
            komut.Parameters.AddWithValue("@tur",islemTuru);
            komut.Parameters.AddWithValue("@zaman",DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "KAYIT EKLENDİ";
        }
    }
}