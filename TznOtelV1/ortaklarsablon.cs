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
using System.Reflection.Emit;
using TznOtelV1;

namespace TznOtelV1
{
    public partial class ortaklarsablon: UserControl
    {
        public ortaklarsablon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        string kisiTcSorgula ="";
        private void ortaklarsablon_Load(object sender, EventArgs e)
        {
            kisiBilgiGetir();
            if (lblBizimTcmiz.Text == kisiTcSorgula)
            {
                pictureBox1.Image = Properties.Resources.edfr;
                panel1.BackColor = Color.FromArgb(255, 128, 0);
                lblKisiTcNo.ForeColor= Color.FromArgb(254, 42, 19);
                btn_Cikart.BackColor = Color.FromArgb(255, 128, 0);
            }

            iptalEtme();
            if (iptalDurumu==true)
            {
                btn_Cikart.Visible = false;
                btn_iptalet.Visible = true;
            }
            else
            {
                btn_Cikart.Visible = true;
                btn_iptalet.Visible = false;
            }
        }
        bool iptalDurumu = false;

        void iptalEtme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Ortaklik WHERE kisiTc=@p1 AND otelKodu=@p2 AND onayVeren LIKE '%"+lblBizimTcmiz.Text+"%'", baglanti);
            komut.Parameters.AddWithValue("@p1", kisiTcSorgula);
            komut.Parameters.AddWithValue("@p2", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                iptalDurumu = true;
            }
            else
            {
                iptalDurumu = false;
            }
            baglanti.Close();
        }
        void kisiBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiTc=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblKisiTcNo.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblKisiTcNo.Text = oku["kisiAd"].ToString() + " " + oku["kisiSoyad"].ToString() +" - "+oku["kisiTc"].ToString();
                kisiTcSorgula = oku["kisiTc"].ToString();
            }
            baglanti.Close();
        }
        bool kisiKayitDurumu = false;

        void kisiKontrolEt()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Ortaklik WHERE kisiTc=@p1 AND otelKodu=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", kisiTcSorgula);
            komut.Parameters.AddWithValue("@p2", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kisiKayitDurumu = true;
            }
            else
            {
                kisiKayitDurumu = false;
            }
            baglanti.Close();
        }
        String sahipler = "";
        int ortakSayisi = 0;
        void ortakSayisiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                sahipler = oku["otelSahip"].ToString();
            }
            baglanti.Close();
                 ortakSayisi = sahipler.Split(',').Count();

        }
        string onayVerenler = "";

        void onayVerenlerMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Ortaklik WHERE otelKodu=@p1 AND kisiTc=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            komut.Parameters.AddWithValue("@p2", kisiTcSorgula);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                onayVerenler = oku["onayVeren"].ToString();
            }
            baglanti.Close();

        }
        string ortaklar = "";
        void ortaklarMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ortaklar = oku["otelSahip"].ToString();
                foreach (string kisi in ortaklar.Split(','))
                {
                    listBox1.Items.Add(kisi);
                }
            }
            baglanti.Close();

        }
        bool onayVerildiMi = false;
        void onayVerildiMiMetod()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Ortaklik WHERE otelKodu=@p1 AND kisiTc=@p2 AND onayVeren LIKE '%"+lblBizimTcmiz.Text+"%'", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            komut.Parameters.AddWithValue("@p2", kisiTcSorgula);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                onayVerildiMi = true;
            }
            else
            {
                onayVerildiMi = false;
            }
            baglanti.Close();

        }
        void kisiKaydiSilmeMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1 AND otelSahip=@p2  LIKE '%" + kisiTcSorgula+ "%'", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (!oku.Read())
            {
                this.Hide();
            }
            baglanti.Close();

        }
        private void btn_Cikart_Click(object sender, EventArgs e)
        {
            onayVerildiMiMetod();
            if (onayVerildiMi==true)
            {
                MessageBox.Show("ONAY DAHA ÖNCE VERİLMİŞ");
            }
            else
            {
                listBox1.Items.Clear();
                onayVerenlerMetodu();
                ortakSayisiGetir();

                ortaklarMetodu();
                listBox1.Items.Remove(kisiTcSorgula);
                if (listBox1.Items.Count == 0)
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.label1.Text = "ORTAK OLAN KİMSE YOKTUR İŞLEM GERÇEKLEŞTİRİLEMEDİ";
                }
                else
                {
                    string newKisi = "";
                    foreach (string kisi in listBox1.Items)
                    {
                        newKisi += "," + kisi;

                    }
                    label1.Text = newKisi.Substring(1);
                    kisiKontrolEt();
                    if (kisiKayitDurumu == true)
                    {
                        baglanti.Open();
                        SqlCommand guncelle = new SqlCommand("UPDATE Tbl_Ortaklik SET onayVeren=@p3, onaySayisi+=1 WHERE otelKodu=@p1 AND kisiTc=@p2", baglanti);
                        guncelle.Parameters.AddWithValue("@p1", lblOtelKodu.Text);
                        guncelle.Parameters.AddWithValue("@p2", kisiTcSorgula);
                        guncelle.Parameters.AddWithValue("@p3", onayVerenler + "," + lblBizimTcmiz.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();

                        //otel sahibi silme v  
                        baglanti.Open();
                        SqlCommand sorgula = new SqlCommand("UPDATE Tbl_Oteller SET Tbl_Oteller.otelSahip=@p1 FROM Tbl_Oteller INNER JOIN Tbl_Ortaklik ON Tbl_Oteller.otelKodu=Tbl_Ortaklik.otelKodu WHERE Tbl_Oteller.otelKodu=@p2 AND Tbl_Ortaklik.ortakSayisi=Tbl_Ortaklik.onaySayisi", baglanti);
                        sorgula.Parameters.AddWithValue("p1", label1.Text);
                        sorgula.Parameters.AddWithValue("p2", lblOtelKodu.Text);
                        sorgula.ExecuteNonQuery();
                        baglanti.Close();

                        //Ortaklik tablosundan silme işlemi

                        baglanti.Open();
                        SqlCommand silme = new SqlCommand("DELETE FROM Tbl_Ortaklik WHERE ortakSayisi=onaySayisi AND otelKodu=@p1 AND kisiTc=@p2", baglanti);
                        silme.Parameters.AddWithValue("p1", lblOtelKodu.Text);
                        silme.Parameters.AddWithValue("p2", kisiTcSorgula);
                        silme.ExecuteNonQuery();
                        baglanti.Close();

                        kisiKaydiSilmeMetodu();
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.label1.Text = "ORTAK ÇIKARMA İŞLEMİ TAMAMLANDI!";
                       

                    }
                    else
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Ortaklik (otelKodu,kisiTc,onayVeren,ortakSayisi,onaySayisi) VALUES  (@otelKodu,@kisiTc,@onayVeren,@ortakSayisi,@onaySayisi)", baglanti);
                        komut.Parameters.AddWithValue("@otelKodu", lblOtelKodu.Text);
                        komut.Parameters.AddWithValue("@kisiTc", kisiTcSorgula);
                        komut.Parameters.AddWithValue("@onayVeren", lblBizimTcmiz.Text);
                        komut.Parameters.AddWithValue("@ortakSayisi", ortakSayisi);
                        komut.Parameters.AddWithValue("@onaySayisi", 1);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.label1.Text = "ORTAKLIKTAN ÇIKARMA İŞLEMİ ONAYDA";

                    }
                }
            }
            iptalEtme();
            if (iptalDurumu == true)
            {
                btn_Cikart.Visible = false;
                btn_iptalet.Visible = true;
            }
            else
            {
                btn_Cikart.Visible = true;
                btn_iptalet.Visible = false;
            }
        }

        private void btn_iptalet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silme = new SqlCommand("DELETE FROM Tbl_Ortaklik WHERE otelKodu=@p1 AND kisiTc=@p2", baglanti);
            silme.Parameters.AddWithValue("p1", lblOtelKodu.Text);
            silme.Parameters.AddWithValue("p2", kisiTcSorgula);
            silme.ExecuteNonQuery();
            baglanti.Close();
            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "İŞLEM TAMAMLANDI";
            iptalEtme();
            if (iptalDurumu == true)
            {
                btn_Cikart.Visible = false;
                btn_iptalet.Visible = true;
            }
            else
            {
                btn_Cikart.Visible = true;
                btn_iptalet.Visible = false;
            }
        }
    }
}
