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
    public partial class frmOdaBilgiDüzenlemeEkranı : Form
    {
        public frmOdaBilgiDüzenlemeEkranı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        public string gelenOdaKodu = "";
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOdaBilgiDüzenlemeEkranı_Load(object sender, EventArgs e)
        {
            lblOdaKodu.Text = gelenOdaKodu;
            odaSorgulamaIslemi();
        }
        void odaSorgulamaIslemi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Odalar WHERE odaKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenOdaKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblOtelKodu.Text = oku["otelKodu"].ToString();
                lblKisiTc.Text = oku["odaOlusturankisi"].ToString();
                lblOdaAdi.Text = oku["odaAdi"].ToString();
                lblOdaYatakSayisi.Text = oku["odaYataksayisi"].ToString();
                lblOdaDurumu.Text = oku["odaDurumu"].ToString();
                lblOdaTuru.Text = oku["odaTuru"].ToString();
                lblOdaOzellik.Text = oku["odaOzellik"].ToString();
                txtOdaFiyati.Text = oku["odaFiyati"].ToString();
                txtOdaAciklama.Text = oku["odaBilgi"].ToString();


                //**********************
                txtOdaAdi.Text = oku["odaAdi"].ToString();
                textBox1.Text = oku["odaFiyati"].ToString();
                textBox2.Text = txtOdaAciklama.Text = oku["odaBilgi"].ToString();
            }
            baglanti.Close();

            //yatak sayısı belirleme
            foreach (RadioButton item in groupBox2.Controls)
            {
                if (lblOdaYatakSayisi.Text.Trim() == item.Text)
                {
                    item.Checked = true;
                    item.ForeColor = Color.FromArgb(17, 55, 64);
                }
                else
                {
                    item.Checked = false;
                    item.ForeColor = Color.FromArgb(19, 187, 216);
                }

            }
            //oda durumu belirleme
            if (lblOdaDurumu.Text == "1")
            {
                pb1.Visible = true;
                pb2.Visible = false;
            }
            else
            {
                pb1.Visible = false;
                pb2.Visible = true;
            }
            //oda türü belirleme 
            if (lblOdaTuru.Text == "0")
            {
                pb3.Visible = true;
                pb4.Visible = false;
                pb5.Visible = false;
            }
            else if (lblOdaTuru.Text == "1")
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
            listegelen.Items.Clear();
            string[] gelenozellikler = lblOdaOzellik.Text.Split(',');
            foreach (string bulunan in gelenozellikler)
            {
                listegelen.Items.Add(bulunan);
                listesecilen.Items.Add(bulunan);
            }
            foreach (CheckBox item in groupBox3.Controls)
            {
                if (listegelen.Items.Contains(item.Text))
                {
                    item.Checked = true;
                    item.ForeColor = Color.Black;
                }
                else
                {
                    if (item.Text == "HEPSİ")
                    {
                        item.Checked = false;
                        item.ForeColor = Color.Black;
                    }
                    else
                    {
                        item.Checked = false;
                        item.ForeColor = Color.FromArgb(19, 187, 216);
                    }

                }
            }

            if (listegelen.Items.Count == 7)
            {
                cbHepsiSec.Checked = true;
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
                cb.ForeColor = Color.FromArgb(19, 187, 216);
            }
        }
        private void cbLeave(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == false)
            {
                cb.ForeColor = Color.FromArgb(19, 187, 216);
            }
            else
            {
                cb.ForeColor = Color.Black;
            }
        }
        private void cbClick(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                listesecilen.Items.Add(cb.Text);
            }
            else
            {
                listesecilen.Items.Remove(cb.Text);
            }
        }
        private void rbYatakSayisi(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lblOdaYatakSayisi.Text = rb.Text;
            foreach (Control item in groupBox2.Controls)
            {
                if (item is RadioButton)
                {
                    if (item.Text == lblOdaYatakSayisi.Text)
                    {
                        item.ForeColor = Color.Black;
                    }
                    else
                    {
                        item.ForeColor = Color.FromArgb(19, 187, 216);
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
            if (rb.Checked == false)
            {
                rb.ForeColor = Color.FromArgb(19, 187, 216);
            }
            else
            {
                rb.ForeColor = Color.Black;
            }
        }
        private void odaDurumClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblOdaDurumu.Text = btn.Text;

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


            if (lblOdaTuru.Text == "AÇIK")
            {
                pb3.Visible = true;
                pb4.Visible = false;
                pb5.Visible = false;
            }
            else if (lblOdaTuru.Text == "KAPALI")
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
        string odaAdi, odaFiyati, odaAciklamasi, odaozellikleri;
        public string gelenKisiTc;

        private void cbHepsiSec_CheckedChanged(object sender, EventArgs e)
        {
            listesecilen.Items.Clear();
            foreach (CheckBox item in groupBox3.Controls)
            {
                if (item.Text != cbHepsiSec.Text)
                {
                    if (cbHepsiSec.Checked)
                    {
                        item.Checked = true;
                        item.Enabled = false;
                        listesecilen.Items.Add(item.Text);
                        cbHepsiSec.ForeColor = Color.Black;
                    }
                    else
                    {
                        cbHepsiSec.Checked = false;
                        cbHepsiSec.ForeColor = Color.FromArgb(19, 187, 216);
                        item.Checked = false;
                        item.Enabled = true;
                        listesecilen.Items.Clear();
                        lblOdaOzellik.Text = "ÖZELLİK YOK";
                        item.ForeColor = Color.FromArgb(19, 187, 216);
                    }
                }
            }
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            if (txtOdaAdi.Text != "")
            {
                odaAdi = txtOdaAdi.Text.ToUpper();
            }
            else
            {
                odaAdi = lblOdaAdi.Text.ToUpper();
            }

            if (textBox1.Text != "")
            {
                odaFiyati = textBox1.Text;
            }
            else
            {
                odaFiyati = txtOdaFiyati.Text;
            }

            if (textBox2.Text != "")
            {
                odaAciklamasi = textBox2.Text.ToUpper();
            }
            else
            {
                odaAciklamasi = txtOdaAciklama.Text.ToUpper();
            }

            if (listesecilen.Items.Count == 0)
            {
                if (listegelen.Items.Count == 0)
                {
                    odaozellikleri = "ÖZELLİK YOK";
                }
                else
                {
                    odaozellikleri = lblOdaOzellik.Text;
                }
            }
            else
            {
                odaozellikleri = "";
                foreach (string item in listesecilen.Items)
                {
                    odaozellikleri += "," + item;
                }
                odaozellikleri = odaozellikleri.Substring(1);
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Odalar SET odaKodu=@odaKodu,odaAdi =@odaAdi,odaDurumu =@odaDurumu, odaTuru = @odaTuru, odaFiyati = @odaFiyati,odaBilgi = @odaBilgi, odaYataksayisi = @odaYataksayisi,odaOzellik = @odaOzellik, odaOlusturankisi = @odaOlusturankisi  WHERE odaKodu=@odaKodu", baglanti);
            komut.Parameters.AddWithValue("@odaKodu", lblOdaKodu.Text);
            komut.Parameters.AddWithValue("@odaAdi", odaAdi);
            if (lblOdaDurumu.Text == "KİRLİ")
            {
                komut.Parameters.AddWithValue("@odaDurumu", "0");
            }
            else
            {
                komut.Parameters.AddWithValue("@odaDurumu", "1");
            }
            if (lblOdaTuru.Text == "KAPALI")
            {
                komut.Parameters.AddWithValue("@odaTuru", "0");
            }
            else if (lblOdaTuru.Text == "AÇIK")
            {
                komut.Parameters.AddWithValue("@odaTuru", "1");
            }
            else
            {
                komut.Parameters.AddWithValue("@odaTuru", "2");
            }
            komut.Parameters.AddWithValue("@odaFiyati", odaFiyati);
            komut.Parameters.AddWithValue("@odaYataksayisi", lblOdaYatakSayisi.Text);
            komut.Parameters.AddWithValue("@odaOzellik", odaozellikleri);
            komut.Parameters.AddWithValue("@odaOlusturankisi", gelenKisiTc);
            komut.Parameters.AddWithValue("@odaBilgi", odaAciklamasi);
            komut.ExecuteNonQuery();
            baglanti.Close();
            odaSorgulamaIslemi();
            frmPopupmenu frm = new frmPopupmenu();
            frm.label1.Text = "ODA GÜNCELLEME İŞLEMİ BAŞARILI";
            frm.Show();
        }

    }
}
