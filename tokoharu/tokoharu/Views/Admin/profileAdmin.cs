using System;
using System.Windows.Forms;
using tokoharu.Controllers;
using tokoharu.Views.Auth;
using tokoharu.Models;
using TokoHaru.Views.Order;

namespace TokoHaru.Views.Admin
{
    public partial class profileAdmin : Form
    {
        private readonly AdminController _adminController;

        public profileAdmin()
        {
            InitializeComponent();

            var dbConnection = new DBConnection();
            _adminController = new AdminController(dbConnection);

            LoadAdminProfile();
        }

        private void LoadAdminProfile()
        {
            try
            {
                string adminName = _adminController.GetAdminName();

                if (!string.IsNullOrEmpty(adminName))
                {
                    label1.Text = $"Selamat datang, {adminName}";
                }
                else
                {
                    label1.Text = "Selamat datang, Admin";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat profil admin.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            var orderForm = new order();  // Pastikan class `order` ada dan sesuai namespace
            orderForm.ShowDialog();
            this.Show();
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userAccountForm = new userAccount();  // Pastikan class `userAccount` tersedia
            userAccountForm.ShowDialog();
            this.Show();
        }

        private void profileAdmin_Load(object sender, EventArgs e)
        {
            // Event saat form pertama kali load, bisa diisi nanti jika perlu
        }
    }
}
