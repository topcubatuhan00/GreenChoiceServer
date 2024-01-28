namespace GreenChoice.Domain.Models.AuthModels;

public class TokenResponseModel
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}
