using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace tokoharu
{
    public partial class menu3 : Form
    {
        public menu3()
        {
            InitializeComponent();
        }

        private void menu3_Load(object sender, EventArgs e)
        {
            // Load event if needed
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli CHEESE BLACKBERRY seharga Rp. 21000");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli CHEESE RASBERRY seharga Rp. 21000");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli STRAWBERRY COCHO seharga Rp. 23000");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli CHEESE CHERRY seharga Rp. 21000");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenWhatsApp("Saya ingin membeli STRAWBERRY ROSE seharga Rp. 19000");
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
            // Pindah ke form Kue (form ini sendiri)
            MessageBox.Show("Anda sudah berada di menu Kue.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Pindah ke form Minuman
            menu4 minumanForm = new menu4();
            minumanForm.Show();
            this.Hide();
        }
    }
}
