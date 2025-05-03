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
    public partial class frmKonaklayanCikis: Form
    {
        public frmKonaklayanCikis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string gelenmusteritcno = "";

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKonaklayanCikis_Load(object sender, EventArgs e)
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
                lblOdaKodu.Text= oku["odaKodu"].ToString();
                lblgirisT.Text = oku["girisT"].ToString();
                lblcikisT.Text = oku["cikisT"].ToString();
                lblAdSoyadTc.Text= oku["kisiTc"].ToString()+"- "+oku["kisiAd"].ToString()+" "+oku["kisiSoyad"].ToString();
                lblAd.Text = oku["kisiAd"].ToString();
                lblSoyad.Text = oku["kisiSoyad"].ToString();
                lblKisiTc.Text= oku["kisiTc"].ToString();
                lblOdaNo.Text= oku["odaNo"].ToString();
                lblTelNo.Text= oku["kisiTel"].ToString();
                lblCinsiyet.Text = oku["kisiCinsiyet"].ToString();
                lblCocuk.Text = oku["kisiCocuk"].ToString();
                lblDogumT.Text= oku["kisiDogumT"].ToString();

            }  // Giriş ve çıkış tarihlerini alalım
            DateTime girisTarihi = Convert.ToDateTime(oku["girisT"]);
            DateTime cikisTarihi = Convert.ToDateTime(oku["cikisT"]);
            DateTime bugun = DateTime.Today;

            // Kalan gün hesaplama
            int kalanGun = (cikisTarihi - bugun).Days;
            if (kalanGun < 0)
                kalanGun = 0;
            lblKalanGun.Text = kalanGun.ToString();

            baglanti.Close();
            baglanti.Open();
            SqlCommand getir = new SqlCommand("SELECT * FROM Tbl_Yataksayisi WHERE odaKodu=@p1 ", baglanti);
            getir.Parameters.AddWithValue("@p1", lblOdaKodu.Text);
            SqlDataReader read = getir.ExecuteReader();
            if (read.Read())
            {
                lblbosyatak.Text = read["bosYatak"].ToString();
            }
            baglanti.Close();

        }

        private void ayrilmaclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ayrilmanedeni.Text = btn.Text;

            if(ayrilmanedeni.Text== "NORMAL AYRILMA")
            {
                pb1.Visible = true;
                pb2.Visible = false;
                pb3.Visible = false;
                pb4.Visible = false;
                txtdiger.Visible = false;
            }
            else if(ayrilmanedeni.Text== "ERKEN AYRILMA")
            {

                pb1.Visible = false;
                pb2.Visible = true;
                pb3.Visible = false;
                pb4.Visible = false;
                txtdiger.Visible = false;
            }
            else if (ayrilmanedeni.Text=="HABERSİZ AYRILMA")
            {

                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = true;
                pb4.Visible = false;
                txtdiger.Visible = false;
            }
            else
            {

                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = false;
                pb4.Visible = true;
                txtdiger.Visible = true;
            }
        }

        private void btnTamamla_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            // 1. Müşteriyi sil
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Musteriler WHERE odaKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOdaKodu.Text);
            komut.ExecuteNonQuery();

            // 2. lblbosyatak.Text içindeki değeri 1 azalt
            int mevcutBosYatak = int.Parse(lblbosyatak.Text);
            int yeniBosYatak = mevcutBosYatak + 1; // Boş yatak sayısı 1 artar çünkü müşteri çıkıyor

            // 3. Yeni boş yatak sayısını güncelle
            SqlCommand guncelle = new SqlCommand("UPDATE Tbl_Yataksayisi SET bosYatak=@bosyatak WHERE odaKodu=@odaKodu", baglanti);
            guncelle.Parameters.AddWithValue("@bosyatak", yeniBosYatak);
            guncelle.Parameters.AddWithValue("@odaKodu", lblOdaKodu.Text);
            guncelle.ExecuteNonQuery();

            SqlCommand insert = new SqlCommand("INSERT INTO Tbl_Ayrilanlar (kisiTc, kisiAd, kisiSoyad, ayrilmanedeni,odaNo,kisiTel,kisiDogumT,kisiMail,kisiCinsiyet,kisiCocuk,girisT,cikisT, ayrilmazamani) VALUES (@kisiTc, @kisiAd, @kisiSoyad, @ayrilmanedeni,@odaNo,@kisiTel,@kisiDogumT,@kisiMail,@kisiCinsiyet,@kisiCocuk,@girisT,@cikisT,@ayrilmazamani)", baglanti);
            insert.Parameters.AddWithValue("@kisiTc", lblKisiTc.Text);
            insert.Parameters.AddWithValue("@kisiAd", lblAd.Text);
            insert.Parameters.AddWithValue("@kisiSoyad", lblSoyad.Text);
            insert.Parameters.AddWithValue("@ayrilmanedeni", ayrilmanedeni.Text);
            insert.Parameters.AddWithValue("@odaNo", lblOdaNo.Text);
            insert.Parameters.AddWithValue("@kisiTel", lblTelNo.Text);
            insert.Parameters.AddWithValue("@kisiDogumT", lblDogumT.Text);
            insert.Parameters.AddWithValue("@ayrilmazamani", DateTime.Now);
            insert.Parameters.AddWithValue("@kisiMail", lblMail.Text);
            insert.Parameters.AddWithValue("@kisiCinsiyet", lblCinsiyet.Text);
            insert.Parameters.AddWithValue("@kisiCocuk", lblCocuk.Text);
            insert.Parameters.AddWithValue("@girisT", lblgirisT.Text);
            insert.Parameters.AddWithValue("@cikisT", lblcikisT.Text);
            insert.ExecuteNonQuery();

            baglanti.Close();

            frmPopupmenu frm = new frmPopupmenu();
            frm.label1.Text = "İŞLEM BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİ";
            frm.Show();
            this.Close();

        }


        private void txtdiger_TextChanged(object sender, EventArgs e)
        {
            ayrilmanedeni.Text = txtdiger.Text;
        }
    }
}
