using Microsoft.AspNetCore.Http;

namespace GreenChoice.Domain.Models.AuthModels;

public partial class UserRegisterModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
    public IFormFile Image { get; set; }
    public string Role { get; set; }
};
