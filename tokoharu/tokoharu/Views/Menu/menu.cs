using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace tokoharu
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            // Bisa digunakan untuk inisialisasi
        }

        // Tombol-tombol untuk pemesanan via WhatsApp
        private void button8_Click(object sender, EventArgs e) => OpenWhatsApp();
        private void button7_Click(object sender, EventArgs e) => OpenWhatsApp();
        private void button6_Click(object sender, EventArgs e) => OpenWhatsApp();
        private void button5_Click(object sender, EventArgs e) => OpenWhatsApp();
        private void button4_Click(object sender, EventArgs e) => OpenWhatsApp();

        // Fungsi untuk membuka WhatsApp dengan pesan untuk roti kering
        private void OpenWhatsApp()
        {
            string pesan = "Saya ingin membeli roti kering";
            string url = "https://wa.me/6282335882451?text=" + Uri.EscapeDataString(pesan);

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka WhatsApp: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigasi antar menu
        private void button2_Click(object sender, EventArgs e)
        {
            // Buka menu2 (Kue Ulang Tahun)
            menu2 menu2 = new menu2();
            menu2.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Form ini sendiri (Roti Kering), tidak perlu dibuka ulang
            MessageBox.Show("Anda sudah berada di menu Roti Kering.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Buka menu3 (Kue)
            menu3 menu3 = new menu3();
            menu3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Buka menu4 (Minuman)
            menu4 menu4 = new menu4();
            menu4.Show();
            this.Hide();
        }
    }
}
