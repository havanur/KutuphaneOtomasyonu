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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitapListele kitaplistele = new kitapListele();
            kitaplistele.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OkuyucularıListele okuyucularılistele = new OkuyucularıListele();
            okuyucularılistele.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmanetAlVer emanet = new EmanetAlVer();
            emanet.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmanetVerilenKitaplar emanetverilen = new EmanetVerilenKitaplar();
            emanetverilen.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KitapEkle kitapekle = new KitapEkle();
            kitapekle.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OkuyucuEkle okuyucuekle = new OkuyucuEkle();
            okuyucuekle.Show();
            this.Hide();
        }
    }
}
