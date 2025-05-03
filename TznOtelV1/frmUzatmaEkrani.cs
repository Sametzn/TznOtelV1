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
    public partial class frmUzatmaEkrani : Form
    {
        public frmUzatmaEkrani()
        {
            InitializeComponent();
        }
        public string cikistarihi = "";
        public string giristarihi = "";
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TznOtelVT;Integrated Security=True");
        private void frmUzatmaEkrani_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // Geçerli ayın gün sayısı
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);

            // Önce paneli temizle (yeniden yüklendiğinde tekrarlamasın)
            flpgunler.Controls.Clear();

            for (int day = 1; day <= daysInMonth; day++)
            {
                Button btn = new Button();
                btn.Text = day.ToString();
                btn.Width = 45;
                btn.Height = 45;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(19, 187, 216);
                btn.Tag = day; // Günü tutmak için

                btn.Click += (s, ev) =>
                {
                    Button clickedBtn = s as Button;
                    int selectedDay = (int)clickedBtn.Tag;
                    lbluzatılacakgun.Text = $"{selectedDay}";
                };

                flpgunler.Controls.Add(btn);
            }

        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. lbluzatılacakgun'dan yeni günü al
            int yeniGun = int.Parse(lbluzatılacakgun.Text);

            // 2. cikistarihi değişkeninden eski tarihi al
            string eskiTarih = cikistarihi;
            string giristarih = giristarihi;

            string[] parcalar1 = giristarih.Split('.');
            if (parcalar1.Length == 3)
            {
                int gun = int.Parse(parcalar1[0]);
                // 3. Tarihi parçala
                string[] parcalar2 = eskiTarih.Split('.');
                if (parcalar2.Length == 3)
                {
                    int ay = int.Parse(parcalar2[1]);
                    int yil = int.Parse(parcalar2[2]);

                    // 4. Yeni tarihi oluştur
                    string yeniTarih = $"{yeniGun}.{ay}.{yil}";

                    if (gun>yeniGun)
                    {
                        frmPopupmenu frm = new frmPopupmenu();
                        frm.label1.Text = "YENİ TARİH GİRİŞ ZAMANINDAN ÖNCE OLAMAZ";
                        frm.Show();
                    }
                    else
                    {
                        // 5. Güncelleme sorgusu
                        string guncelleSorgu = "UPDATE Tbl_Musteriler SET cikisT = @YeniTarih WHERE cikisT = @EskiTarih";

                        SqlCommand komut = new SqlCommand(guncelleSorgu, baglanti);
                        komut.Parameters.AddWithValue("@YeniTarih", yeniTarih);
                        komut.Parameters.AddWithValue("@EskiTarih", eskiTarih);

                        // 6. Veritabanı işlemi
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        this.Close();
                    }
                }
            }
            
        }
    }
}

