using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using tokoharu.Views.Auth;

namespace tokoharu.Views.Auth
{
    public partial class LoginForm : Form
    {
        string connectionString = "Server=localhost;Database=tokoharu;Uid=root;Pwd=;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Cek login admin
                    string adminQuery = "SELECT COUNT(*) FROM admin WHERE username = @username AND password = @password";
                    using (MySqlCommand adminCmd = new MySqlCommand(adminQuery, conn))
                    {
                        adminCmd.Parameters.AddWithValue("@username", username);
                        adminCmd.Parameters.AddWithValue("@password", password);

                        int adminCount = Convert.ToInt32(adminCmd.ExecuteScalar());

                        if (adminCount > 0)
                        {
                            MessageBox.Show("Login sebagai Admin berhasil!");
                            this.Hide();
                            profileAdmin profile = new profileAdmin();
                            profile.ShowDialog();
                            this.Close();
                            return;
                        }
                    }

                    // Jika bukan admin, cek user
                    string userQuery = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                    using (MySqlCommand userCmd = new MySqlCommand(userQuery, conn))
                    {
                        userCmd.Parameters.AddWithValue("@username", username);
                        userCmd.Parameters.AddWithValue("@password", password);

                        int userCount = Convert.ToInt32(userCmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login sebagai User berhasil!");
                            this.Hide();
                            menu2 menu = new menu2();
                            menu.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username atau password salah.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan koneksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Kosong atau inisialisasi jika diperlukan
        }

        private void backRegist(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
            this.Hide();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
