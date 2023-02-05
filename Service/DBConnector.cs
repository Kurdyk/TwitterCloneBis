using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;
using WebTest.Models;

namespace WebTest.Service {
    public class DbConnector {
        
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=WebTest;User=louis;Password=";

        private static MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }
        
        /**
         * Return the list of all user as a enumeration of User objects 
         */
        public IEnumerable<User> GetUsers() {

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
                conn.Close();
            }

            return list;
        }

        /**
         * Get the password linked to the given email to test it
         */
        public string GetPassword(string email) {
            using (MySqlConnection connection = GetConnection()) {
                connection.Open();
                var cmd = new MySqlCommand("SELECT password FROM User WHERE email='" + email +"';", 
                    connection);
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetString("password");
                    }
                }
                connection.Close();
            }
            throw new NullReferenceException();
        }
        
        /**
         * Get the username of an user from its mail
         */
        public string GetUsername(string email) {
            using (MySqlConnection connection = GetConnection()) {
                connection.Open();
                var cmd = new MySqlCommand("SELECT username FROM User WHERE email='" + email +"';", 
                    connection);
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetString("username");
                    }
                }
                connection.Close();
            }
            throw new NullReferenceException();
        }

        public void AddUser(User user) {
            using (MySqlConnection connection = GetConnection()) {
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO User(email, password, username) VALUES ('" 
                                           + user.Email + "', '" 
                                           + user.Password + "', '"
                                           + user.Username + "');", connection);
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 0) {
                    throw new Exception("New user error");
                }
            }
        }
    }
}