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
    public partial class OkuyucularıListele : Form
    {
        public OkuyucularıListele()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void OkuyuculariGetir()
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From Okuyucular", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }
      
        private void OkuyucularıListele_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("TcKimlikNo");
            comboBox1.Items.Add("Ad");
            comboBox1.Items.Add("Soyad");
            comboBox1.Items.Add("DogumTarihi");
            comboBox1.Items.Add("DogumYeri");
            comboBox1.Items.Add("Telefon");
            comboBox1.Items.Add("Cinsiyet");
            comboBox1.Items.Add("UyelikTarihi");
            comboBox1.Items.Add("Eposta");
            comboBox1.Items.Add("Adres");
            OkuyuculariGetir();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

        }
        private void button2_Click(object sender, EventArgs e) // Tabloyu Excele Aktarma
        {
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                myRange.Value2 = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = dataGridView1[i, j].Value;
                }
            }
        }
        private void textclear(Control ctl) //Yenile basıldığında her şeyi textboxları temizleme
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
        private void button3_Click(object sender, EventArgs e) //Yenile basıldığında her şeyi temizleme
        {
            textclear(this);
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }
        private void button4_Click(object sender, EventArgs e) //Güncelle
        {
            string sorgu = "update Okuyucular Set TCKimlikNo=@TCKimlikNo, Ad=@Ad, Soyad=@Soyad, DogumTarihi=@DogumTarihi,DogumYeri = @DogumYeri, Telefon = @Telefon, Cinsiyet = @Cinsiyet, UyelikTarihi = @UyelikTarihi, Eposta = @Eposta,Adres = @Adres Where TCKimlikNo = @TCKimlikNo";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@TCKimlikNo",textBox2.Text);
            komut.Parameters.AddWithValue("@Ad", textBox5.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@DogumTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@DogumYeri", textBox9.Text);
            komut.Parameters.AddWithValue("@Telefon", textBox6.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", textBox8.Text);
            komut.Parameters.AddWithValue("@UyelikTarihi", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@Eposta", textBox4.Text);
            komut.Parameters.AddWithValue("@Adres", textBox7.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            OkuyuculariGetir();
        } 
        private void button6_Click(object sender, EventArgs e) //Çıkış
        {
            this.Close();
            KütüphaneTakipIslemleri yeni = new KütüphaneTakipIslemleri();
            yeni.Hide();
            yeni.Show();
        }
        private void button5_Click(object sender, EventArgs e) //Sil
        {
            string sorgu = "Delete From Okuyucular Where TCKimlikNo=@TCKimlikNo";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@TCKimlikNo", textBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            OkuyuculariGetir();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) //Arama
        {
            if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("Select * From Okuyucular  " + " where(" + comboBox1.SelectedItem + " like '" + textBox1.Text + "%' )", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "Okuyucular");
                dataGridView1.DataSource = ds.Tables["Okuyucular"];
                baglanti.Close();
            }
            else
                MessageBox.Show("Lütfen arama türünü seçiniz..");
        }
    }
}
