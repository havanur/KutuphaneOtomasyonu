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
    public partial class OkuyucuEkle : Form
    {
        public OkuyucuEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void sehir_doldur()
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From Sehirler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "SehirNo";
            comboBox1.DisplayMember = "SehirAdi";
            comboBox1.DataSource = dt;

            baglanti.Close();

        }

        private void OkuyucuEkle_Load(object sender, EventArgs e)
        {
            sehir_doldur();
        }

        private void button1_Click(object sender, EventArgs e) //Kaydet
        {
            string sorgu = "Insert Into Okuyucular(TCKimlikNo,Ad,Soyad, DogumTarihi,DogumYeri,Telefon, Cinsiyet,UyelikTarihi,Eposta,Adres) Values (@TCKimlikNo,@Ad,@Soyad, @DogumTarihi,@DogumYeri,@Telefon, @Cinsiyet,@UyelikTarihi,@Eposta,@Adres)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@TCKimlikNo", textBox1.Text);
            komut.Parameters.AddWithValue("@Ad", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@DogumTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@DogumYeri", comboBox1.Text);
            komut.Parameters.AddWithValue("@Telefon", textBox4.Text);
            string cinsiyet = "";
            if(radioButton1.Checked)
                cinsiyet = radioButton1.Text;
            else if (radioButton2.Checked)
                cinsiyet = radioButton2.Text;
            komut.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@UyelikTarihi", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@Eposta", textBox5.Text);
            komut.Parameters.AddWithValue("@Adres", textBox6.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Okuyucu Kaydedildi.");
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
            dateTimePicker2.Text = "";
            radioButton1.Text = "";
            radioButton2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) //Kapat
        {
            this.Close();
            KütüphaneTakipIslemleri yeni = new KütüphaneTakipIslemleri();
            yeni.Hide();
            yeni.Show();
        }
    }
}
