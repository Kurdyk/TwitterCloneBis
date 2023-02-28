using System.Text.Json;

namespace WebTest.Models; 

public class Follow : IModel {
    
    public int Id { get; }
    public int FollowerId { get;  }
    public int FollowedId { get;  }

    public Follow(int id, int followerId, int followedId) {
        Id = id;
        FollowerId = followerId;
        FollowedId = followedId;
    }

    public string Serialize() {
        return JsonSerializer.Serialize<Follow>(this);
    }
}