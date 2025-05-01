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
    public partial class frmPersonelListesi: Form
    {
        public frmPersonelListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string gelenOtelKodu = "";
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonelListesi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenOtelKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblortakKisiTcler.Text = oku["otelPersonel"].ToString();
            }
            baglanti.Close();
            foreach (string kisiTc in lblortakKisiTcler.Text.Split(','))
            {
                if (kisiTc != "")
                {
                    calisanSablon sablon = new calisanSablon();
                    sablon.lblKisiTcNo.Text = kisiTc;
                    sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                    sablon.lblOtelKodu.Text = gelenOtelKodu;
                    pnlKisiListesi.Controls.Add(sablon);
                }

                listBox1.Items.Add(kisiTc);

            }
            if (lblortakKisiTcler.Text=="")
            {
                pnlKisiListesi.Visible = false;
                pnlAramaEkrani.Visible = false;
                pnlAciklamaEkrani.Visible = true;
                pbAramaMenu.Visible = false;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;
            }
            else
            {
                pnlKisiListesi.Visible = true;
                pnlAramaEkrani.Visible = false;
                pnlAciklamaEkrani.Visible = false;
                pbAramaMenu.Visible = false;
                pnlKisiListesi.Dock = DockStyle.Fill;
            }
        }

        private void pbAramaMenu_Click(object sender, EventArgs e)
        {
            if (pnlAramaEkrani.Visible==false)
            {
                pnlAramaEkrani.Visible = true;
            }
            else
            {
                pnlAramaEkrani.Visible = false;
            }
        }
        private void frmPersonelListesi_Activated(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Oteller WHERE otelKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenOtelKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblortakKisiTcler.Text = oku["otelPersonel"].ToString();
            }
            baglanti.Close();
            if (lblortakKisiTcler.Text == "")
            {
                pnlKisiListesi.Visible = false;
                pnlAramaEkrani.Visible = false;
                pnlAciklamaEkrani.Visible = true;
                pbAramaMenu.Visible = false;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;
            }
            else
            {
                pnlKisiListesi.Visible = true;
                pnlAramaEkrani.Visible = false;
                pnlAciklamaEkrani.Visible = false;
                pbAramaMenu.Visible = true;
                pnlKisiListesi.Dock = DockStyle.Fill;
            }
        }

        private void kisiTcNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (kisiTcNumarasi.Text!="")
            {
                pnlKisiListesi.Controls.Clear();
                foreach (string kisiler in listBox1.Items)
                {
                    if (kisiler.Contains(kisiTcNumarasi.Text))
                    {
                        if (kisiler != "")
                        {
                            calisanSablon sablon = new calisanSablon();
                            sablon.lblKisiTcNo.Text = kisiler;
                            sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                            sablon.lblOtelKodu.Text = gelenOtelKodu;
                            pnlKisiListesi.Controls.Add(sablon);
                        }
                        else
                        {
                            foreach (string kisiTc in listBox1.Items)
                            {
                                if (kisiTc != "")
                                {
                                    calisanSablon sablon = new calisanSablon();
                                    sablon.lblKisiTcNo.Text = kisiTc;
                                    sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                                    sablon.lblOtelKodu.Text = gelenOtelKodu;
                                    pnlKisiListesi.Controls.Add(sablon);
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                pnlKisiListesi.Controls.Clear();
                foreach (string kisiTc in listBox1.Items)
                {
                    if (kisiTc != "")
                    {
                        calisanSablon sablon = new calisanSablon();
                        sablon.lblKisiTcNo.Text = kisiTc;
                        sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                        sablon.lblOtelKodu.Text = gelenOtelKodu;
                        pnlKisiListesi.Controls.Add(sablon);
                    }

                }
            }
            if (pnlKisiListesi.Controls.Count == 0)
            {
                pnlAramaEkrani.BackColor = Color.Red;
                label2.ForeColor = Color.Red;
                pnlKisiListesi.Visible = false;
                pnlAciklamaEkrani.Visible = true;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;
            }
            else
            {
                pnlAramaEkrani.BackColor = Color.Green;
                pnlKisiListesi.Visible = true;
                pnlAciklamaEkrani.Visible = false;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;

            }
        }

        private void txtKisiAdi_TextChanged(object sender, EventArgs e)
        {
            pnlKisiListesi.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiYetki=0 AND kisiAd LIKE '%"+txtKisiAdi.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (listBox1.Items.Contains(oku["kisiTc"].ToString()))
                {
                    calisanSablon sablon = new calisanSablon();
                    sablon.lblKisiTcNo.Text = oku["kisiTc"].ToString();
                    sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                    sablon.lblOtelKodu.Text = gelenOtelKodu;
                    pnlKisiListesi.Controls.Add(sablon);
                }
            }
            baglanti.Close();
            if (pnlKisiListesi.Controls.Count == 0)
            {
                pnlAramaEkrani.BackColor = Color.Red;
                label2.ForeColor = Color.Red;
                pnlKisiListesi.Visible = false;
                pnlAciklamaEkrani.Visible = true;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;
            }
            else
            {
                pnlAramaEkrani.BackColor = Color.Green;
                pnlKisiListesi.Visible = true;
                pnlAciklamaEkrani.Visible = false;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtKisiAdi.Text = "";
            kisiTcNumarasi.Text = "";
            txtkisiSoyad.Text = "";
            pnlAramaEkrani.BackColor = Color.FromArgb(19, 187, 216);
        }

        private void kisiSoyad_TextChanged(object sender, EventArgs e)
        {
            pnlKisiListesi.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiYetki=0 AND kisiSoyad LIKE '%" + txtkisiSoyad.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (listBox1.Items.Contains(oku["kisiTc"].ToString()))
                {
                    calisanSablon sablon = new calisanSablon();
                    sablon.lblKisiTcNo.Text = oku["kisiTc"].ToString();
                    sablon.lblBizimTcmiz.Text = lblBizimTcmiz.Text;
                    sablon.lblOtelKodu.Text = gelenOtelKodu;
                    pnlKisiListesi.Controls.Add(sablon);
                }
            }
            baglanti.Close();
            if (pnlKisiListesi.Controls.Count == 0)
            {
                pnlAramaEkrani.BackColor = Color.Red;
                pnlKisiListesi.Visible = false;
                pnlAciklamaEkrani.Visible = true;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;
                label2.ForeColor = Color.Red;
            }
            else
            {
                pnlAramaEkrani.BackColor = Color.Green;
                pnlKisiListesi.Visible = true;
                pnlAciklamaEkrani.Visible = false;
                pnlAciklamaEkrani.Dock = DockStyle.Fill;

            }
        }

        private void txtkisiSoyad_MouseClick(object sender, MouseEventArgs e)
        {
            kisiTcNumarasi.Text = "";
        }

        private void txtKisiAdi_MouseClick(object sender, MouseEventArgs e)
        {
            kisiTcNumarasi.Text = "";
        }

        private void kisiTcNumarasi_MouseClick(object sender, MouseEventArgs e)
        {
            txtkisiSoyad.Text = "";
            txtKisiAdi.Text = "";
        }
    }
}
