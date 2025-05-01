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

namespace TznOtelV1
{
    public partial class frmKullaniciGiris : Form
    {
        public frmKullaniciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmKisiKayit frm = new frmKisiKayit();
            frm.Show();
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtGiris.Text != "" && txtParolaGiris.Text != "")
            {
                if (bes.BackColor == Color.FromArgb(39, 187, 216))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kisiler WHERE kisiKul=@p1 collate SQL_Latin1_General_CP1_CS_AS AND kisiParola=@p2 collate SQL_Latin1_General_CP1_CS_AS AND kisiYetki=@p3", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtGiris.Text);
                    komut.Parameters.AddWithValue("@p2", txtParolaGiris.Text);
                    komut.Parameters.AddWithValue("@p3", lblSecilenGiris.Text);
                    SqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        frmAnaEkran anaEkran = new frmAnaEkran();
                        anaEkran.lblKulAdi.Text = txtGiris.Text;
                        anaEkran.lblYetki.Text = lblSecilenGiris.Text;
                        anaEkran.Show();
                        this.Hide();
                    }
                    else
                    {
                        alanları_Temizle();
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.label1.Text = "Böyle Bir Kayıt Yok";
                        frm.Show();
                    }
                    baglanti.Close();
                }
                else
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.label1.Text = "Lütfen Güvenlik Kontrolünü Tamamlayınız";
                }
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "Alanlar Boş Geçilemez";
            }
        }

        private void frmKullaniciGiris_Load(object sender, EventArgs e)
        {
            txtParolaGiris.UseSystemPasswordChar = true;

            // Buton resmi parola gizliyken göster ikonunu gösterir (yani şu anda şifre gizli)
            btngoster.Image = Properties.Resources.show16px;

            // Durum değişkenini ayarla
            parolaGizli = true;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            alanları_Temizle();
        }


        private void bir_Click(object sender, EventArgs e)
        {
            iki.Enabled = true;
        }

        private void iki_Click(object sender, EventArgs e)
        {
            uc.Enabled = true;
        }

        private void uc_Click(object sender, EventArgs e)
        {
            dort.Enabled = true;
        }

        private void dort_Click(object sender, EventArgs e)
        {
            bes.Enabled = true;
        }
        void alanları_Temizle()
        {
            txtGiris.Text = "";
            txtParolaGiris.Text = "";
            lblSecilenGiris.Text = "0";
            rbPersonel.Checked = true;
            rbYetkili.Checked = false;
            bir.BackColor = Color.FromArgb(17, 55, 64);
            iki.BackColor = Color.FromArgb(17, 55, 64);
            uc.BackColor = Color.FromArgb(17, 55, 64);
            dort.BackColor = Color.FromArgb(17, 55, 64);
            bes.BackColor = Color.FromArgb(17, 55, 64);
            iki.Enabled = false;
            uc.Enabled = false;
            dort.Enabled = false;
            bes.Enabled = false;
            txtGiris.Focus();
        }

        private void rbPersonel_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenGiris.Text = "0";
        }

        private void rbYetkili_CheckedChanged(object sender, EventArgs e)
        {
            lblSecilenGiris.Text = "1";
        }

        private void tiklama(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(39, 187, 216);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmYetki yetkiPenceresi = new frmYetki();
            yetkiPenceresi.Show();
            this.Hide();
        }
        bool parolaGizli = true;
        private void btngoster_Click(object sender, EventArgs e)
        {
            // Gizli ise göster, açık ise gizle
            parolaGizli = !parolaGizli;

            txtParolaGiris.UseSystemPasswordChar = parolaGizli;

            // Buton image'ını güncelle
              btngoster.Image = parolaGizli ? Properties.Resources.show16px : Properties.Resources.hide16px;
        }
    }
}
