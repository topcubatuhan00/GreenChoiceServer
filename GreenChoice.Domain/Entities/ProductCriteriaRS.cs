using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class ProductCriteriaRS : EntityBase
{
    public int ProductId{ get; set; }
    public int SustainabilityCriteriaId{ get; set; }
    public float Score{ get; set; }
}
