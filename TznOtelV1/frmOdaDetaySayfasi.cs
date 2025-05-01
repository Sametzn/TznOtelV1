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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TznOtelV1
{
    public partial class frmOdaDetaySayfasi: Form
    {

        public  frmOdaDetaySayfasi()
        {
            InitializeComponent();
        }
        public string gelenOdaKodu = "";
        string yatakSayisiString = "";

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");

        private void frmOdaDetaySayfasi_Load(object sender, EventArgs e)
        {
            odaBilgiGetir();
            int yatakSayisi = int.Parse(yatakSayisiString);
            yatakOlustur();
            YataklariGetir(gelenOdaKodu);


        }
        private void YataklariGetir(string odaKodu)
        {
            flpharita.Controls.Clear();

            int toplamYatak = 0;
            Dictionary<int, Tuple<string, string, string>> doluYataklar = new Dictionary<int, Tuple<string, string, string>>();

            using (SqlCommand komut1 = new SqlCommand("SELECT toplamYatak FROM Tbl_Yataksayisi WHERE odaKodu = @p1", baglanti))
            {
                komut1.Parameters.AddWithValue("@p1", odaKodu);
                baglanti.Open();
                SqlDataReader dr1 = komut1.ExecuteReader();
                if (dr1.Read())
                {
                    toplamYatak = Convert.ToInt32(dr1["toplamYatak"]);
                }
                baglanti.Close();
            }

            using (SqlCommand komut2 = new SqlCommand("SELECT seciliYatakNo, kisiAd, kisiSoyad, kisiCinsiyet FROM Tbl_Musteriler WHERE odaKodu = @p1", baglanti))
            {
                komut2.Parameters.AddWithValue("@p1", odaKodu);
                baglanti.Open();
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    int yatakNo = Convert.ToInt32(dr2["seciliYatakNo"]);
                    string ad = dr2["kisiAd"].ToString();
                    string soyad = dr2["kisiSoyad"].ToString();
                    string cinsiyet = dr2["kisiCinsiyet"].ToString();
                    doluYataklar[yatakNo] = Tuple.Create(ad, soyad, cinsiyet);
                }
                baglanti.Close();
            }

            for (int i = 1; i <= toplamYatak; i++)
            {
                Panel panel = new Panel();
                panel.Width = 260;
                panel.Height = 80;
                panel.Margin = new Padding(5);

                Label lblYatakNo = new Label();
                lblYatakNo.Text = i.ToString();
                lblYatakNo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblYatakNo.ForeColor = Color.Orange;
                lblYatakNo.Width = 40;
                lblYatakNo.TextAlign = ContentAlignment.MiddleLeft;
                lblYatakNo.Location = new Point(5, 25);

                RadioButton rdb = new RadioButton();
                rdb.Appearance = Appearance.Button;
                rdb.Width = 200;
                rdb.Height = 60;
                rdb.TextAlign = ContentAlignment.MiddleCenter;
                rdb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                rdb.Location = new Point(50, 10);

                if (doluYataklar.ContainsKey(i))
                {
                    var musteri = doluYataklar[i];
                    string ad = musteri.Item1;
                    string soyad = musteri.Item2;
                    string cinsiyet = musteri.Item3 == "0" ? "Erkek" : "Kadın";
                    rdb.Text = $"Dolu\n{ad} {soyad}\n{cinsiyet}";
                    rdb.BackColor = Color.LightCoral;
                }
                else
                {
                    rdb.Text = "Boş";
                    rdb.BackColor = Color.LightGreen;
                }

                panel.Controls.Add(lblYatakNo);
                panel.Controls.Add(rdb);
                flpharita.Controls.Add(panel);
            }

        }



        void odaBilgiGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Odalar WHERE odaKodu=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", gelenOdaKodu);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                txtOdaKodu.Text = oku["odaKodu"].ToString();
                txtOdaNumara.Text  = oku["odaAdi"].ToString();
                lblOdaYatakSayisi.Text = oku["odaYataksayisi"].ToString();
                lblOdaDurumu.Text = oku["odaDurumu"].ToString();
                lblOdaTuru.Text = oku["odaTuru"].ToString();
                lblOdaOzellik.Text = oku["odaOzellik"].ToString();
                txtOdaAciklama.Text = oku["odaBilgi"].ToString();
                lblOdaFiyat.Text = oku["odaFiyati"].ToString() +" "+"₺";
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Yataksayisi WHERE odaKodu=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", gelenOdaKodu);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                lblbosyatak.Text = read["bosYatak"].ToString();
                yatakSayisiString = read["toplamYatak"].ToString();
            }

            baglanti.Close();
            //yatak sayısı belirleme
            foreach (RadioButton item in groupBox4.Controls)
            {
                if (lblOdaYatakSayisi.Text.Trim() == item.Text)
                {
                    item.Checked = true;
                    item.ForeColor = Color.Black;
                }
                else
                {
                    item.Checked = false;
                    item.ForeColor = Color.FromArgb(26, 111, 166);

                }

            }
            if (lblOdaTuru.Text == "0")
            {
                odaTuru.Text = "KAPALI";
            }
            else if (lblOdaTuru.Text == "1") 
            {
                odaTuru.Text = "AÇIK";
            }
            else
            {
                odaTuru.Text = "BAKIMDA";
            }

            if (lblOdaDurumu.Text == "0")
            {
                rbKirli.Checked = true;
                rbTemiz.Checked = false;
            }
            else
            {
                rbKirli.Checked = false;
                rbTemiz.Checked = true;
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
                }
                else
                {
                    if (item.Text == "HEPSİ")
                    {
                        item.Checked = false;
                    }
                    else
                    {
                        item.Checked = false;
                    }

                }
            }

            if (listegelen.Items.Count == 7)
            {
                cbHepsiSec.Checked = true;
            }

            if (lblOdaTuru.Text=="0")
            {
                //İŞLEM YOK KAPALI
                panel1.BackColor=Color.FromArgb(26, 111, 166);
                panel2.BackColor = Color.FromArgb(26, 111, 166);
                groupBox1.ForeColor = Color.FromArgb(26, 111, 166);
                groupBox2.ForeColor = Color.FromArgb(26, 111, 166);
                groupBox3.ForeColor = Color.FromArgb(26, 111, 166);
                groupBox4.ForeColor = Color.FromArgb(26, 111, 166);
                groupBox5.ForeColor = Color.FromArgb(26, 111, 166);
                groupBox6.ForeColor = Color.FromArgb(26, 111, 166);
                lblMesaj.Text = "BU ODA KAPALI OLDUĞUNDAN İŞLEM YAPILAMAMAKTADIR";
                lblMesaj.ForeColor=Color.FromArgb(26, 111, 166);
                label1.ForeColor=Color.FromArgb(26, 111, 166);
                panel4.BackColor= Color.FromArgb(26, 111, 166);
                lblMesaj.Visible = true;
                lblMesaj.Dock = DockStyle.Fill;
            }
            else if (lblOdaTuru.Text=="2")
            {
                panel1.BackColor = Color.FromArgb(242, 167, 75);
                panel2.BackColor = Color.FromArgb(242, 167, 75);
                groupBox1.ForeColor = Color.FromArgb(242, 167, 75);
                groupBox2.ForeColor = Color.FromArgb(242, 167, 75);
                groupBox3.ForeColor = Color.FromArgb(242, 167, 75);
                groupBox4.ForeColor = Color.FromArgb(242, 167, 75);
                groupBox5.ForeColor = Color.FromArgb(242, 167, 75);
                groupBox6.ForeColor = Color.FromArgb(242, 167, 75);
                lblMesaj.Text = "BU ODA BAKIMDA OLDUĞUNDAN İŞLEM YAPILAMAMAKTADIR";
                lblMesaj.ForeColor = Color.FromArgb(242, 167, 75);
                label1.ForeColor = Color.FromArgb(242, 167, 75);
                panel4.BackColor = Color.FromArgb(242, 167, 75);
                lblMesaj.Visible = true;
                lblMesaj.Dock = DockStyle.Fill;
            }
            else
            {
                if (lblOdaDurumu.Text=="1")
                {
                    if (lblbosyatak.Text.Trim()!="0")
                    {

                        lblMesaj.Visible = false;
                        panel3.Visible = true;
                        panel1.BackColor = Color.FromArgb(43, 178, 123);
                        panel2.BackColor = Color.FromArgb(43, 178, 123);
                        groupBox1.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox2.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox3.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox4.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox5.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox6.ForeColor = Color.FromArgb(43, 178, 123);
                        label1.ForeColor = Color.FromArgb(43, 178, 123);
                        panel3.ForeColor= Color.FromArgb(43, 178, 123);
                        groupBox7.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox8.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox9.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox10.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox11.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox12.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox13.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox14.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox15.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox16.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox17.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox18.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox19.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox20.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox21.ForeColor = Color.FromArgb(43, 178, 123);
                        groupBox22.ForeColor = Color.FromArgb(43, 178, 123);
                        panel4.BackColor = Color.FromArgb(43, 178, 123);

                    }
                    else
                    {
                        //dolu olduğu için  işlemler gelecek
                        panel1.BackColor = Color.FromArgb(237, 85, 109);
                        panel2.BackColor = Color.FromArgb(237, 85, 109);
                        groupBox1.ForeColor = Color.FromArgb(237, 85, 109);
                        groupBox2.ForeColor = Color.FromArgb(237, 85, 109);
                        groupBox3.ForeColor = Color.FromArgb(237, 85, 109);
                        groupBox4.ForeColor = Color.FromArgb(237, 85, 109);
                        groupBox5.ForeColor = Color.FromArgb(237, 85, 109);
                        groupBox6.ForeColor = Color.FromArgb(237, 85, 109);
                        lblMesaj.Text = "BU ODANIN TÜM YATAKLARI DOLU OLDUĞU İÇİN İŞLEM YAPILAMAMAKTADIR";
                        lblMesaj.ForeColor = Color.FromArgb(237, 85, 109);
                        label1.ForeColor = Color.FromArgb(237, 85, 109);
                        panel4.BackColor = Color.FromArgb(237, 85, 109);
                        lblMesaj.Visible = true;
                        lblMesaj.Dock = DockStyle.Fill;
                        
                    }
                }
                else
                {
                    panel1.BackColor = Color.FromArgb(43, 178, 123);
                    panel2.BackColor = Color.FromArgb(43, 178, 123);
                    groupBox1.ForeColor = Color.FromArgb(43, 178, 123);
                    groupBox2.ForeColor = Color.FromArgb(43, 178, 123);
                    groupBox3.ForeColor = Color.FromArgb(43, 178, 123);
                    groupBox4.ForeColor = Color.FromArgb(43, 178, 123);
                    groupBox5.ForeColor = Color.FromArgb(43, 178, 123);
                    groupBox6.ForeColor = Color.FromArgb(43, 178, 123);
                    lblMesaj.Text = "LÜTFEN ODANIN TEMİZLENMESİNİ BEKLEYİNİZ VE İŞLEMLERİ DAHA SONRA GERÇEKLEŞTİRİNİZ";
                    panel4.BackColor = Color.FromArgb(43, 178, 123);
                    lblMesaj.ForeColor = Color.FromArgb(43, 178, 123);
                    label1.ForeColor = Color.FromArgb(43, 178, 123);
                    lblMesaj.Visible = true;
                    lblMesaj.Dock = DockStyle.Fill;
                }
            }
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnKaydiTamamla_Click(object sender, EventArgs e)
        {
            DateTime girisTarihi = girisT.Value.Date;
            DateTime cikisTarihi = cikisT.Value.Date;
            DateTime bugun = DateTime.Today;
            DateTime dogumTarihi = dtpDogumT.Value;
            int yas = bugun.Year - dogumTarihi.Year;
            if (dogumTarihi.Date > bugun.AddYears(-yas))
            {
                yas--;
            }
            if (txtTcNo.Text!="" && txtUyruk.Text!="" && txtAd.Text!="" && txtSoyad.Text!="" && txtTelNo.Text!="" && txtMail.Text!="")
            {
                if (lblCinsiyet.Text != "lblCinsiyet")
                {
                    if (lblucret.Text!="lblucret")
                    {
                        if (lblodemetipi.Text!="lblodemetipi")
                        {
                            if (lblKayitTuru.Text!="lblKayitTuru")
                            {
                                if (lblCocuk.Text!="lblCocuk")
                                {
                                    if (girisTarihi < bugun)
                                    {
                                        frmPopupmenu frm = new frmPopupmenu();
                                        frm.Show();
                                        frm.label1.Text = "GİRİŞ TARİHİ BUGÜNDEN ÖNCE OLAMAZ";
                                    }
                                    else
                                    {
                                        if (girisTarihi>cikisTarihi)
                                        {
                                            frmPopupmenu frm = new frmPopupmenu();
                                            frm.Show();
                                            frm.label1.Text = "GİRİŞ TARİHİ ÇIKIŞ TARİHİNDEN SONRA OLAMAZ";
                                        }
                                        else
                                        {
                                            if (yas>=18)
                                            {
                                                bosmudolumukontrol();
                                                odaBilgiGetir();
                                                int yatakSayisi = int.Parse(yatakSayisiString);
                                                yatakOlustur();
                                                YataklariGetir(gelenOdaKodu);
                                            }
                                            else
                                            {
                                                frmPopupmenu frm = new frmPopupmenu();
                                                frm.Show();
                                                frm.label1.Text = "KAYIT İÇİN KİŞİNİN 18 YAŞINDAN BÜYÜK OLMASI GEREKİR";
                                            }
                                                
                                        }
                                    }
                                }
                                else
                                {
                                    frmPopupmenu frm = new frmPopupmenu();
                                    frm.Show();
                                    frm.label1.Text = "COCUK ALANINI DOLDURUNUZ";
                                }
                            }
                            else
                            {
                                frmPopupmenu frm = new frmPopupmenu();
                                frm.Show();
                                frm.label1.Text = "LÜTFEN KAYIT TÜRÜNÜ DOLDURUNUZ";
                            }
                        }
                        else
                        {
                            frmPopupmenu frm = new frmPopupmenu();
                            frm.Show();
                            frm.label1.Text = "LÜTFEN ÖDEME TİPİNİ SEÇİNİZ";
                        }
                    }
                    else
                    {
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.Show();
                        frm.label1.Text = "LÜTFEN ÜCRET TİPİNİ SEÇİNİZ";
                    }
                }
                else
                {
                    frmPopupmenu frm = new frmPopupmenu();
                    frm.Show();
                    frm.label1.Text = "LÜTFEN CİNSİYETİ SEÇİNİZ";
                }
            }
            else
            {
                frmPopupmenu frm = new frmPopupmenu();
                frm.Show();
                frm.label1.Text = "LÜTFEN TÜM ALANLARI DOLDURUN";
            }
           

        }
        void bosmudolumukontrol()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Yataksayisi SET bosYatak=@bosYatak WHERE odaKodu=@odaKodu", baglanti);
            komut.Parameters.AddWithValue("@odaKodu", txtOdaKodu.Text);
            if (lblbosyatak.Text!="0")
            {
                kisiKayitMetodu();
                int sayi = int.Parse(lblbosyatak.Text);
                sayi = sayi - 1;
                komut.Parameters.AddWithValue("@bosYatak", sayi);
         
            }
            else
            {
                panel1.BackColor = Color.FromArgb(43, 178, 123);
                panel2.BackColor = Color.FromArgb(43, 178, 123);
                groupBox1.ForeColor = Color.FromArgb(43, 178, 123);
                groupBox2.ForeColor = Color.FromArgb(43, 178, 123);
                groupBox3.ForeColor = Color.FromArgb(43, 178, 123);
                groupBox4.ForeColor = Color.FromArgb(43, 178, 123);
                groupBox5.ForeColor = Color.FromArgb(43, 178, 123);
                groupBox6.ForeColor = Color.FromArgb(43, 178, 123);
                lblMesaj.Text = "BU ODANIN TÜM YATAKLARI DOLU OLDUĞU İÇİN İŞLEM YAPILAMAMAKTADIR";
                lblMesaj.ForeColor = Color.FromArgb(43, 178, 123);
                label1.ForeColor = Color.FromArgb(43, 178, 123);
                lblMesaj.Visible = true;
                lblMesaj.Dock = DockStyle.Fill;
            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        void kisiKayitMetodu()
        {

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Musteriler (odaKodu,odaNo,kisiTc,kisiUyruk,kisiAd,kisiSoyad,kisiDogumT,kisiTel,kisiMail,kisiCinsiyet,kisiUcret,kisiOdeme,kisiKayit,kisiCocuk,girisT,cikisT,aciklama,seciliYatakNo) VALUES (@odaKodu,@odaNo,@kisiTc,@kisiUyruk,@kisiAd,@kisiSoyad,@kisiDogumT,@kisiTel,@kisiMail,@kisiCinsiyet,@kisiUcret,@kisiOdeme,@kisiKayit,@kisiCocuk,@girisT,@cikisT,@aciklama,@seciliYatakNo)", baglanti);
            komut.Parameters.AddWithValue("@odaKodu", txtOdaKodu.Text);
            komut.Parameters.AddWithValue("@odaNo", txtOdaNumara.Text);
            komut.Parameters.AddWithValue("@kisiTc", txtTcNo.Text);
            komut.Parameters.AddWithValue("@kisiUyruk", txtUyruk.Text);
            komut.Parameters.AddWithValue("@kisiAd", txtAd.Text);
            komut.Parameters.AddWithValue("@kisiSoyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@kisiDogumT", dtpDogumT.Text);
            komut.Parameters.AddWithValue("@kisiTel", txtTelNo.Text);
            komut.Parameters.AddWithValue("@kisiMail", txtMail.Text);
            if (lblCinsiyet.Text == "ERKEK")
            {
                komut.Parameters.AddWithValue("@kisiCinsiyet", "0");
            }
            else
            {
                komut.Parameters.AddWithValue("@kisiCinsiyet", "1");
            }

            if (lblodemetipi.Text == "ÖDENDİ")
            {
                komut.Parameters.AddWithValue("@kisiUcret", "1");
            }
            else
            {
                komut.Parameters.AddWithValue("@kisiUcret", "0");
            }

            if (lblodemetipi.Text == "NAKİT")
            {
                komut.Parameters.AddWithValue("@kisiOdeme", "0");
            }
            else
            {
                komut.Parameters.AddWithValue("@kisiOdeme", "1");
            }

            if (lblKayitTuru.Text == "BİREYSEL")
            {
                komut.Parameters.AddWithValue("@kisiKayit", "0");
            }
            else if (lblKayitTuru.Text == "KARMA")
            {
                komut.Parameters.AddWithValue("@kisiKayit", "1");
            }
            else
            {
                komut.Parameters.AddWithValue("@kisiKayit", "2");
            }

            if (lblCocuk.Text == "YOK")
            {
                komut.Parameters.AddWithValue("@kisiCocuk", "0");
            }
            else
            {
                komut.Parameters.AddWithValue("@kisiCocuk", "1");
            }
            komut.Parameters.AddWithValue("@girisT", girisT.Text);
            komut.Parameters.AddWithValue("@cikisT", cikisT.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@seciliYatakNo", lblSeciliYatakNo.Text);
            komut.ExecuteNonQuery();
            frmPopupmenu frm = new frmPopupmenu();
            frm.Show();
            frm.label1.Text = "KAYIT BAŞARILI";
        }
        void yatakOlustur()
        {
            int yatakSayisi = int.Parse(yatakSayisiString);
            flpYataklar.Controls.Clear();

            // Dolu yatakları tutacak bir Dictionary (veya List)
            Dictionary<int, bool> doluYataklar = new Dictionary<int, bool>();

            // Veritabanından dolu yatakları alalım
            using (SqlCommand komut = new SqlCommand("SELECT seciliYatakNo FROM Tbl_Musteriler WHERE odaKodu = @odaKodu", baglanti))
            {
                komut.Parameters.AddWithValue("@odaKodu", gelenOdaKodu); // odaKodu'nu parametre olarak alıyoruz
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    int yatakNo = Convert.ToInt32(dr["seciliYatakNo"]);
                    doluYataklar[yatakNo] = true;  // Bu yatak doludur
                }
                baglanti.Close();
            }

            for (int i = 1; i <= yatakSayisi; i++)
            {
                System.Windows.Forms.Button btnYatak = new System.Windows.Forms.Button();
                btnYatak.Text = i.ToString();
                btnYatak.Size = new Size(30, 30);

                // Eğer yatak doluysa, buton tıklanamaz yapalım
                if (doluYataklar.ContainsKey(i) && doluYataklar[i])
                {
                    btnYatak.Enabled = false;  // Bu buton tıklanamaz
                    btnYatak.BackColor = Color.Gray;  // Dolu yatakları gri yapabiliriz
                }
                else
                {
                    btnYatak.Enabled = true;  // Bu buton tıklanabilir
                    btnYatak.BackColor = Color.LightGreen;  // Boş yatakları yeşil yapabiliriz
                }

                btnYatak.Click += new EventHandler(btnYatak_Click);
                flpYataklar.Controls.Add(btnYatak);
            }
        }
        private void btnYatak_Click(object sender, EventArgs e)
        {
            // Seçilen yatağın butonunu alıyoruz
            System.Windows.Forms.Button selectedButton = sender as System.Windows.Forms.Button;

            if (selectedButton != null)
            {
                // Yatak numarasını lblSeciliYatakNo'ya yazdırıyoruz
                lblSeciliYatakNo.Text = selectedButton.Text;
            }
        }
        private void btnErkek_Click(object sender, EventArgs e)
        {
            if (btnErkek.Text == "ERKEK")
            {
                pb1.Visible = true;
                pb2.Visible = false;
                lblCinsiyet.Text = "ERKEK";
            }
        }

        private void btnKadın_Click(object sender, EventArgs e)
        {
            if (btnKadın.Text == "KADIN")
            {
                pb1.Visible = false;
                pb2.Visible = true;
                lblCinsiyet.Text = "KADIN";
            }
        }

        private void btnOdendi_Click(object sender, EventArgs e)
        {
            if (btnOdendi.Text=="ÖDENDİ")
            {
                pb6.Visible = true;
                pb7.Visible = false;
                lblodemetipi.Text = "ÖDENDİ";
            }
        }

        private void btnOdenmedi_Click(object sender, EventArgs e)
        {
            if (btnOdenmedi.Text == "ÖDENMEDİ")
            {
                pb6.Visible = false;
                pb7.Visible = true;
                lblodemetipi.Text = "ÖDENMEDİ";
            }
        }

        private void btnNakit_Click(object sender, EventArgs e)
        {
            if (btnNakit.Text == "NAKİT")
            {
                pb10.Visible = true;
                pb11.Visible = false;
                lblucret.Text = "NAKİT";
            }
        }

        private void btnKart_Click(object sender, EventArgs e)
        {
            if (btnKart.Text == "KART")
            {
                pb10.Visible = false;
                pb11.Visible = true;
                lblucret.Text = "KART";
            }
        }

        private void btnBireysel_Click(object sender, EventArgs e)
        {
            if (btnBireysel.Text=="BİREYSEL")
            {
                pb3.Visible = true;
                pb4.Visible = false;
                pb5.Visible = false;
                lblKayitTuru.Text = "BİREYSEL";
            }
        }

        private void btnKarma_Click(object sender, EventArgs e)
        {
            if (btnKarma.Text == "KARMA")
            {
                pb3.Visible = false;
                pb4.Visible = true;
                pb5.Visible = false;
                lblKayitTuru.Text = "KARMA";
            }
        }
        private void btnAile_Click(object sender, EventArgs e)
        {
            if (btnAile.Text == "AİLE")
            {
                pb3.Visible = false;
                pb4.Visible = false;
                pb5.Visible = true;
                lblKayitTuru.Text = "AİLE";
            }
        }
        private void btnCvar_Click(object sender, EventArgs e)
        {
            if (btnCvar.Text=="VAR")
            {
                pb12.Visible = true;
                pb13.Visible = false;
                lblCocuk.Text = "VAR";
            }
        }

        private void btnCyok_Click(object sender, EventArgs e)
        {
            if (btnCyok.Text == "YOK")
            {
                pb12.Visible = false;
                pb13.Visible = true;
                lblCocuk.Text = "YOK";
            }
        }


    }
}