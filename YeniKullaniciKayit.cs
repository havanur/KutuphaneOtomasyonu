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
    public partial class YeniKullaniciKayit : Form
    {
        public YeniKullaniciKayit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI ");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Kullanicilar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_YeniKullanici";
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@KullaniciSifre", textBox2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            kullanici yeni = new kullanici();
            yeni.Show();
            this.Hide();
        }
    }
}
