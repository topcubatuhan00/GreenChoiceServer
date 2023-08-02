namespace GreenChoice.Domain.Models.StoreModels;

public class CreateStoreModel
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOnlineAvailable { get; set; }
    public string CreatorName { get; set; }
}
