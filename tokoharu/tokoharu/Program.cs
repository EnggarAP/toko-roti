using System;
using System.Windows.Forms;

namespace tokoharu
{
    static class Program
    {
        // Variabel global untuk menyimpan username pengguna yang login
        public static string CurrentUsername = "";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Mulai dari login
            Application.Run(new LoginForm());
        }

        // Method untuk membuka form dari manapun
        public static void ShowForm(Form form)
        {
            form.Show();
        }
    }
}