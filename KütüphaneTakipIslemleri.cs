using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class KütüphaneTakipIslemleri : Form
    {
        public KütüphaneTakipIslemleri()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e) //Çıkış
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) //Kitap Listesi formu
        {
            kitapListele kitaplistele = new kitapListele();
            kitaplistele.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //Okuyucu listesi formu
        {
            OkuyucularıListele okuyucularılistele = new OkuyucularıListele();
            okuyucularılistele.Show();
            this.Hide();
        }

       
        private void button5_Click(object sender, EventArgs e) //Kitap ekleme formu
        {
            KitapEkle kitapekle = new KitapEkle();
            kitapekle.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e) //okuyucu ekleme formu
        {
            OkuyucuEkle okuyucuekle = new OkuyucuEkle();
            okuyucuekle.Show();
            this.Hide();
        }
    }
}
