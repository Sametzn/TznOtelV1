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
    public partial class frmOrtakGiris: Form
    {
        public frmOrtakGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void pbKontrol_MouseMove(object sender, MouseEventArgs e)
        {
            pbKontrol.Image = Properties.Resources.plus__1_;
        }

        private void pbKontrol_MouseLeave(object sender, EventArgs e)
        {
            pbKontrol.Image = Properties.Resources.plus;
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void otelAdiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1 AND otelTipi=1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtOtelKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtOtelAdi.Text = oku["otelAdi"].ToString();
                txtOnayKodu.ReadOnly = false;
                btnOnay.Enabled = true;

            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "OTEL ADI BULUNAMADI!!";
                frm.Show();
                txtOnayKodu.ReadOnly = true;
                btnOnay.Enabled = false;
                txtOtelAdi.Text = "";
                txtOnayKodu.Text = "";
            }
            baglanti.Close();
            kayitliKodGetir();


        }
        public string ortakTc ="";
        void kayitliKodGetir()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kodlar WHERE otelKodu=@p1 AND kisiTc=@p2", baglan);
            komut.Parameters.AddWithValue("@p1", txtOtelKodu.Text);
            komut.Parameters.AddWithValue("@p2", ortakTc);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblKayitliKod.Text = oku["onayKodu"].ToString();
                txtOnayKodu.ReadOnly = false;
                btnOnay.Enabled = true;
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "HERHANGİ BİR KODA ULAŞIM SAĞLANAMADI!";
                frm.Show();
                lblKayitliKod.Text="";
                txtOnayKodu.ReadOnly = true;
                btnOnay.Enabled = false;
                txtOtelAdi.Text = "";
                txtOnayKodu.Text = "";
            }
        
            baglan.Close();
        }
        private void pbKontrol_Click(object sender, EventArgs e)
        {
            if (txtOtelKodu.Text!="")
            {
                otelAdiGetir();
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "OTEL KODU EKSİK VEYA HATALI !";
                frm.Show();
            }
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            if(txtOtelAdi.Text!="" &&txtOtelKodu.Text!="" && txtOnayKodu.Text != "")
            {
                if (txtOnayKodu.Text == lblKayitliKod.Text)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE Tbl_Kodlar SET kodTekrar=@p1 WHERE onayKodu=@p2", baglanti);
                    komut.Parameters.AddWithValue("p1", txtOnayKodu.Text);
                    komut.Parameters.AddWithValue("p2", lblKayitliKod.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.label1.Text = "İŞLEM BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİRİLDİ İSTEĞİNİZ ONAYA GÖNDERİLMİŞTİR";
                    frm.TopMost = true; //formu en üst kısımda göstermeye yarıyor.
                    frm.Show();
                    this.Close();
                    
                }
                else
                {

                    frmPopupmenu frm = new frmPopupmenu();
                    frm.label1.Text = "KODU EKSİK VEYA HATALI GİRDİNİZ";
                    frm.Show();
                }

            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "LÜTFEN TÜM ALANLARI EKSİKSİZ DOLDURUN !!";
                frm.Show();
            }
        }

    }
}
