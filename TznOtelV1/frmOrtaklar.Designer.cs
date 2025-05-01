namespace TznOtelV1
{
    partial class frmOrtaklar
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
            this.pnlUstmenu = new System.Windows.Forms.Panel();
            this.lblBizimTcmiz = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblortakKisiTcler = new System.Windows.Forms.Label();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlKisiListesi = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUstmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUstmenu
            // 
            this.pnlUstmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(216)))));
            this.pnlUstmenu.Controls.Add(this.lblBizimTcmiz);
            this.pnlUstmenu.Controls.Add(this.pictureBox1);
            this.pnlUstmenu.Controls.Add(this.lblortakKisiTcler);
            this.pnlUstmenu.Controls.Add(this.btn_cıkıs);
            this.pnlUstmenu.Controls.Add(this.label1);
            this.pnlUstmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUstmenu.Location = new System.Drawing.Point(0, 0);
            this.pnlUstmenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlUstmenu.Name = "pnlUstmenu";
            this.pnlUstmenu.Size = new System.Drawing.Size(565, 48);
            this.pnlUstmenu.TabIndex = 3;
            // 
            // lblBizimTcmiz
            // 
            this.lblBizimTcmiz.AutoSize = true;
            this.lblBizimTcmiz.Location = new System.Drawing.Point(326, 14);
            this.lblBizimTcmiz.Name = "lblBizimTcmiz";
            this.lblBizimTcmiz.Size = new System.Drawing.Size(54, 21);
            this.lblBizimTcmiz.TabIndex = 5;
            this.lblBizimTcmiz.Text = "label2";
            this.lblBizimTcmiz.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::TznOtelV1.Properties.Resources.Custom_Icon_Design_Pretty_Office_4_Couple_48;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblortakKisiTcler
            // 
            this.lblortakKisiTcler.AutoSize = true;
            this.lblortakKisiTcler.Location = new System.Drawing.Point(266, 15);
            this.lblortakKisiTcler.Name = "lblortakKisiTcler";
            this.lblortakKisiTcler.Size = new System.Drawing.Size(54, 21);
            this.lblortakKisiTcler.TabIndex = 4;
            this.lblortakKisiTcler.Text = "label2";
            this.lblortakKisiTcler.Visible = false;
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.ForeColor = System.Drawing.Color.White;
            this.btn_cıkıs.Location = new System.Drawing.Point(517, 0);
            this.btn_cıkıs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_cıkıs.Name = "btn_cıkıs";
            this.btn_cıkıs.Size = new System.Drawing.Size(48, 48);
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
            this.label1.Location = new System.Drawing.Point(54, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ORTAK LİSTE EKRANI";
            // 
            // pnlKisiListesi
            // 
            this.pnlKisiListesi.AutoScroll = true;
            this.pnlKisiListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKisiListesi.Location = new System.Drawing.Point(0, 48);
            this.pnlKisiListesi.Name = "pnlKisiListesi";
            this.pnlKisiListesi.Size = new System.Drawing.Size(565, 267);
            this.pnlKisiListesi.TabIndex = 5;
            // 
            // frmOrtaklar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 315);
            this.Controls.Add(this.pnlKisiListesi);
            this.Controls.Add(this.pnlUstmenu);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrtaklar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrtaklar";
            this.Load += new System.EventHandler(this.frmOrtaklar_Load);
            this.pnlUstmenu.ResumeLayout(false);
            this.pnlUstmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUstmenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblortakKisiTcler;
        private System.Windows.Forms.FlowLayoutPanel pnlKisiListesi;
        public System.Windows.Forms.Label lblBizimTcmiz;
    }
}