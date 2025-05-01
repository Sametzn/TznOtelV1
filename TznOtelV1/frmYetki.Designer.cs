namespace TznOtelV1
{
    partial class frmYetki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(167)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.btn_cıkıs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 40);
            this.panel1.TabIndex = 2;
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.ForeColor = System.Drawing.Color.White;
            this.btn_cıkıs.Location = new System.Drawing.Point(330, 0);
            this.btn_cıkıs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_cıkıs.Name = "btn_cıkıs";
            this.btn_cıkıs.Size = new System.Drawing.Size(40, 40);
            this.btn_cıkıs.TabIndex = 1;
            this.btn_cıkıs.Text = "X";
            this.btn_cıkıs.UseVisualStyleBackColor = false;
            this.btn_cıkıs.Click += new System.EventHandler(this.btn_cıkıs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "YETKİ YÖNLENDİRME EKRANI";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 116);
            this.label2.TabIndex = 3;
            this.label2.Text = "LÜTFEN SAHİP OLDUĞUNUZ ŞİFREYİ PERSONELLERLE PAYLAŞMAYINIZ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtParola);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(194, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.groupBox2.Size = new System.Drawing.Size(155, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PAROLA";
            // 
            // txtParola
            // 
            this.txtParola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParola.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtParola.Location = new System.Drawing.Point(15, 25);
            this.txtParola.MaxLength = 30;
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(125, 22);
            this.txtParola.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKullaniciAdi);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(21, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.groupBox1.Size = new System.Drawing.Size(144, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KULLANICI ADI";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciAdi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(15, 28);
            this.txtKullaniciAdi.MaxLength = 30;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(114, 22);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btnGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGirisYap.FlatAppearance.BorderSize = 0;
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.ForeColor = System.Drawing.Color.White;
            this.btnGirisYap.Location = new System.Drawing.Point(21, 236);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(328, 30);
            this.btnGirisYap.TabIndex = 10;
            this.btnGirisYap.Text = "İŞLEME DEVAM ET ";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // frmYetki
            // 
            this.AcceptButton = this.btnGirisYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 280);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmYetki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmYetki";
            this.Load += new System.EventHandler(this.frmYetki_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnGirisYap;
    }
}