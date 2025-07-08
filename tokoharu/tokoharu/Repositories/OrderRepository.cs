using MySql.Data.MySqlClient;
using System.Data;
using tokoharu.Models;

namespace TokoHaru.Repositories
{
    public class OrderRepository
    {
        private readonly DBConnection _dbConnection;

        public OrderRepository(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DataTable GetAllOrders()
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT idorder, nama, menu, harga FROM `order`";
                var adapter = new MySqlDataAdapter(query, conn);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddOrder(string customerName, string menu, string price)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO `order` (nama, menu, harga) VALUES (@nama, @menu, @harga)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", customerName);
                    cmd.Parameters.AddWithValue("@menu", menu);
                    cmd.Parameters.AddWithValue("@harga", price);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateOrder(int orderId, string customerName, string menu, string price)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE `order` SET nama = @nama, menu = @menu, harga = @harga WHERE idorder = @idorder";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idorder", orderId);
                    cmd.Parameters.AddWithValue("@nama", customerName);
                    cmd.Parameters.AddWithValue("@menu", menu);
                    cmd.Parameters.AddWithValue("@harga", price);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteOrder(int orderId)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM `order` WHERE idorder = @idorder";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idorder", orderId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}