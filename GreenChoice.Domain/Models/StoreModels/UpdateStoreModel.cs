namespace GreenChoice.Domain.Models.StoreModels;

public class UpdateStoreModel
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOnlineAvailable { get; set; }
}
