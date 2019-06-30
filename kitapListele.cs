using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KütüphaneOtomasyonu
{
    public partial class kitapListele : Form
    {
        public kitapListele()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void KitaplariGetir()
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From Kitaplar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            int kayit=-1;
            kayit += dataGridView1.Rows.Count;
            label14.Text = kayit.ToString();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            numericUpDown1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();


        }

        private void kitapListele_Load(object sender, EventArgs e)
        {
            //kayitlikitap();
            comboBox1.Items.Add("BarkodNo");
            comboBox1.Items.Add("KitapAdi");
            comboBox1.Items.Add("YazarAdi");
            comboBox1.Items.Add("YayinEvi");
            comboBox1.Items.Add("SayfaSayisi");
            comboBox1.Items.Add("KitapTürü");
            comboBox1.Items.Add("TeminTürü");
            comboBox1.Items.Add("CiltNo");
            comboBox1.Items.Add("StokSayisi");
            KitaplariGetir();
        }

       /* void kayitlikitap() //Kayıtlı Kitap sayısı
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            SqlCommand kitapsayisi = new SqlCommand("Select Count(*) From Kitaplar", baglanti);
            label14.Text = "Kayıtlı Kitap Sayısı :" + (int)kitapsayisi.ExecuteScalar();
        }*/

        private void button3_Click(object sender, EventArgs e)//Yenile butonuna basıldığında kitapbilgilerini silme
        {
            textclear(this);
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
           

        }

        private void textclear(Control ctl) //Yenile butonuna basıldığında textbox verileri silme
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

        private void button4_Click(object sender, EventArgs e)//Güncelle
        {
            string sorgu = "update Kitaplar Set BarkodNo=@BarkodNo, KitapAdi=@KitapAdi, YazarAdi=@YazarAdi, YayinEvi=@YayinEvi,SayfaSayisi = @SayfaSayisi, KitapTürü = @KitapTürü, TeminTürü = @TeminTürü, TeminTarihi = @TeminTarihi, CiltNo = @CiltNo,StokSayisi = @StokSayisi Where BarkodNo = @BarkodNo";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BarkodNo", Convert.ToInt32(textBox2.Text));
            komut.Parameters.AddWithValue("@KitapAdi", textBox3.Text);
            komut.Parameters.AddWithValue("@YazarAdi", textBox4.Text);
            komut.Parameters.AddWithValue("@YayinEvi", textBox5.Text);
            komut.Parameters.AddWithValue("@SayfaSayisi", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@KitapTürü", comboBox2.Text);
            komut.Parameters.AddWithValue("@TeminTürü", comboBox3.Text);
            komut.Parameters.AddWithValue("@TeminTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@CiltNo", Convert.ToInt32(textBox7.Text));
            komut.Parameters.AddWithValue("@StokSayisi",numericUpDown1.Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            //kayitlikitap();



            KitaplariGetir();
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
            string sorgu = "Delete From Kitaplar Where BarkodNo=@BarkodNo";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@BarkodNo", Convert.ToInt32(textBox2.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            KitaplariGetir();
            //kayitlikitap();
        } 

        private void textBox1_TextChanged(object sender, EventArgs e) //ARAMA
        {
            if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("Select * From Kitaplar  " + " where(" + comboBox1.SelectedItem + " like '" + textBox1.Text + "%' )", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "Kitaplar");
                dataGridView1.DataSource = ds.Tables["Kitaplar"];
                baglanti.Close();
            }
            else
                MessageBox.Show("Lütfen arama türünü seçiniz..");
        }
    }
}
          