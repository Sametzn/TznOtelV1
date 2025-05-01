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
    public partial class frmKodOlustur: Form
    {
        public frmKodOlustur()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKodOlustur_Load(object sender, EventArgs e)
        {
            bilgiGetir();
            onayKodOlustur();
        }
        void bilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtOtelAdi.Text = oku["otelAdi"].ToString();
                lblOrtakSayisi.Text = oku["otelSahip"].ToString();
            }
            baglanti.Close();
            int sayi = lblOrtakSayisi.Text.Split(',').Count();
            lblOrtakSayisi.Text = sayi.ToString();
        }
        void onayKodOlustur()
        {
            Random rastgele = new Random();
            string semboller = "ABCDEFGHIJKLM29386231985462349851234567890NOPRSTUVYZ";
            string olusankod = "";
            for (int i = 1; i < 6; i++)
            {
                olusankod += semboller[rastgele.Next(semboller.Length)];
            }
            txtOnayKod.Text = olusankod.ToString();
        }
        void kayitEkleme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Kodlar (otelKodu, otelAdi, onayKodu, kisiTc, olusturanTc,ortakSayisi,onaySayisi) VALUES (@otelKodu, @otelAdi, @onayKodu, @kisiTc, @olusturanTc,@ortakSayisi,@onaySayisi)", baglanti);
            komut.Parameters.AddWithValue("@otelKodu", txtOtelKodu.Text);
            komut.Parameters.AddWithValue("@otelAdi", txtOtelAdi.Text);
            komut.Parameters.AddWithValue("@onayKodu", txtOnayKod.Text);
            komut.Parameters.AddWithValue("@kisiTc", txtKisiTc.Text);
            komut.Parameters.AddWithValue("@olusturanTc", lblGelenTc.Text);
            komut.Parameters.AddWithValue("@ortakSayisi", lblOrtakSayisi.Text);
            komut.Parameters.AddWithValue("@onaySayisi", 0);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnOnay_Click(object sender, EventArgs e)
        {
            if (txtKisiTc.Text != "")
            {
                kayitEkleme();
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "ONAY KODU OLUŞTURULMUŞTUR";
                txtOnayKod.Text = "";
                onayKodOlustur();
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "Lütfen Bilgileri Doldurun";
            }
        }
        }
    }

