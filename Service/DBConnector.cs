using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;
using WebTest.Models;

namespace WebTest.Service {
    public class DbConnector {
        
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=WebTest;User=louis;Password=";

        private static MySqlConnection GetConnection() {
            return new MySqlConnection(ConnectionString);
        }
        
        /// USER RELATED
        
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
            using var connection = GetConnection();
            connection.Open();
            var cmd = new MySqlCommand("SELECT username FROM User WHERE email='" + email +"';", 
                connection);
            using (MySqlDataReader reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    return reader.GetString("username");
                }
            }
            connection.Close();
            throw new NullReferenceException();
        }
        
        /**
         * Add an user to the database
         */
        public void AddUser(User user) {
            using var connection = GetConnection();
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

        /**
         * Validate the presence of a username in the database
         */
        public bool ValidateUsername(string username) {
            using var connection = GetConnection();
            connection.Open();
            var query = new MySqlCommand("SELECT * FROM User WHERE username='" + username + "';", connection);
            using var reader = query.ExecuteReader();
            var result = reader.HasRows;
            connection.Close();
            return result;
        }

        public int GetUserIdFromUsername(string username) {
            using var connection = GetConnection();
            connection.Open();
            var query = new MySqlCommand("SELECT id FROM User WHERE username='" + username + "';", connection);
            using var reader = query.ExecuteReader();
            int result;
            if (reader.NextResult()) {
                result = reader.GetInt32("id");
            }
            else {
                connection.Close();
                throw new Exception("No such user");
            }
            connection.Close();
            return result;
        }
        
        /// TWEET RELATED

        /**
         * Add a tweet to the database
         */
        public void AddTweet(Tweet toAdd) {
            throw new NotImplementedException();
        }
        
        /**
         * Get new tweets from person you follow
         */
        public IList<Tweet> GetTweetsOfFollowed(DateTime lastConnexion, int size) {
            throw new NotImplementedException();
        }
        
        /**
         * Get some new filler tweets if possible
         */
        public IList<Tweet> GetFillerTweets(DateTime lastConnexion, int size) {
            throw new NotImplementedException();
        }
        
        /**
         * Get the tweets of a certain user
         */
        public IList<Tweet> GetUserTweets(User user) {
            IList<Tweet> result = new List<Tweet>();
            using var connection = GetConnection();
            connection.Open();
            var query = new MySqlCommand("SELECT * FROM Tweet WHERE author_id=" + user.Id + ";");
            var reader = query.ExecuteReader();
            while (reader.NextResult()) {
                result.Add(new Tweet(user, reader.GetString("content")));
            }
            return result;
        }

        /// FOLLOW RELATED

        /**
         * Get recursively the followed people and the people they follow
         */
        public IEnumerable<User> GetFollowedRecursive(User baseUser, int maxDepth) {
            throw new NotImplementedException();
        } 
        
    }
}