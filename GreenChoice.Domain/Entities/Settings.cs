using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Settings : EntityBase
{
    public string Name { get; set; }
    public string Value { get; set; }
}
