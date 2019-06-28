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
    public partial class kullanici : Form
    {
        public kullanici()
        {
            InitializeComponent();
        }

        private void btn_kullaniciKayit_Click(object sender, EventArgs e)
        {
            YeniKullaniciKayit yeni = new YeniKullaniciKayit();
            yeni.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection("Server=(localdb)\\V11.0; Initial Catalog=KütüphaneDB;Integrated Security=SSPI ");
        SqlDataReader dr;

        private void btn_kullaniciGiris_Click(object sender, EventArgs e)
        {
            
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Kullanicilar",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Kullanicilar";
                cmd.Parameters.AddWithValue("@KullaniciAdi",txt_kullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@KullaniciSifre", txt_kullaniciSifre.Text);
                dr = cmd.ExecuteReader();
                
                if(dr.Read())
                { 
                    KütüphaneTakipIslemleri yeni = new KütüphaneTakipIslemleri();
                    yeni.Show();
                   this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("HATALI GİRİŞ");
                }
                 con.Close();








        }
    }
}
