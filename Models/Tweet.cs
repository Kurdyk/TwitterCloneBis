using System.Text.Json;

namespace WebTest.Models {

    public class Tweet : IModel {
        public int Id {get;}
        public User Author {get; }
        public string Content {get; }

        public Tweet(int id, User author, string content) {
            this.Id = id;
            this.Author = author;
            this.Content = content;
        }

        public Tweet(User author, string content) {
            this.Author = author;
            this.Content = content;
        }
        
        public string Serialize() {
            return JsonSerializer.Serialize<Tweet>(this);
        }
    }

}