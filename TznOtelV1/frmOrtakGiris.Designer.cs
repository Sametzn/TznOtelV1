namespace TznOtelV1
{
    partial class frmOrtakGiris
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbKontrol = new System.Windows.Forms.PictureBox();
            this.txtOtelKodu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOtelAdi = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOnayKodu = new System.Windows.Forms.TextBox();
            this.btnOnay = new System.Windows.Forms.Button();
            this.lblKayitliKod = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKontrol)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Controls.Add(this.btn_cıkıs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 40);
            this.panel1.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogo.Image = global::TznOtelV1.Properties.Resources.Custom_Icon_Design_Pretty_Office_4_Couple_48;
            this.pbLogo.Location = new System.Drawing.Point(12, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(36, 36);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.ForeColor = System.Drawing.Color.White;
            this.btn_cıkıs.Location = new System.Drawing.Point(307, 0);
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
            this.label1.Location = new System.Drawing.Point(51, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ORTAKLIK EKRANI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbKontrol);
            this.groupBox1.Controls.Add(this.txtOtelKodu);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(28, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.groupBox1.Size = new System.Drawing.Size(302, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OTEL KODU";
            // 
            // pbKontrol
            // 
            this.pbKontrol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbKontrol.Image = global::TznOtelV1.Properties.Resources.plus;
            this.pbKontrol.Location = new System.Drawing.Point(262, 0);
            this.pbKontrol.Name = "pbKontrol";
            this.pbKontrol.Size = new System.Drawing.Size(39, 23);
            this.pbKontrol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbKontrol.TabIndex = 14;
            this.pbKontrol.TabStop = false;
            this.pbKontrol.Click += new System.EventHandler(this.pbKontrol_Click);
            this.pbKontrol.MouseLeave += new System.EventHandler(this.pbKontrol_MouseLeave);
            this.pbKontrol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbKontrol_MouseMove);
            // 
            // txtOtelKodu
            // 
            this.txtOtelKodu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOtelKodu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOtelKodu.ForeColor = System.Drawing.Color.Red;
            this.txtOtelKodu.Location = new System.Drawing.Point(15, 29);
            this.txtOtelKodu.MaxLength = 10;
            this.txtOtelKodu.Name = "txtOtelKodu";
            this.txtOtelKodu.Size = new System.Drawing.Size(272, 22);
            this.txtOtelKodu.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOtelAdi);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(27, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.groupBox2.Size = new System.Drawing.Size(302, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OTEL ADI";
            // 
            // txtOtelAdi
            // 
            this.txtOtelAdi.BackColor = System.Drawing.Color.White;
            this.txtOtelAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOtelAdi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOtelAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtOtelAdi.Location = new System.Drawing.Point(15, 29);
            this.txtOtelAdi.MaxLength = 30;
            this.txtOtelAdi.Name = "txtOtelAdi";
            this.txtOtelAdi.ReadOnly = true;
            this.txtOtelAdi.Size = new System.Drawing.Size(272, 22);
            this.txtOtelAdi.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOnayKodu);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(28, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.groupBox3.Size = new System.Drawing.Size(302, 54);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ONAY KODU";
            // 
            // txtOnayKodu
            // 
            this.txtOnayKodu.BackColor = System.Drawing.Color.White;
            this.txtOnayKodu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOnayKodu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOnayKodu.Location = new System.Drawing.Point(15, 29);
            this.txtOnayKodu.MaxLength = 5;
            this.txtOnayKodu.Name = "txtOnayKodu";
            this.txtOnayKodu.ReadOnly = true;
            this.txtOnayKodu.Size = new System.Drawing.Size(272, 22);
            this.txtOnayKodu.TabIndex = 0;
            // 
            // btnOnay
            // 
            this.btnOnay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOnay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnay.Enabled = false;
            this.btnOnay.FlatAppearance.BorderSize = 0;
            this.btnOnay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnay.ForeColor = System.Drawing.Color.White;
            this.btnOnay.Location = new System.Drawing.Point(43, 251);
            this.btnOnay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOnay.Name = "btnOnay";
            this.btnOnay.Size = new System.Drawing.Size(266, 35);
            this.btnOnay.TabIndex = 13;
            this.btnOnay.Text = "ONAYA GÖNDER";
            this.btnOnay.UseVisualStyleBackColor = false;
            this.btnOnay.Click += new System.EventHandler(this.btnOnay_Click);
            // 
            // lblKayitliKod
            // 
            this.lblKayitliKod.AutoSize = true;
            this.lblKayitliKod.Location = new System.Drawing.Point(52, 317);
            this.lblKayitliKod.Name = "lblKayitliKod";
            this.lblKayitliKod.Size = new System.Drawing.Size(54, 21);
            this.lblKayitliKod.TabIndex = 14;
            this.lblKayitliKod.Text = "label2";
            // 
            // frmOrtakGiris
            // 
            this.AcceptButton = this.btnOnay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 427);
            this.Controls.Add(this.lblKayitliKod);
            this.Controls.Add(this.btnOnay);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrtakGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrtakGiris";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKontrol)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOtelKodu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOtelAdi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOnayKodu;
        private System.Windows.Forms.PictureBox pbKontrol;
        private System.Windows.Forms.Button btnOnay;
        private System.Windows.Forms.Label lblKayitliKod;
    }
}