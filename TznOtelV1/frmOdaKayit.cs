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
    public partial class frmOdaKayit: Form
    {
        public frmOdaKayit()
        {
            InitializeComponent();
        }
    
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string gelenKisiTcNumarası = "";
        public string gelenOtelKodu = "";
        private void frmOdaKayit_Load(object sender, EventArgs e)
        {
            lblOtelKodu.Text = gelenOtelKodu;
            lblKisiTc.Text = gelenKisiTcNumarası;
            odaKodOlustur();
            odaListesiGetir();
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void odaDurumClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblOdaDurumu.Text = btn.Text;

            //döngü ile gruplandırma işlemi

            if (lblOdaDurumu.Text == "TEMİZ")
            {
                pb1.Visible = true;
                pb2.Visible = false;
            }
            else
            {
                pb1.Visible = false;
                pb2.Visible = true;
            }
        }
        private void odaTuruClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblOdaTuru.Text = btn.Text;

            //döngü ile gruplandırma işlemi

            if (lblOdaTuru.Text=="AÇIK")
            {
                pb3.Visible = true;
                pb4.Visible = false;
                pb5.Visible = false;
            }
            else if (lblOdaTuru.Text=="KAPALI")
            {
                pb3.Visible = false;
                pb4.Visible = true;
                pb5.Visible = false;
            }
            else
            {
                pb3.Visible = false;
                pb4.Visible = false;
                pb5.Visible = true;
            }
        }
        void odaListesiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Odalar order by odaAdi ASC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                odaSablon oda = new odaSablon();
                oda.lblOdaKodu.Text = oku["odaKodu"].ToString();
                oda.lblOdaAdi.Text = oku["odaAdi"].ToString();
                oda.lblOdaFiyati.Text = oku["odaFiyati"].ToString()+" "+"₺";
                oda.lblOdaTuru.Text = oku["odaTuru"].ToString();
                odaListePaneli.Controls.Add(oda);
            }
            baglanti.Close();
        }
        private void rbYatakSayisi(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lblOdaYatakSayisi.Text = rb.Text;
            foreach (Control item in groupBox2.Controls)
            {
                if (item is RadioButton)
                {
                    if (item.Text==lblOdaYatakSayisi.Text)
                    {
                        item.ForeColor = Color.Black;
                    }
                    else
                    {
                        item.ForeColor=Color.FromArgb(242, 167, 75);
                    }
                }
            }
        }
        private void rbMove(object sender, MouseEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.ForeColor = Color.Black;
            }
            else
            {
                rb.ForeColor = Color.Black;
            }
        }
        private void rbLeave(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked==false)
            {
                rb.ForeColor = Color.FromArgb(242, 167, 75);
            }
            else
            {
                rb.ForeColor = Color.Black;
            }
        }
        private void cbClick(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                ListeKutusu.Items.Add(cb.Text);
                
            }
            else
            {
                ListeKutusu.Items.Remove(cb.Text);
            }
        }
        private void cbMove(object sender, MouseEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                cb.ForeColor = Color.Black;
            }
            else
            {
                cb.ForeColor = Color.Black;
            }
        }
        private void cbLeave(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == false)
            {
                cb.ForeColor = Color.FromArgb(242, 167, 75);
            }
            else
            {
                cb.ForeColor = Color.Black;
            }
        }
        void odaKodOlustur()
        {
            Random rastgele = new Random();
            string semboller = "012345678901234567890123456789012345678901234567890123456789";
            string olusankod = "";
            for (int i = 1; i < 6; i++)
            {
                olusankod += semboller[rastgele.Next(semboller.Length)];
            }
            lblOdaKodu.Text = olusankod.ToString();
        }
        private void cbHepsiSec_CheckedChanged(object sender, EventArgs e)
        {
            ListeKutusu.Items.Clear();
            foreach (CheckBox item in groupBox3.Controls)
            {
                if (item.Text!=cbHepsiSec.Text)
                {
                    if (cbHepsiSec.Checked)
                    {
                        item.Checked = true;
                        item.Enabled = false;
                        ListeKutusu.Items.Add(item.Text);
                    }
                    else
                    {
                        cbHepsiSec.Checked = false;
                        cbHepsiSec.ForeColor=Color.FromArgb(242, 167, 75);
                        item.Checked = false;
                        item.Enabled = true;
                        ListeKutusu.Items.Clear();
                        lblOdaOzellik.Text = "ÖZELLİK YOK";
                        item.ForeColor=Color.FromArgb(242, 167, 75);
                    }
                }
            }
        }
        void odaKaydiMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT odaKodu from Tbl_Odalar WHERE odaKodu=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", lblOdaKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                odaKodOlustur();
                odaEklemeMetodu();
            }
            else
            {
                odaEklemeMetodu();
            }
                baglanti.Close();
        }
        void odaEklemeMetodu()
        {
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO  Tbl_Odalar (otelKodu,odaKodu,odaAdi,odaDurumu,odaTuru,odaFiyati,odaBilgi,odaYataksayisi,odaOzellik,odaOlusturankisi) VALUES (@otelKodu,@odaKodu,@odaAdi,@odaDurumu,@odaTuru,@odaFiyati,@odaBilgi,@odaYataksayisi,@odaOzellik,@odaOlusturankisi)", baglanti);
            komut.Parameters.AddWithValue("@otelKodu", lblOtelKodu.Text);
            komut.Parameters.AddWithValue("@odaKodu", lblOdaKodu.Text);
            komut.Parameters.AddWithValue("@odaAdi", lblOdaAdi.Text);
            if (lblOdaDurumu.Text=="KİRLİ")
            {
                komut.Parameters.AddWithValue("@odaDurumu", "0");
            }
            else
            {
                komut.Parameters.AddWithValue("@odaDurumu", "1");
            }
            if (lblOdaTuru.Text=="KAPALI")
            {
                komut.Parameters.AddWithValue("@odaTuru", "0");
            }
            else if (lblOdaTuru.Text=="AÇIK")
            {
                komut.Parameters.AddWithValue("@odaTuru", "1");
            }
            else
            {
                komut.Parameters.AddWithValue("@odaTuru", "2");
            }
            komut.Parameters.AddWithValue("@odaFiyati", txtOdaFiyati.Text);
            komut.Parameters.AddWithValue("@odaBilgi", txtOdaAciklama.Text.ToUpper());
            komut.Parameters.AddWithValue("@odaYataksayisi", lblOdaYatakSayisi.Text);
            komut.Parameters.AddWithValue("@odaOzellik", lblOdaOzellik.Text);
            komut.Parameters.AddWithValue("@odaOlusturankisi", gelenKisiTcNumarası);
            komut.ExecuteNonQuery();
            SqlCommand yataksayisi = new SqlCommand("INSERT INTO Tbl_Yataksayisi (odaKodu,toplamYatak,bosYatak) VALUES (@odaKodu,@toplamYatak,@bosYatak)", baglanti);
            yataksayisi.Parameters.AddWithValue("@odaKodu", lblOdaKodu.Text);
            yataksayisi.Parameters.AddWithValue("@toplamYatak", lblOdaYatakSayisi.Text);
            yataksayisi.Parameters.AddWithValue("@bosYatak", lblOdaYatakSayisi.Text);
            yataksayisi.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnOluştur_Click(object sender, EventArgs e)
        {
         
            if (ListeKutusu.Items.Count != 0)
            {
                lblOdaOzellik.Text = "";
                foreach (string item in ListeKutusu.Items)
                {
                    lblOdaOzellik.Text += "," + item;
                }
                if (lblOdaOzellik.Text.Length > 1)
                {
                    lblOdaOzellik.Text = lblOdaOzellik.Text.Substring(1);
                }
            }
            else
            {
                lblOdaOzellik.Text = "ÖZELLİK YOK";
            }
            if (txtOdaAdi.Text != "" && lblOdaOzellik.Text!="lblOdaOzellik" && lblOdaDurumu.Text!= "lblOdaDurumu" && lblOdaTuru.Text!= "lblOdaTuru" )
            {
                lblOdaAdi.Text = txtOdaAdi.Text;
                odaKodOlustur();
                int x = (this.Width - pnlSonAsama.Width) / 2;
                int y = (this.Height - pnlSonAsama.Height) / 2;
                pnlSonAsama.Location =new Point(x,y);
                pnlSonAsama.Visible = true;
                pnl_Kayit.Visible = false;
                pnl_Listeler.Visible = false;
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "ODA ADI BOŞ GEÇİLEMEZ";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnlSonAsama.Visible=false;
            pnl_Kayit.Visible = true;
            pnl_Listeler.Visible = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtOdaFiyati.Text != "")
            {
                odaKaydiMetodu();
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "KAYIT İŞLEMİ BAŞARILI";
                txtOdaAciklama.ReadOnly = true;
                txtOdaFiyati.ReadOnly = true;
                btnKaydet.Visible = false;
                btnDuzenle.Visible = false;
                btnGuncelle.Visible = true;
                btnYeniKayit.Visible = true;

            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "ODA FİYATI BELİRLEYİNİZ";
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            pnlSonAsama.Visible = false;
            pnl_Kayit.Visible = true;
            pnl_Listeler.Visible = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frmOdaBilgiDüzenlemeEkranı frm = new frmOdaBilgiDüzenlemeEkranı();
            frm.gelenOdaKodu = lblOdaKodu.Text;
            frm.gelenKisiTc = lblKisiTc.Text;
            frm.ShowDialog();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            lblOtelKodu.Text = gelenOtelKodu;
            lblKisiTc.Text = gelenKisiTcNumarası;
            odaListesiGetir();
        }
        private void frmOdaKayit_Activated(object sender, EventArgs e)
        {
            lblOtelKodu.Text = gelenOtelKodu;
            lblKisiTc.Text = gelenKisiTcNumarası;
        }

    }
    }

