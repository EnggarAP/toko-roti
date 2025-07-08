using System;
using System.Windows.Forms;
using tokoharu.Views.Auth;
using TokoHaru.Controllers;
using tokoharu.Models;

namespace TokoHaru.Views.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly AuthController _authController;

        public RegisterForm()
        {
            InitializeComponent();
            var dbConnection = new DBConnection();
            _authController = new AuthController(dbConnection);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = lblPassword.Text;
            string confirmPassword = lblConfirmPassword.Text;

            // Validasi input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password dan konfirmasi password tidak sama.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool registrationResult = _authController.RegisterUser(username, password);

                if (registrationResult)
                {
                    MessageBox.Show("Registrasi berhasil!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Pindah ke form login setelah registrasi berhasil
                    this.Hide();
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username sudah digunakan atau registrasi gagal.",
                        "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Pindah ke form login
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}