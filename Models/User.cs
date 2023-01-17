using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace WebTest.Models {

    public class User {
        //[Key]
        private int id {get;}
        //[Required]
        private string email {get;}
        //[Required]
        public string username {get; private set;}
        //[Required]
        private string password;


        internal User(int id, string email, string username, string password) {
            this.id = id;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<User>(this);
        }

    }

}