namespace GreenChoice.Domain.Models.StoreModels;

public class CreateStoreModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOnlineAvailable { get; set; }
    public string CreatorName { get; set; }
    public float AverageScore { get; set; }
}
