using MySql.Data.MySqlClient;
using System;
using System.Data;
using tokoharu.Models;

namespace TokoHaru.Repositories
{
    public class UserRepository
    {
        private readonly DBConnection _dbConnection;

        public UserRepository(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool Authenticate(string username, string password)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public DataTable GetAllUsers()
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT userid, username FROM user";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception)
                {
                    return new DataTable();
                }
            }
        }

        public bool UpdateUser(int userId, string username)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE user SET username = @username WHERE userid = @userid";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.Parameters.AddWithValue("@username", username);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM user WHERE userid = @userid";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UsernameExists(string username)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Create(string username, string password)
        {
            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO user (username, password) VALUES (@username, @password)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}