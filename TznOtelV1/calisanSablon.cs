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
    public partial class calisanSablon : UserControl
    {
        public calisanSablon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        string kisiTcSorgula = "";
        string ad, soyad, cinsiyet,dogumT,tel,mail,aciklama;
        private void calisanSablon_Load(object sender, EventArgs e)
        {
            kisiBilgiGetir();
            calisanlarMetodu();
            if (lblKisiTcNo.Text =="")
            {
                this.Hide();
            }
            if (cinsiyet == "True")
            {
                pictureBox1.Image = Properties.Resources.edfr;
                panel1.BackColor = Color.FromArgb(255, 128, 0);
                lblKisiTcNo.ForeColor = Color.FromArgb(254, 42, 19);
                btn_Cikart.BackColor = Color.FromArgb(255, 128, 0);
                lblUyariMesaji.BackColor= Color.FromArgb(255, 128, 0);
            }
        }
        void kisiBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblKisiTcNo.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblKisiTcNo.Text = oku["kisiAd"].ToString() + " " + oku["kisiSoyad"].ToString() + " - " + oku["kisiTc"].ToString();
                kisiTcSorgula = oku["kisiTc"].ToString();
                ad = oku["kisiAd"].ToString();
                soyad = oku["kisiSoyad"].ToString();
                cinsiyet = oku["kisiCinsiyet"].ToString();
                dogumT = oku["kisiDogumT"].ToString();
                tel = oku["kisiTel"].ToString();
                mail = oku["kisiMail"].ToString();
                aciklama = oku["kisiAciklama"].ToString();
            }
            baglanti.Close();
        }
        string calisanlar = "";
        void calisanlarMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                calisanlar = oku["otelPersonel"].ToString();
                foreach (string kisi in calisanlar.Split(','))
                {
                    listBox1.Items.Add(kisi);
                }
      
            }
            baglanti.Close();

        }

        private void btn_Cikart_Click(object sender, EventArgs e)
        {
            if (btn_Cikart.Text=="ÇIKAR")
            {
                btn_Cikart.Text = "EVET";
                btn_Detay.Text = "HAYIR";
                this.Height = 140;
                lblUyariMesaji.Visible = true;
            }
            else
            {
                btn_Cikart.Text = "ÇIKAR";
                btn_Detay.Text = "DETAY";
                this.Height = 85;
                lblUyariMesaji.Visible = false;
                listBox1.Items.Clear();

                calisanlarMetodu();
                listBox1.Items.Remove(kisiTcSorgula);

                string newKisi = "";
                foreach (string kisi in listBox1.Items)
                {
                    newKisi += "," + kisi;
                }
                if (listBox1.Items.Count != 0)
                {
                    label1.Text = newKisi.Substring(1);
                }
                else
                {
                    label1.Text = "";
                }
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("INSERT INTO Tbl_EskiPersoneller (otelKodu,kisiTc,kisiAd,kisiSoyad,kisiCinsiyet,kisiDogumT,kisiTel,kisiMail,kisiAciklama,cikartan,ayrilmaT) VALUES (@otelKodu,@kisiTc,@kisiAd,@kisiSoyad,@kisiCinsiyet,@kisiDogumT,@kisiTel,@kisiMail,@kisiAciklama,@cikartan,@ayrilmaT)", baglanti);
                ekle.Parameters.AddWithValue("@otelKodu", lblOtelKodu.Text);
                ekle.Parameters.AddWithValue("@kisiTc", kisiTcSorgula);
                ekle.Parameters.AddWithValue("@kisiAd", ad);
                ekle.Parameters.AddWithValue("@kisiSoyad", soyad);
                ekle.Parameters.AddWithValue("@kisiCinsiyet", cinsiyet);
                ekle.Parameters.AddWithValue("@kisiDogumT", dogumT);
                ekle.Parameters.AddWithValue("@kisiTel", tel);
                ekle.Parameters.AddWithValue("@kisiMail", mail);
                ekle.Parameters.AddWithValue("@kisiAciklama", aciklama);
                ekle.Parameters.AddWithValue("@cikartan", lblBizimTcmiz.Text);
                ekle.Parameters.AddWithValue("@ayrilmaT", DateTime.Now.ToString());

                ekle.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand sil = new SqlCommand("DELETE FROM Tbl_Kisiler WHERE kisiTc=@p1", baglanti);
                sil.Parameters.AddWithValue("@p1", kisiTcSorgula);
                sil.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand guncelle = new SqlCommand("UPDATE Tbl_Oteller SET otelPersonel=@p1 WHERE otelKodu=@p2", baglanti);
                guncelle.Parameters.AddWithValue("@p1", label1.Text);
                guncelle.Parameters.AddWithValue("@p2", lblOtelKodu.Text);
                guncelle.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("İŞLEM BAŞARILI");
                this.Hide();
            }
        }

        private void btn_Detay_Click(object sender, EventArgs e)
        {
            if (btn_Detay.Text == "DETAY")
            {
                frmPersonelDetay frm = new frmPersonelDetay();
                frm.gelenKisiTcNumarası = kisiTcSorgula;
                frm.ShowDialog();

                this.FindForm().Close();

                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name=="frmPersonelListesi")
                    {
                        form.Controls.Clear();
                    }
                } 

                

                    frmPersonelListesi frm2 = new frmPersonelListesi();
                frm2.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                frm2.gelenOtelKodu = lblOtelKodu.Text;
                frm2.ShowDialog();
            }
            else
            {
                btn_Cikart.Text = "ÇIKAR";
                btn_Detay.Text = "DETAY";
                this.Height = 85;
                lblUyariMesaji.Visible = false;
            }
        }
    }
}


