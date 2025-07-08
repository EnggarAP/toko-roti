using MySql.Data.MySqlClient;

namespace tokoharu.Models
{
    public class DBConnection
    {
        public MySqlConnection GetConnection()
        {
            string connStr = "server=localhost;database=tokoharu;user=root;password=";
            return new MySqlConnection(connStr);
        }
    }
}