using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TznOtelV1
{
    public partial class frmKisiKayit: Form
    {
        public frmKisiKayit()
        {
            InitializeComponent();
        }
        string tc, ad, soyad, dogumt, mail, tel, aciklama, cinsiyet;

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void txtTcKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }


        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void rbKadin_CheckedChanged(object sender, EventArgs e)
        {
            lblCinsiyetKontrol.Text = "1";
        }

        string mailDeseni = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        private void rbErkek_CheckedChanged(object sender, EventArgs e)
        {
            lblCinsiyetKontrol.Text = "0";
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            

                if (txtTcKimlik.Text != "" && txtAd.Text != "" && txtSoyad.Text != "" && txtDogumTarihi.Text != "" && txtMail.Text != "" && txtTelNo.Text != "")
                {
                    //Değişkenlere değer atama işlemleri 
                    tc = txtTcKimlik.Text;
                    ad = txtAd.Text.ToUpper();
                    soyad = txtSoyad.Text.ToUpper() ;
                    dogumt = txtDogumTarihi.Text;
                    mail = txtMail.Text;
                    aciklama = txtAciklama.Text;
                    tel = txtTelNo.Text;
                    cinsiyet = lblCinsiyetKontrol.Text;

                    if (!Regex.IsMatch(mail, mailDeseni))
                    {
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.label1.Text = "LÜTFEN DOĞRU BİR MAİL ADRESİ GİRİNİZ";
                    }
                    else
                    {
                        frmKisiKayit2 frm = new frmKisiKayit2();
                        frm.ad = ad;
                        frm.soyad = soyad;
                        frm.dogumt = dogumt;
                        frm.mail = mail;
                        frm.tel = tel;
                        frm.aciklama = aciklama;
                        frm.cinsiyet = cinsiyet;
                        frm.tc = tc;
                        this.Hide();
                        frm.Show();
                       
                    }
                }
                else
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.label1.Text = "LÜTFEN TÜM ZORUNLU ALANLARI DOLDURUN";
                }

            
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Temizle()
        {
            txtAciklama.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtDogumTarihi.Text = "";
            txtMail.Text = "";
            txtTcKimlik.Text = "";
            lblCinsiyetKontrol.Text = "0";
            txtTelNo.Text = "";
            rbErkek.Checked = true;
            rbKadin.Checked = false;
            txtTcKimlik.Focus();
        }
    }
}
