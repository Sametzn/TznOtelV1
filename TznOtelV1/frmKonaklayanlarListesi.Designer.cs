namespace TznOtelV1
{
    partial class frmKonaklayanlarListesi
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flpmisafir = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUstmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUstmenu
            // 
            this.pnlUstmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(216)))));
            this.pnlUstmenu.Controls.Add(this.pictureBox1);
            this.pnlUstmenu.Controls.Add(this.btn_cıkıs);
            this.pnlUstmenu.Controls.Add(this.label1);
            this.pnlUstmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUstmenu.Location = new System.Drawing.Point(0, 0);
            this.pnlUstmenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlUstmenu.Name = "pnlUstmenu";
            this.pnlUstmenu.Size = new System.Drawing.Size(456, 48);
            this.pnlUstmenu.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TznOtelV1.Properties.Resources.Custom_Icon_Design_Pretty_Office_4_Couple_48;
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.ForeColor = System.Drawing.Color.White;
            this.btn_cıkıs.Location = new System.Drawing.Point(408, 0);
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
            this.label1.Location = new System.Drawing.Point(46, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "KONAKLAYAN LİSTESİ";
            // 
            // flpmisafir
            // 
            this.flpmisafir.AutoScroll = true;
            this.flpmisafir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpmisafir.Location = new System.Drawing.Point(0, 48);
            this.flpmisafir.Name = "flpmisafir";
            this.flpmisafir.Size = new System.Drawing.Size(456, 388);
            this.flpmisafir.TabIndex = 3;
            // 
            // frmKonaklayanlarListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 436);
            this.Controls.Add(this.flpmisafir);
            this.Controls.Add(this.pnlUstmenu);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKonaklayanlarListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKonaklayanlarListesi";
            this.Load += new System.EventHandler(this.frmKonaklayanlarListesi_Load);
            this.pnlUstmenu.ResumeLayout(false);
            this.pnlUstmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUstmenu;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flpmisafir;
    }
}