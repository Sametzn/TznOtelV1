namespace TznOtelV1
{
    partial class calisanSablon
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Detay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblOtelKodu = new System.Windows.Forms.Label();
            this.btn_Cikart = new System.Windows.Forms.Button();
            this.lblBizimTcmiz = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKisiTcNo = new System.Windows.Forms.Label();
            this.lblUyariMesaji = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Detay
            // 
            this.btn_Detay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_Detay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Detay.FlatAppearance.BorderSize = 0;
            this.btn_Detay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Detay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Detay.ForeColor = System.Drawing.Color.White;
            this.btn_Detay.Location = new System.Drawing.Point(428, 5);
            this.btn_Detay.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_Detay.Name = "btn_Detay";
            this.btn_Detay.Size = new System.Drawing.Size(88, 44);
            this.btn_Detay.TabIndex = 17;
            this.btn_Detay.Text = "DETAY";
            this.btn_Detay.UseVisualStyleBackColor = false;
            this.btn_Detay.Click += new System.EventHandler(this.btn_Detay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 470);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(63, 423);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 151);
            this.listBox1.TabIndex = 15;
            // 
            // lblOtelKodu
            // 
            this.lblOtelKodu.AutoSize = true;
            this.lblOtelKodu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOtelKodu.Location = new System.Drawing.Point(142, 34);
            this.lblOtelKodu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOtelKodu.Name = "lblOtelKodu";
            this.lblOtelKodu.Size = new System.Drawing.Size(72, 13);
            this.lblOtelKodu.TabIndex = 14;
            this.lblOtelKodu.Text = "lblOtelKODU";
            this.lblOtelKodu.Visible = false;
            // 
            // btn_Cikart
            // 
            this.btn_Cikart.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Cikart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cikart.FlatAppearance.BorderSize = 0;
            this.btn_Cikart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cikart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cikart.ForeColor = System.Drawing.Color.White;
            this.btn_Cikart.Location = new System.Drawing.Point(327, 5);
            this.btn_Cikart.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_Cikart.Name = "btn_Cikart";
            this.btn_Cikart.Size = new System.Drawing.Size(88, 44);
            this.btn_Cikart.TabIndex = 13;
            this.btn_Cikart.Text = "ÇIKAR";
            this.btn_Cikart.UseVisualStyleBackColor = false;
            this.btn_Cikart.Click += new System.EventHandler(this.btn_Cikart_Click);
            // 
            // lblBizimTcmiz
            // 
            this.lblBizimTcmiz.AutoSize = true;
            this.lblBizimTcmiz.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBizimTcmiz.Location = new System.Drawing.Point(174, 5);
            this.lblBizimTcmiz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBizimTcmiz.Name = "lblBizimTcmiz";
            this.lblBizimTcmiz.Size = new System.Drawing.Size(51, 21);
            this.lblBizimTcmiz.TabIndex = 12;
            this.lblBizimTcmiz.Text = "label1";
            this.lblBizimTcmiz.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 3);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TznOtelV1.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblKisiTcNo
            // 
            this.lblKisiTcNo.AutoSize = true;
            this.lblKisiTcNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKisiTcNo.Location = new System.Drawing.Point(47, 5);
            this.lblKisiTcNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKisiTcNo.Name = "lblKisiTcNo";
            this.lblKisiTcNo.Size = new System.Drawing.Size(51, 21);
            this.lblKisiTcNo.TabIndex = 9;
            this.lblKisiTcNo.Text = "label1";
            // 
            // lblUyariMesaji
            // 
            this.lblUyariMesaji.BackColor = System.Drawing.Color.DarkRed;
            this.lblUyariMesaji.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUyariMesaji.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyariMesaji.ForeColor = System.Drawing.Color.Black;
            this.lblUyariMesaji.Location = new System.Drawing.Point(0, 0);
            this.lblUyariMesaji.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUyariMesaji.Name = "lblUyariMesaji";
            this.lblUyariMesaji.Size = new System.Drawing.Size(517, 82);
            this.lblUyariMesaji.TabIndex = 18;
            this.lblUyariMesaji.Text = "PERSONEL KAYDINI KALICI OLARAK SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?";
            this.lblUyariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUyariMesaji.Visible = false;
            // 
            // calisanSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblUyariMesaji);
            this.Controls.Add(this.btn_Detay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblOtelKodu);
            this.Controls.Add(this.btn_Cikart);
            this.Controls.Add(this.lblBizimTcmiz);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblKisiTcNo);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "calisanSablon";
            this.Size = new System.Drawing.Size(517, 85);
            this.Load += new System.EventHandler(this.calisanSablon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Detay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Label lblOtelKodu;
        private System.Windows.Forms.Button btn_Cikart;
        public System.Windows.Forms.Label lblBizimTcmiz;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblKisiTcNo;
        public System.Windows.Forms.Label lblUyariMesaji;
    }
}
