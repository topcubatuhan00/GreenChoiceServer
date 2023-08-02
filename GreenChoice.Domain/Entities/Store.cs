using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Store : EntityBase
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsOnlineAvailable { get; set; }
}
