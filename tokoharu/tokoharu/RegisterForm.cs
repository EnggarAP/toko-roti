using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace tokoharu
{
    public partial class RegisterForm : Form
    {
        string connectionString = "Server=localhost;Database=tokoharu;Uid=root;Pwd=;";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = textBox1.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Cek apakah username sudah ada
                    string checkQuery = "SELECT COUNT(*) FROM user WHERE username = @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Username sudah digunakan. Pilih username lain.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Simpan data pengguna
                    string insertQuery = "INSERT INTO user (username, password) VALUES (@username, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registrasi berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Registrasi gagal. Coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}