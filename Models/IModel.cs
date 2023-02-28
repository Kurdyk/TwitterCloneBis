namespace WebTest.Models; 

public interface IModel {
    
    // All models should have id
    public int Id { get; }    
    
    // Should be able to serialize models
    public string Serialize();
}