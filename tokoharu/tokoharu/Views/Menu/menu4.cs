using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace tokoharu
{
    public partial class menu4 : Form
    {
        public menu4()
        {
            InitializeComponent();
        }

        private void menu4_Load(object sender, EventArgs e)
        {
            // Load event if needed
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli GRAPE SQUASH seharga Rp. 11000");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli OCEAN BLUE SQUASH seharga Rp. 11000");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli LEMON SQUASH seharga Rp. 11000");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli MATCHA LATTE seharga Rp. 12000");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli COFFEE LATTE seharga Rp. 13000");
        }

        // Fungsi untuk membuka WhatsApp dengan pesan tertentu
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

        private void button9_Click(object sender, EventArgs e)
        {
            // Pindah ke form Roti Ultah
            menu2 rotiUltahForm = new menu2();
            rotiUltahForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pindah ke form Roti Kering
            menu rotiKeringForm = new menu();
            rotiKeringForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pindah ke form Kue
            menu3 kueForm = new menu3();
            kueForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Pindah ke form Minuman (form ini sendiri)
            MessageBox.Show("Anda sudah berada di menu Minuman.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
