using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Photo { get; set; }
    public string Role { get; set; }
}
