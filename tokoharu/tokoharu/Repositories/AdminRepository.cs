using MySql.Data.MySqlClient;
using System;
using tokoharu.Models;

namespace TokoHaru.Repositories
{
    public class AdminRepository
    {
        private readonly DBConnection _dbConnection;

        public AdminRepository(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool Authenticate(string username, string password)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM admin WHERE username = @username AND password = @password";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public string GetAdminName()
        {
            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT nama FROM admin LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["nama"].ToString();
                    }
                }
                return string.Empty;
            }
        }
    }
}