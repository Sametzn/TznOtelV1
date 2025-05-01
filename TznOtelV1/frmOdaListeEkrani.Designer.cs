namespace TznOtelV1
{
    partial class frmOdaListeEkrani
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.odaListePaneli = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(167)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnKapat);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1560, 48);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::TznOtelV1.Properties.Resources.list;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(1512, 0);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(48, 48);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "X";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "ODA LİSTE EKRANI";
            // 
            // odaListePaneli
            // 
            this.odaListePaneli.AutoScroll = true;
            this.odaListePaneli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.odaListePaneli.Location = new System.Drawing.Point(0, 48);
            this.odaListePaneli.Name = "odaListePaneli";
            this.odaListePaneli.Size = new System.Drawing.Size(1560, 633);
            this.odaListePaneli.TabIndex = 5;
            // 
            // frmOdaListeEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 681);
            this.Controls.Add(this.odaListePaneli);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(201, 48);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOdaListeEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOdaListeEkrani";
            this.Activated += new System.EventHandler(this.frmOdaListeEkrani_Activated);
            this.Load += new System.EventHandler(this.frmOdaListeEkrani_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel odaListePaneli;
    }
}