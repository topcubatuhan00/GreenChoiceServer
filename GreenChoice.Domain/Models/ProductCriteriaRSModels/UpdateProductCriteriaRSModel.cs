namespace GreenChoice.Domain.Models.ProductCriteriaRSModels;

public class UpdateProductCriteriaRSModel
{
    public int Id{ get; set; }
    public int ProductId { get; set; }
    public int SustainabilityCriteriaId { get; set; }
    public float Score { get; set; }
}
