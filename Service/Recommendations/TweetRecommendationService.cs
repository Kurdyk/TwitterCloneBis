using WebTest.Models;

namespace WebTest.Service.Recommendations; 

public class TweetRecommendationService : IRecommendationService {
    
    // Will return an IEnumeration of tweets
    public IEnumerable<IModel> GetModelsEnumeration(DateTime lastConnexion, int size) {
        throw new NotImplementedException();
    }

    // get the tweets made by people you follow
    private IEnumerable<Tweet> GetTweetsOfFollowed(DateTime lastConnexion, int size) {
        throw new NotImplementedException();
    }

    // get some tweets to fill up the feed
    private IEnumerable<Tweet> GetFillerTweets(DateTime lastConnexion, int size) {
        throw new NotImplementedException();
    }

}