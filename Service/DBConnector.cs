using MySql.Data.MySqlClient;
using WebTest.Models;

namespace WebTest.Connector {
    public class DBConnector {

        private string connectionString = "Data Source=localhost;Initial Catalog=WebTest;User=louis;Password=";

        private MySqlConnection GetConnection() {
            return new MySqlConnection(connectionString);
        }

        public List<User> getUsers() {

            var list = new List<User>();

            using (MySqlConnection conn = GetConnection()) {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM User;", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    list.Add(new User(
                        reader.GetInt32("id"),
                        reader.GetString("email"),
                        reader.GetString("username"),
                        reader.GetString("password")
                        ));
                    }
                }
            }

            return list;
        }
    }
}