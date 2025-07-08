using System;
using System.Data;
using System.Windows.Forms;
using TokoHaru.Controllers;
using tokoharu.Models;

namespace TokoHaru.Views.Order
{
    public partial class order : Form
    {
        private readonly OrderController _orderController;

        public order()
        {
            InitializeComponent();
            var dbConnection = new DBConnection();
            _orderController = new OrderController(dbConnection);
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                dataGridView1.DataSource = _orderController.GetAllOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void InsertOrder()
        {
            try
            {
                if (_orderController.AddOrder(inputpembeli.Text, textBox1.Text, textBox2.Text))
                {
                    LoadOrders();
                    MessageBox.Show("Data berhasil ditambahkan.");
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UpdateOrder()
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int idorder = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idorder"].Value);
                if (_orderController.UpdateOrder(idorder, inputpembeli.Text, textBox1.Text, textBox2.Text))
                {
                    LoadOrders();
                    MessageBox.Show("Data berhasil diupdate.");
                }
                else
                {
                    MessageBox.Show("Gagal update data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteOrder()
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int idorder = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idorder"].Value);
                if (_orderController.DeleteOrder(idorder))
                {
                    LoadOrders();
                    MessageBox.Show("Data berhasil dihapus.");
                }
                else
                {
                    MessageBox.Show("Gagal hapus data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void btnorder_Click(object sender, EventArgs e)
        {
            OpenOrderForm();
        }

        private void order_Load(object sender, EventArgs e)
        {

        }

        private void order_Load_1(object sender, EventArgs e)
        {

        }
    }
}
