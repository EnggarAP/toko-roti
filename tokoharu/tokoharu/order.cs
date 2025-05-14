using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tokoharu
{
    public partial class order : Form
    {
        dbconnection db = new dbconnection();

        public order()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idorder, nama, menu, harga FROM `order`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void InsertOrder()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO `order` (nama, menu, harga) VALUES (@nama, @menu, @harga)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", inputpembeli.Text);
                    cmd.Parameters.AddWithValue("@menu", textBox1.Text);
                    cmd.Parameters.AddWithValue("@harga", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    LoadOrders();
                    MessageBox.Show("Data berhasil ditambahkan.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan data: " + ex.Message);
                }
            }
        }

        private void UpdateOrder()
        {
            if (dataGridView1.CurrentRow == null) return;

            int idorder = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idorder"].Value);
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE `order` SET nama = @nama, menu = @menu, harga = @harga WHERE idorder = @idorder";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idorder", idorder);
                    cmd.Parameters.AddWithValue("@nama", inputpembeli.Text);
                    cmd.Parameters.AddWithValue("@menu", textBox1.Text);
                    cmd.Parameters.AddWithValue("@harga", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    LoadOrders();
                    MessageBox.Show("Data berhasil diupdate.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update data: " + ex.Message);
                }
            }
        }

        private void DeleteOrder()
        {
            if (dataGridView1.CurrentRow == null) return;

            int idorder = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idorder"].Value);
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM `order` WHERE idorder = @idorder";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idorder", idorder);
                    cmd.ExecuteNonQuery();
                    LoadOrders();
                    MessageBox.Show("Data berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal hapus data: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                inputpembeli.Text = dataGridView1.CurrentRow.Cells["nama"].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells["menu"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["harga"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e) // Tombol Tambah
        {
            InsertOrder();
        }

        private void button8_Click(object sender, EventArgs e) // Tombol Edit
        {
            UpdateOrder();
        }

        private void button7_Click(object sender, EventArgs e) // Tombol Hapus
        {
            DeleteOrder();
        }

        private void OpenOrderForm()
        {
            MessageBox.Show("Anda sudah berada di menu Minuman.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Hide();
            using (userAccount userAccountForm = new userAccount())
            {
                userAccountForm.ShowDialog();
            }
            this.Show();
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
