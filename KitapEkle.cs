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

namespace KütüphaneOtomasyonu
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

         void kitap_türü()
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From KitapTürü", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "KitapTürü";
            comboBox2.DataSource = dt;

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Kapat
        {
            this.Close();
            KütüphaneTakipIslemleri yeni = new KütüphaneTakipIslemleri();
            yeni.Hide();
            yeni.Show();
        }
        private void textclear(Control ctl) //Temizleye basıldığında textboxları temizleme
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }

                if (item.Controls.Count > 0)
                {
                    textclear(item);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) //Temizleme
        {
            textclear(this);
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            numericUpDown1.ResetText();
        }
        private void button3_Click(object sender, EventArgs e) //Kaydet
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            string sorgu = "Insert Into Kitaplar (BarkodNo,KitapAdi,YazarAdi,YayinEvi,SayfaSayisi,KitapTürü,TeminTürü,TeminTarihi,CiltNo,StokSayisi) Values (@BarkodNo,@KitapAdi,@YazarAdi,@YayinEvi,@SayfaSayisi,@KitapTürü,@TeminTürü,@TeminTarihi,@CiltNo,@StokSayisi)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BarkodNo", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@KitapAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@YazarAdi", textBox3.Text);
            komut.Parameters.AddWithValue("@YayinEvi", textBox4.Text);
            komut.Parameters.AddWithValue("@SayfaSayisi", Convert.ToInt32(textBox5.Text));
            komut.Parameters.AddWithValue("@KitapTürü", comboBox1.Text);
            komut.Parameters.AddWithValue("@TeminTürü", comboBox2.Text);
            komut.Parameters.AddWithValue("@TeminTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@CiltNo", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@StokSayisi", numericUpDown1.Value);
            
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap Kaydedildi.");
        }
        private void KitapEkle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Satın Alma");
            comboBox1.Items.Add("Bağış");
            kitap_türü();
        }
    }
}
