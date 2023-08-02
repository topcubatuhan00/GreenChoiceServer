namespace GreenChoice.Domain.Models.ProductCriteriaRSModels;

public class CreateProductCriteriaRSModel
{
    public int ProductId { get; set; }
    public int SustainabilityCriteriaId { get; set; }
    public float Score { get; set; }
    public string CreatorName { get; set; }
}
