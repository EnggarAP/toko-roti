using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tokoharu
{
    public partial class profileAdmin : Form
    {
        private readonly dbconnection db = new dbconnection();

        public profileAdmin()
        {
            InitializeComponent();
        }

        private void profileAdmin_Load(object sender, EventArgs e)
        {
            LoadAdminName();
        }

        private void LoadAdminName()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT nama FROM admin LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = reader["nama"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil nama admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Logout()
        {
            var result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart(); // Atau arahkan ke login form jika ada
            }
        }

        private void OpenOrderForm()
        {
            this.Hide();
            using (order orderForm = new order())
            {
                orderForm.ShowDialog();
            }
            this.Show();
        }


        private void OpenUserAccountForm()
        {
            this.Hide();
            using (userAccount userAccountForm = new userAccount())
            {
                userAccountForm.ShowDialog();
            }
            this.Show();
        }

        private void OpenprofileAdmin()
        {
            MessageBox.Show("Anda sudah berada di menu Minuman.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logoutadminbtn_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenOrderForm();
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            OpenUserAccountForm();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenprofileAdmin();
        }
    }
}
