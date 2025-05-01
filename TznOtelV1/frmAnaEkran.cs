using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TznOtelV1;
namespace TznOtelV1
{
    public partial class frmAnaEkran: Form
    {
        public frmAnaEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (pnlYanMenu.Width==0)
            {
                pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_4_rewind_48;
                pnlUstmenu.BackColor = Color.FromArgb(17, 55, 64);
                ALTMENU.BackColor = Color.FromArgb(17, 55, 64);
                btn_cıkıs.BackColor = Color.FromArgb(39,187,216);
                menuKapat.Stop();
                menuAc.Start();
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
                pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
                ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
                btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
                menuKapat.Stop();
                menuAc.Stop();
                menuKapat.Start();
            }
        }

        private void menuAc_Tick(object sender, EventArgs e)
        {
            pnlYanMenu.Width += 10;
            if (pnlYanMenu.Width == 200)
            {
                menuAc.Stop();
            }
        }
        private void menuKapat_Tick(object sender, EventArgs e)
        {
            pnlYanMenu.Width -= 10;
            if (pnlYanMenu.Width == 200)
            {
                menuKapat.Stop();
            }
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbOlustur_MouseMove(object sender, MouseEventArgs e)
        {
            pbOlustur.Image = Properties.Resources.Ionic_Ionicons_Add_circle_sharp_48;
        }

        private void pbOlustur_MouseLeave(object sender, EventArgs e)
        {
            pbOlustur.Image = Properties.Resources.Steve_Zondicons_Add_Outline1;
        }
        void onaySorgulamaIstemi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kodlar WHERE kisiTc=@p1 AND onayKodu=kodTekrar", baglanti);
            komut.Parameters.AddWithValue("@p1", lblTcNo.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                pictureBox1.Enabled = false;
                pbOlustur.Visible = false;
            }
            baglanti.Close();
        }
        void calisanOtelKaydiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelPersonel LIKE '%" + lblTcNo.Text + "%'", baglanti);
            komut.Parameters.AddWithValue("@p1", lblTcNo.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblOtel.Text = oku["otelKodu"].ToString();
                lblOtelTipi.Text = oku["otelTipi"].ToString();
            }
            baglanti.Close();
        }
        private void frmAnaEkran_Load(object sender, EventArgs e)
        {
            pnlYanMenu.Width = 0;
            flowLayoutPanel1.Visible = false;
            tcNoGetir();
            otelGetir();
            otelKaydiSorgulama();

            if (lblYetki.Text == "0")
            {
                calisanOtelKaydiGetir();
                pbOlustur.Visible = false;
                pBildirim.Visible = false;
                pictureBox1.Enabled = true;
                btnBilgiDuzenle.Visible = false;
                btnKodOlustur.Visible = false;
                button1.Visible = false;
                btnPersonelKayit.Visible = false;
                btnPersonelListesi.Visible = false;
                btnKisiselBilgiDüzenleme.Visible = false;
                btnKullaniciBilgiDüzenleme.Visible = false;
                btn_odakayit.Visible = false;
                btnOdalarListesi.Visible = false;

            }
            else
            {
                btnKullaniciIslemleri.Visible = false;
            }

            if (lblOtel.Text == "lblOtel")
            {
                btnKodOlustur.Visible = false;
                ALTMENU.Visible = false;
            }
            else
            {
                if (lblYetki.Text == "1")
                {
                    btnKodOlustur.Visible = true;
                    ALTMENU.Visible = true;
                }
                else
                {
                    btnKodOlustur.Visible = false;
                    ALTMENU.Visible = true;
                }
               
            }
            //OTEL TİPİ BELİRLEME
            if (lblOtelTipi.Text == "0")
            {
                btnKodOlustur.Visible = false; //button aktif
            }
            else
            {
                if (lblYetki.Text=="1")
                {
                    btnKodOlustur.Visible = true; //button pasif
                }
                else
                {
                    btnKodOlustur.Visible = false; //button aktif
                }

            }

            int x = this.Width - 90;
            int y = this.Height - 110;
            pbOlustur.Location = new Point(x, y);
            pnlSecenek.Location = new Point(x - 180, y - 40);
            if (pbOlustur.Visible == true)
            {
                pictureBox1.Enabled = false;
            }
            else
            {
                pictureBox1.Enabled = true;
            }
            //Kisi Liste Konumlandırma
            int x2 = this.Width - 470;
            int y2 = this.Height - 1032;
            flowLayoutPanel1.Location = new Point(x2, y2);
            //Kisi Sayısı
            kisiListesiDoldur();
            int sayi = flowLayoutPanel1.Controls.Count;
            if (sayi == 0)
            {
                
                pBildirim.Image = Properties.Resources.bell;
            }
            else
            {
                
                pBildirim.Image = Properties.Resources.notification;
            }
            onaySorgulamaIstemi();
        }
        void otelKaydiSorgulama()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelSahip LIKE '%"+lblTcNo.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                pbOlustur.Visible = false;
            }
            else
            {
                pbOlustur.Visible = true;
            }
                baglanti.Close();
        }
        void otelGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelSahip LIKE '%" + lblTcNo.Text + "%'", baglanti);
            komut.Parameters.AddWithValue("@p1", lblTcNo.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblOtel.Text = oku["otelKodu"].ToString();
                lblOtelTipi.Text = oku["otelTipi"].ToString();
            }
            baglanti.Close();
        }
        void tcNoGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiKul=@p1 AND kisiYetki=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", lblKulAdi.Text);
            komut.Parameters.AddWithValue("@p2", lblYetki.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblTcNo.Text = oku["kisiTc"].ToString();
                lblAdSoyad.Text = oku["kisiAd"].ToString()+ " "+ oku["kisiSoyad"].ToString();
            }
            baglanti.Close();
        }
        private void pbOlustur_Click(object sender, EventArgs e)
        {
            pnlSecenek.Visible = true;
        }

        private void frmAnaEkran_MouseClick(object sender, MouseEventArgs e)
        {
            pnlSecenek.Visible = false;
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            pbOlustur.Visible = false;
            pnlSecenek.Visible = false;
            frmOtelKayitEkrani otelkayit = new frmOtelKayitEkrani();
            otelkayit.lblKisiTc.Text = lblTcNo.Text;
            otelkayit.ShowDialog();
        }

        private void frmAnaEkran_Activated(object sender, EventArgs e)
        {
           
            flowLayoutPanel1.Visible = false;
            tcNoGetir();
            otelGetir();
            otelKaydiSorgulama();


            if (lblOtel.Text == "lblOtel")
            {
                btnKodOlustur.Visible = false;
                ALTMENU.Visible = false;
            }
            else
            {
                if (lblYetki.Text == "1")
                {
                    btnKodOlustur.Visible = true;
                    ALTMENU.Visible = true;
                }
                else
                {
                    btnKodOlustur.Visible = false;
                    ALTMENU.Visible = true;
                }

            }
            //OTEL TİPİ BELİRLEME
            if (lblOtelTipi.Text == "0")
            {
                btnKodOlustur.Visible = false; //button aktif
            }
            else
            {
                if (lblYetki.Text == "1")
                {
                    btnKodOlustur.Visible = true; //button pasif
                }
                else
                {
                    btnKodOlustur.Visible = false; //button aktif
                }

            }

            int x = this.Width - 90;
            int y = this.Height - 110;
            pbOlustur.Location = new Point(x, y);
            pnlSecenek.Location = new Point(x - 180, y - 40);
            if (pbOlustur.Visible == true)
            {
                pictureBox1.Enabled = false;
            }
            else
            {
                pictureBox1.Enabled = true;
            }
            //Kisi Liste Konumlandırma
            int x2 = this.Width - 470;
            int y2 = this.Height - 1032;
            flowLayoutPanel1.Location = new Point(x2, y2);
            //Kisi Sayısı
            kisiListesiDoldur();
            int sayi = flowLayoutPanel1.Controls.Count;
            if (sayi == 0)
            {

                pBildirim.Image = Properties.Resources.bell;
            }
            else
            {

                pBildirim.Image = Properties.Resources.notification;
            }
            onaySorgulamaIstemi();
            if (lblYetki.Text == "0")
            {
                calisanOtelKaydiGetir();
                pbOlustur.Visible = false;
                pBildirim.Visible = false;
                pictureBox1.Enabled = true;
                btnBilgiDuzenle.Visible = false;
                btnKodOlustur.Visible = false;
                button1.Visible = false;
                btnPersonelKayit.Visible = false;
                btnPersonelListesi.Visible = false;
                btnKisiselBilgiDüzenleme.Visible = false;
                btnKullaniciBilgiDüzenleme.Visible = false;
                btn_odakayit.Visible = false;
            }
            else
            {
                btnKullaniciIslemleri.Visible = false;
            }

        }
        private void btnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();

            frmOtelKayitEkrani frm = new frmOtelKayitEkrani();
            frm.lblIstemTuru.Text = "1";
            frm.lblKisiTc.Text = lblTcNo.Text;
            frm.ShowDialog();
        }

        private void btnOrtak_Click(object sender, EventArgs e)
        {
            pbOlustur.Visible = false;
            pnlSecenek.Visible = false;
            frmOrtakGiris giris = new frmOrtakGiris();
            giris.ortakTc = lblTcNo.Text;
            giris.ShowDialog();
        }

        private void btnKodOlustur_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmKodOlustur frm = new frmKodOlustur();
            frm.lblGelenTc.Text = lblTcNo.Text;
            frm.txtOtelKodu.Text = lblOtel.Text;
            frm.ShowDialog();
        }

        void kisiListesiDoldur()
        {
            flowLayoutPanel1.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kodlar WHERE otelKodu=@p1 AND onayKodu=kodTekrar", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOtel.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                kisiSablon kisi = new kisiSablon();
                kisi.lblKisiTc.Text = oku["kisiTc"].ToString();
                kisi.gelenKod = lblOtel.Text;
                kisi.gelenBizimTc = lblTcNo.Text;
                kisi.otelKodu = lblOtel.Text;
                flowLayoutPanel1.Controls.Add(kisi);
            }
            baglanti.Close();
        }
        private void pBildirim_Click(object sender, EventArgs e)
        {
            int sayi = flowLayoutPanel1.Controls.Count;
            if (sayi ==0)
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "ORTAK BAŞVURUSU YAPILMAMIŞTIR";
            }
            else
            {
                
                if (flowLayoutPanel1.Visible == true)
                {
                    flowLayoutPanel1.Visible = false;
                    pBildirim.Image = Properties.Resources.notification;
                }
                else
                {

                    flowLayoutPanel1.Visible = true;
                    pBildirim.Image = Properties.Resources.bell;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmOrtaklar frm = new frmOrtaklar();
            frm.gelenOtelKodu = lblOtel.Text;
            frm.lblBizimTcmiz.Text = lblTcNo.Text;
            frm.ShowDialog();

        }

        private void btnPersonelKayit_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmPersonelKayit frm = new frmPersonelKayit();
            frm.gelenOtelKodu = lblOtel.Text;
            frm.ShowDialog();
        }

        private void btnPersonelListesi_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmPersonelListesi frm = new frmPersonelListesi();
            frm.gelenOtelKodu = lblOtel.Text;
            frm.lblBizimTcmiz.Text = lblTcNo.Text;
            frm.ShowDialog();
        }


        private void btnKullaniciIslemleri_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();

            frmPersonelBilgiDüzenlemeEkrani frm = new frmPersonelBilgiDüzenlemeEkrani();

            frm.gelenKisiTcNumarası = lblTcNo.Text;
            frm.ShowDialog();
        }

        private void btnKisiselBilgiDüzenleme_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();

            frmKisiselBilgiDuzenleme frm = new frmKisiselBilgiDuzenleme();
            frm.gelenKisiTcNumarası = lblTcNo.Text;
            frm.ShowDialog();
        }

        private void btnKullaniciBilgiDüzenleme_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmKullaniciBilgiDuzenleme frm = new frmKullaniciBilgiDuzenleme();
            frm.gelenKisiTcNumarası = lblTcNo.Text;
            frm.ShowDialog();
        }
        private void btn_odakayit_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();

            frmOdaKayit frm = new frmOdaKayit();
            frm.gelenKisiTcNumarası = lblTcNo.Text;
            frm.gelenOtelKodu = lblOtel.Text;
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();
            frmOdaListeEkrani frm = new frmOdaListeEkrani();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            pictureBox1.Image = Properties.Resources.Graphicloads_Colorful_Long_Shadow_Button_5_forward_48;
            pnlUstmenu.BackColor = Color.FromArgb(39, 187, 216);
            ALTMENU.BackColor = Color.FromArgb(39, 187, 216);
            btn_cıkıs.BackColor = Color.FromArgb(17, 55, 64);
            menuKapat.Stop();
            menuAc.Stop();
            menuKapat.Start();

            frmKonaklayanlarListesi frm = new frmKonaklayanlarListesi();
            //frm.gelenKisiTcNumarası = lblTcNo.Text;
            //frm.gelenOtelKodu = lblOtel.Text;
            frm.ShowDialog();
        }
    }
}
