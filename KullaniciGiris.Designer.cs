namespace KütüphaneOtomasyonu
{
    partial class kullanici
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
            this.lb_kullaniciAdi = new System.Windows.Forms.Label();
            this.lb_kullaniciSifre = new System.Windows.Forms.Label();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.txt_kullaniciSifre = new System.Windows.Forms.TextBox();
            this.btn_kullaniciKayit = new System.Windows.Forms.Button();
            this.btn_kullaniciGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_kullaniciAdi
            // 
            this.lb_kullaniciAdi.AutoSize = true;
            this.lb_kullaniciAdi.Location = new System.Drawing.Point(35, 13);
            this.lb_kullaniciAdi.Name = "lb_kullaniciAdi";
            this.lb_kullaniciAdi.Size = new System.Drawing.Size(64, 13);
            this.lb_kullaniciAdi.TabIndex = 0;
            this.lb_kullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // lb_kullaniciSifre
            // 
            this.lb_kullaniciSifre.AutoSize = true;
            this.lb_kullaniciSifre.Location = new System.Drawing.Point(35, 45);
            this.lb_kullaniciSifre.Name = "lb_kullaniciSifre";
            this.lb_kullaniciSifre.Size = new System.Drawing.Size(70, 13);
            this.lb_kullaniciSifre.TabIndex = 1;
            this.lb_kullaniciSifre.Text = "Kullanıcı Şifre";
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(116, 13);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(149, 20);
            this.txt_kullaniciAdi.TabIndex = 2;
            // 
            // txt_kullaniciSifre
            // 
            this.txt_kullaniciSifre.Location = new System.Drawing.Point(116, 45);
            this.txt_kullaniciSifre.Name = "txt_kullaniciSifre";
            this.txt_kullaniciSifre.Size = new System.Drawing.Size(149, 20);
            this.txt_kullaniciSifre.TabIndex = 3;
            // 
            // btn_kullaniciKayit
            // 
            this.btn_kullaniciKayit.Location = new System.Drawing.Point(12, 92);
            this.btn_kullaniciKayit.Name = "btn_kullaniciKayit";
            this.btn_kullaniciKayit.Size = new System.Drawing.Size(95, 23);
            this.btn_kullaniciKayit.TabIndex = 4;
            this.btn_kullaniciKayit.Text = "Yeni Kullanıcı";
            this.btn_kullaniciKayit.UseVisualStyleBackColor = true;
            this.btn_kullaniciKayit.Click += new System.EventHandler(this.btn_kullaniciKayit_Click);
            // 
            // btn_kullaniciGiris
            // 
            this.btn_kullaniciGiris.Location = new System.Drawing.Point(190, 92);
            this.btn_kullaniciGiris.Name = "btn_kullaniciGiris";
            this.btn_kullaniciGiris.Size = new System.Drawing.Size(75, 23);
            this.btn_kullaniciGiris.TabIndex = 5;
            this.btn_kullaniciGiris.Text = "Giriş";
            this.btn_kullaniciGiris.UseVisualStyleBackColor = true;
            this.btn_kullaniciGiris.Click += new System.EventHandler(this.btn_kullaniciGiris_Click);
            // 
            // kullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 135);
            this.Controls.Add(this.btn_kullaniciGiris);
            this.Controls.Add(this.btn_kullaniciKayit);
            this.Controls.Add(this.txt_kullaniciSifre);
            this.Controls.Add(this.txt_kullaniciAdi);
            this.Controls.Add(this.lb_kullaniciSifre);
            this.Controls.Add(this.lb_kullaniciAdi);
            this.Name = "kullanici";
            this.Text = "Kullanıcı Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_kullaniciAdi;
        private System.Windows.Forms.Label lb_kullaniciSifre;
        private System.Windows.Forms.TextBox txt_kullaniciAdi;
        private System.Windows.Forms.TextBox txt_kullaniciSifre;
        private System.Windows.Forms.Button btn_kullaniciKayit;
        private System.Windows.Forms.Button btn_kullaniciGiris;
    }
}

