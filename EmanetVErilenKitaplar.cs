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
    public partial class EmanetVerilenKitaplar : Form
    {
        public EmanetVerilenKitaplar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void EmanetVerilenKitaplariGetir()
        {
            baglanti = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From Emanet", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            

        }
        private void EmanetVerilenKitaplar_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("KitapID");
            comboBox1.Items.Add("KisiTCkimlikNo");
            comboBox1.Items.Add("KitapBarkodNo");
            comboBox1.Items.Add("KitapDurumu");
            comboBox1.Items.Add("TeslimDurumu");
            EmanetVerilenKitaplariGetir();
        }

        private void button2_Click(object sender, EventArgs e) //Tabloyu Excele aktar
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

        private void button1_Click(object sender, EventArgs e) //Çıkış
        {
            this.Close();
            KütüphaneTakipIslemleri yeni = new KütüphaneTakipIslemleri();
            yeni.Hide();
            yeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "Seçiniz..";
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Arama
        {
            if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("Select * From Emanet  " + " where(" + comboBox1.SelectedItem + " like '" + textBox1.Text + "%' )", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "Emanet");
                dataGridView1.DataSource = ds.Tables["Emanet"];
                baglanti.Close();
            }
            else
                MessageBox.Show("Lütfen arama türünü seçiniz..");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            EmanetAlVer emanet = new EmanetAlVer();
            emanet.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EmanetAlVer emanet = new EmanetAlVer();
            emanet.Show();
        }
    }
}
