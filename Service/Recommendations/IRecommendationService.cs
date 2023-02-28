using WebTest.Models;


namespace WebTest.Service.Recommendations; 

public interface IRecommendationService {

    // Get a recommendation list for various model type
    public IEnumerable<IModel> GetModelsEnumeration(DateTime lastConnexion, int size);

}