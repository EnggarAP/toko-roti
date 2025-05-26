using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace tokoharu
{
    public partial class menu2 : Form
    {
        public menu2()
        {
            InitializeComponent();
        }

        private void menu2_Load(object sender, EventArgs e)
        {
            // Load event if needed
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli kue ulang tahun bentuk karakter");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli kue ulang tahun bentuk angka");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli kue ulang tahun bentuk bunga");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli kue ulang tahun bentuk foto");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli kue ulang tahun bentuk custom");
        }

        // Fungsi untuk membuka WhatsApp dengan pesan berbeda
        private void OpenWhatsApp(string pesan)
        {
            string url = "https://wa.me/6282335882451?text=" + Uri.EscapeDataString(pesan);

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pindah ke form Roti Kering
            menu menu = new menu();
            menu.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Pindah ke form Roti Ultah (form ini sendiri)
            MessageBox.Show("Anda sudah berada di menu Roti Ultah.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pindah ke form Kue
            menu3 menu3 = new menu3();
            menu3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Pindah ke form Minuman
            menu4 menu4 = new menu4();
            menu4.Show();
        }
    }
}
