using System;
using System.Data;
using System.Windows.Forms;
using TokoHaru.Controllers;
using tokoharu.Models;

namespace TokoHaru.Views.Admin
{
    public partial class userAccount : Form
    {
        private readonly UserController _userController;

        public userAccount()
        {
            InitializeComponent();
            var dbConnection = new DBConnection();
            _userController = new UserController(dbConnection);
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                dataGridView1.DataSource = _userController.GetAllUsers();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void UpdateUser()
        {
            if (dataGridView1.CurrentRow == null) return;

            int userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["userid"].Value);
            if (_userController.UpdateUser(userId, inputuser.Text))
            {
                LoadUsers();
                MessageBox.Show("User updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update user.");
            }
        }

        private void DeleteUser()
        {
            if (dataGridView1.CurrentRow == null) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this user?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["userid"].Value);
                if (_userController.DeleteUser(userId))
                {
                    LoadUsers();
                    MessageBox.Show("User deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["username"].Value != null)
            {
                inputuser.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userAccount_Load(object sender, EventArgs e)
        {

        }
    }
}