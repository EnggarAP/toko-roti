using MySql.Data.MySqlClient;

namespace tokoharu
{
    internal class dbconnection
    {
        public MySqlConnection GetConnection()
        {
            string connStr = "server=localhost;database=tokoharu;user=root;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
