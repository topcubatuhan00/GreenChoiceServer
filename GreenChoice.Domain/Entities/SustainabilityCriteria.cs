using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class SustainabilityCriteria : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}
