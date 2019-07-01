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
            this.btn_kullaniciGiris = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_kullaniciAdi
            // 
            this.lb_kullaniciAdi.AutoSize = true;
            this.lb_kullaniciAdi.Location = new System.Drawing.Point(12, 18);
            this.lb_kullaniciAdi.Name = "lb_kullaniciAdi";
            this.lb_kullaniciAdi.Size = new System.Drawing.Size(64, 13);
            this.lb_kullaniciAdi.TabIndex = 0;
            this.lb_kullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // lb_kullaniciSifre
            // 
            this.lb_kullaniciSifre.AutoSize = true;
            this.lb_kullaniciSifre.Location = new System.Drawing.Point(12, 50);
            this.lb_kullaniciSifre.Name = "lb_kullaniciSifre";
            this.lb_kullaniciSifre.Size = new System.Drawing.Size(70, 13);
            this.lb_kullaniciSifre.TabIndex = 1;
            this.lb_kullaniciSifre.Text = "Kullanıcı Şifre";
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(93, 18);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(149, 20);
            this.txt_kullaniciAdi.TabIndex = 2;
            // 
            // txt_kullaniciSifre
            // 
            this.txt_kullaniciSifre.Location = new System.Drawing.Point(93, 50);
            this.txt_kullaniciSifre.Name = "txt_kullaniciSifre";
            this.txt_kullaniciSifre.PasswordChar = '*';
            this.txt_kullaniciSifre.Size = new System.Drawing.Size(149, 20);
            this.txt_kullaniciSifre.TabIndex = 3;
            // 
            // btn_kullaniciGiris
            // 
            this.btn_kullaniciGiris.Location = new System.Drawing.Point(167, 86);
            this.btn_kullaniciGiris.Name = "btn_kullaniciGiris";
            this.btn_kullaniciGiris.Size = new System.Drawing.Size(75, 23);
            this.btn_kullaniciGiris.TabIndex = 5;
            this.btn_kullaniciGiris.Text = "Giriş";
            this.btn_kullaniciGiris.UseVisualStyleBackColor = true;
            this.btn_kullaniciGiris.Click += new System.EventHandler(this.btn_kullaniciGiris_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 135);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_kullaniciGiris);
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
        private System.Windows.Forms.Button btn_kullaniciGiris;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_kullaniciSifre;
    }
}

