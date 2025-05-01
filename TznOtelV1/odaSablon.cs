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
    public partial class odaSablon : UserControl
    {
        public odaSablon()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        void odaYatakKapasitesi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Yataksayisi WHERE odaKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblOdaKodu.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblOdaYatakSayisi.Text = oku["toplamYatak"].ToString();
                lblBosYatakSayisi.Text = oku["bosYatak"].ToString();
            }
            baglanti.Close();
        }
        private void odaSablon_Load(object sender, EventArgs e)
        {
            odaYatakKapasitesi();
            if (lblOdaTuru.Text == "1")
            {
                if (lblBosYatakSayisi.Text.Trim() == "0")
                {
                    lblOdaTuru.Text = "AÇIK";
                    pbOdaTuru.Image = Properties.Resources.acik;
                    pnlUstMenu.BackColor = Color.FromArgb(237, 85, 109);
                    label1.ForeColor = Color.FromArgb(237, 85, 109);
                    lblOdaYatakSayisi.ForeColor = Color.FromArgb(237, 85, 109);
                    btnOdaDetay.BackColor = Color.FromArgb(237, 85, 109);
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.FromArgb(237, 85, 109);
                    btnSil.BackColor = Color.FromArgb(237, 85, 109);
                    btnUygula.BackColor = Color.FromArgb(237, 85, 109);
                    btnKapat.BackColor = Color.FromArgb(237, 85, 109);
                    button1.BackColor = Color.FromArgb(237, 85, 109);
                    rbacik.ForeColor = Color.FromArgb(237, 85, 109);
                    rbKapali.ForeColor = Color.FromArgb(237, 85, 109);
                    rbbakimda.ForeColor = Color.FromArgb(237, 85, 109);
                    rbTemiz.ForeColor = Color.FromArgb(237, 85, 109);
                    rbKirli.ForeColor = Color.FromArgb(237, 85, 109);

                }
                else
                {
                    lblOdaTuru.Text = "AÇIK";
                    pbOdaTuru.Image = Properties.Resources.acik;
                    pnlUstMenu.BackColor = Color.FromArgb(43, 178, 123);
                    label1.ForeColor = Color.FromArgb(43, 178, 123);
                    lblOdaYatakSayisi.ForeColor = Color.FromArgb(43, 178, 123);
                    btnOdaDetay.BackColor = Color.FromArgb(43, 178, 123);
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.FromArgb(43, 178, 123);
                    btnSil.BackColor = Color.FromArgb(43, 178, 123);
                    btnUygula.BackColor = Color.FromArgb(43, 178, 123);
                    btnKapat.BackColor = Color.FromArgb(43, 178, 123);
                    button1.BackColor = Color.FromArgb(43, 178, 123);
                    rbacik.ForeColor = Color.FromArgb(43, 178, 123);
                    rbKapali.ForeColor = Color.FromArgb(43, 178, 123);
                    rbbakimda.ForeColor = Color.FromArgb(43, 178, 123);
                    rbTemiz.ForeColor = Color.FromArgb(43, 178, 123);
                    rbKirli.ForeColor = Color.FromArgb(43, 178, 123);

                }

            }
            else if (lblOdaTuru.Text == "0")
            {
                lblOdaTuru.Text = "KAPALI";
                pbOdaTuru.Image = Properties.Resources.kapali;
                pnlUstMenu.BackColor = Color.FromArgb(26, 111, 166);
                label1.ForeColor = Color.FromArgb(26, 111, 166);
                lblOdaYatakSayisi.ForeColor = Color.FromArgb(26, 111, 166);
                btnOdaDetay.BackColor = Color.FromArgb(26, 111, 166);
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.FromArgb(26, 111, 166);
                btnSil.BackColor = Color.FromArgb(26, 111, 166);
                btnUygula.BackColor = Color.FromArgb(26, 111, 166);
                btnKapat.BackColor = Color.FromArgb(26, 111, 166);
                button1.BackColor = Color.FromArgb(26, 111, 166);
                rbacik.ForeColor = Color.FromArgb(26, 111, 166);
                rbKapali.ForeColor = Color.FromArgb(26, 111, 166);
                rbbakimda.ForeColor = Color.FromArgb(26, 111, 166);
                rbTemiz.ForeColor = Color.FromArgb(26, 111, 166);
                rbKirli.ForeColor = Color.FromArgb(26, 111, 166);
            }
            else
            {
                lblOdaTuru.Text = "BAKIMDA";
                pbOdaTuru.Image = Properties.Resources.Gartoon_Team_Gartoon_Action_Edit_clear_broom_48;
                pnlUstMenu.BackColor = Color.FromArgb(242, 167, 75);
                label1.ForeColor = Color.FromArgb(242, 167, 75);
                lblOdaYatakSayisi.ForeColor = Color.FromArgb(242, 167, 75);
                btnOdaDetay.BackColor = Color.FromArgb(242, 167, 75);
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.FromArgb(242, 167, 75);
                btnSil.BackColor = Color.FromArgb(242, 167, 75);
                btnUygula.BackColor = Color.FromArgb(242, 167, 75);
                btnKapat.BackColor = Color.FromArgb(242, 167, 75);
                button1.BackColor = Color.FromArgb(242, 167, 75);
                rbacik.ForeColor = Color.FromArgb(242, 167, 75);
                rbKapali.ForeColor = Color.FromArgb(242, 167, 75);
                rbbakimda.ForeColor = Color.FromArgb(242, 167, 75);
                rbTemiz.ForeColor = Color.FromArgb(242, 167, 75);
                rbKirli.ForeColor = Color.FromArgb(242, 167, 75);

            }
        }

        private void btnOdaDetay_Click(object sender, EventArgs e)
        {
            frmOdaDetaySayfasi detay = new frmOdaDetaySayfasi();
            detay.gelenOdaKodu = lblOdaKodu.Text;
            detay.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel6.Dock = DockStyle.Fill;
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
            if (lblOdaDurumu.Text == "1")
            {
                rbTemiz.Checked = true;
                rbKirli.Checked = false;
            }
            else
            {
                rbTemiz.Checked = false;
                rbKirli.Checked = true;
            }

            if (lblOdaTuru.Text == "KAPALI")
            {
                rbKapali.Checked = true;
                rbacik.Checked = false;
                rbbakimda.Checked = false;
            }
            else if (lblOdaTuru.Text == "AÇIK")
            {
                rbKapali.Checked = false;
                rbacik.Checked = true;
                rbbakimda.Checked = false;
            }
            else
            {
                rbKapali.Checked = false;
                rbacik.Checked = false;
                rbbakimda.Checked = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            int lbldys = int.Parse(lblOdaYatakSayisi.Text);
            int lblbys = int.Parse(lblBosYatakSayisi.Text);
            if (lblbys == lbldys)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Tbl_Odalar SET odaDurumu=@odaDurumu, odaTuru=@odaTuru WHERE odakodu=@odaKodu", baglanti);
                komut.Parameters.AddWithValue("@odaKodu", lblOdaKodu.Text);
                if (rbacik.Checked)
                {
                    komut.Parameters.AddWithValue("@odaTuru", "1");
                }
                else if (rbKapali.Checked)
                {
                    komut.Parameters.AddWithValue("@odaTuru", "0");
                }
                else
                {
                    komut.Parameters.AddWithValue("@odaTuru", "2");
                }
                if (rbTemiz.Checked)
                {
                    komut.Parameters.AddWithValue("@odaDurumu", "1");
                }
                else
                {
                    komut.Parameters.AddWithValue("@odaDurumu", "0");
                }
                komut.ExecuteNonQuery();
                baglanti.Close();
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "İŞLEM BAŞARILI";
                frm.Show();
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "ODADA KAYITLI KİŞİ MEVCUT OLDUĞU İÇİN ODA TÜRÜNÜ VE DURUMU DEĞİŞTİRİLEMEZ";
                frm.Show();
                panel2.Visible = false;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int lbldys = int.Parse(lblOdaYatakSayisi.Text);
            int lblbys = int.Parse(lblBosYatakSayisi.Text);
            baglanti.Open();
            if (lblbys == lbldys)
            {
                SqlCommand komut = new SqlCommand("DELETE  FROM Tbl_Odalar WHERE odaKodu=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", lblOdaKodu.Text);
                komut.ExecuteNonQuery();

                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "ODA SİLME İŞLEMİ BAŞARILI";
                frm.Show();
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.label1.Text = "ODADA KAYITLI KİŞİ MEVCUT OLDUĞU İÇİN ODA TÜRÜNÜ VE DURUMU DEĞİŞTİRİLEMEZ";
                frm.Show();
                panel6.Visible = false;
            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }
    }
}
