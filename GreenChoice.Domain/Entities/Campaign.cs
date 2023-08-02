using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Campaign : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
}
