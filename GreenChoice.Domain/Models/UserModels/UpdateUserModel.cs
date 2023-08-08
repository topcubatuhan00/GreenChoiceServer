namespace GreenChoice.Domain.Models.UserModels;

public class UpdateUserModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Photo { get; set; }
    public string Role { get; set; }
}
