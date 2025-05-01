namespace TznOtelV1
{
    partial class ortaklarsablon
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
            this.lblKisiTcNo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBizimTcmiz = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Cikart = new System.Windows.Forms.Button();
            this.lblOtelKodu = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_iptalet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKisiTcNo
            // 
            this.lblKisiTcNo.AutoSize = true;
            this.lblKisiTcNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKisiTcNo.Location = new System.Drawing.Point(38, 0);
            this.lblKisiTcNo.Name = "lblKisiTcNo";
            this.lblKisiTcNo.Size = new System.Drawing.Size(51, 21);
            this.lblKisiTcNo.TabIndex = 0;
            this.lblKisiTcNo.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 2);
            this.panel1.TabIndex = 2;
            // 
            // lblBizimTcmiz
            // 
            this.lblBizimTcmiz.AutoSize = true;
            this.lblBizimTcmiz.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBizimTcmiz.Location = new System.Drawing.Point(116, 3);
            this.lblBizimTcmiz.Name = "lblBizimTcmiz";
            this.lblBizimTcmiz.Size = new System.Drawing.Size(51, 21);
            this.lblBizimTcmiz.TabIndex = 3;
            this.lblBizimTcmiz.Text = "label1";
            this.lblBizimTcmiz.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TznOtelV1.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Cikart
            // 
            this.btn_Cikart.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Cikart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cikart.FlatAppearance.BorderSize = 0;
            this.btn_Cikart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cikart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cikart.ForeColor = System.Drawing.Color.White;
            this.btn_Cikart.Location = new System.Drawing.Point(285, 4);
            this.btn_Cikart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Cikart.Name = "btn_Cikart";
            this.btn_Cikart.Size = new System.Drawing.Size(59, 27);
            this.btn_Cikart.TabIndex = 4;
            this.btn_Cikart.Text = "ÇIKAR";
            this.btn_Cikart.UseVisualStyleBackColor = false;
            this.btn_Cikart.Click += new System.EventHandler(this.btn_Cikart_Click);
            // 
            // lblOtelKodu
            // 
            this.lblOtelKodu.AutoSize = true;
            this.lblOtelKodu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOtelKodu.Location = new System.Drawing.Point(95, 21);
            this.lblOtelKodu.Name = "lblOtelKodu";
            this.lblOtelKodu.Size = new System.Drawing.Size(72, 13);
            this.lblOtelKodu.TabIndex = 5;
            this.lblOtelKodu.Text = "lblOtelKODU";
            this.lblOtelKodu.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(32, 101);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 6;
            this.listBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // btn_iptalet
            // 
            this.btn_iptalet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_iptalet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_iptalet.FlatAppearance.BorderSize = 0;
            this.btn_iptalet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iptalet.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_iptalet.ForeColor = System.Drawing.Color.White;
            this.btn_iptalet.Location = new System.Drawing.Point(285, 4);
            this.btn_iptalet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_iptalet.Name = "btn_iptalet";
            this.btn_iptalet.Size = new System.Drawing.Size(59, 27);
            this.btn_iptalet.TabIndex = 8;
            this.btn_iptalet.Text = "İPTAL ET";
            this.btn_iptalet.UseVisualStyleBackColor = false;
            this.btn_iptalet.Click += new System.EventHandler(this.btn_iptalet_Click);
            // 
            // ortaklarsablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_iptalet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblOtelKodu);
            this.Controls.Add(this.btn_Cikart);
            this.Controls.Add(this.lblBizimTcmiz);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblKisiTcNo);
            this.Name = "ortaklarsablon";
            this.Size = new System.Drawing.Size(348, 35);
            this.Load += new System.EventHandler(this.ortaklarsablon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblKisiTcNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblBizimTcmiz;
        private System.Windows.Forms.Button btn_Cikart;
        public System.Windows.Forms.Label lblOtelKodu;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_iptalet;
    }
}
