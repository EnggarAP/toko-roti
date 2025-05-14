using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tokoharu
{
    public partial class userAccount : Form
    {
        dbconnection db = new dbconnection();

        public userAccount()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT userid, username FROM user";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private void UpdateUser()
        {
            if (dataGridView1.CurrentRow == null) return;

            int userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["userid"].Value);
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE user SET username = @username WHERE userid = @userid";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@username", inputuser.Text);
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                    MessageBox.Show("User berhasil diupdate.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update user: " + ex.Message);
                }
            }
        }

        private void DeleteUser()
        {
            if (dataGridView1.CurrentRow == null) return;

            int userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["userid"].Value);
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM user WHERE userid = @userid";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                    MessageBox.Show("User berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal hapus user: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                inputuser.Text = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DeleteUser();
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

        private void OpenProfileForm()
        {
            this.Hide();
            using (profileAdmin profileAdminForm = new profileAdmin())
            {
                profileAdminForm.ShowDialog();
            }
            this.Show();
        }

        private void OpenUserAccountForm()
        {
            MessageBox.Show("Anda sudah berada di menu Minuman.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            OpenOrderForm();
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            OpenProfileForm();
        }

        private void btnuserAccount_Click(object sender, EventArgs e)
        {
            OpenUserAccountForm();

        }
    }
}
