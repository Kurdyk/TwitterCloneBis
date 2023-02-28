using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace WebTest.Models {

    public class User : IModel {
        public int Id {get;}
        
        internal string Email {get;}
        public string Username {get;}
        internal string Password { get; }

        internal User(int id, string email, string username, string password) {
            this.Id = id;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        internal User(string email, string username, string password) {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        internal User(string username) {
            this.Username = username;
            this.Id = new Service.DbConnector().GetUserIdFromUsername(username);
        }

        public override string ToString() {
            return JsonSerializer.Serialize<User>(this);
        }
        
        public string Serialize() {
            return JsonSerializer.Serialize<User>(this);
        }


    }

}