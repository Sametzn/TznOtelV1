using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TznOtelV1
{
    public partial class frmYetki: Form
    {
        public frmYetki()
        {
            InitializeComponent();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            frmKullaniciGiris giris = new frmKullaniciGiris();
            giris.Show();
            this.Close();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text=="admin" && txtParola.Text=="123")
            {
                frmKisiKayit giris = new frmKisiKayit();
                giris.Show();
                this.Close();
            }
            else
            {
                txtKullaniciAdi.Text = "";
                txtParola.Text = "";
                txtKullaniciAdi.Focus();

                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "KULLANICI ADI VEYA PAROLA DOĞRU DEĞİL";
            }
        }

        private void frmYetki_Load(object sender, EventArgs e)
        {
            txtParola.PasswordChar = '*';
        }
    }
}
