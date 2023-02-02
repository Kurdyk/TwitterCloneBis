using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace WebTest.Models {

    public class User {
        //[Key]
        public int Id {get;}
        //[Required]
        public string Email {get;}
        //[Required]
        public string Username {get;}
        //[Required]
        public string Password {get;}


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

        public override string ToString()
        {
            return JsonSerializer.Serialize<User>(this);
        }

    }

}