namespace WebTest.Models {

    public class Tweet {
        //[Key]
        private int id {get; set;}
        //[Required]
        private int authorId {get; set;}
        //[Required]
        private string content {get; set;}

        public Tweet(int id, int authorId, string content) {
            this.id = id;
            this.authorId = authorId;
            this.content = content;
        } 
    }

}