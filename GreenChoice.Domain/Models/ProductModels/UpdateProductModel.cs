namespace GreenChoice.Domain.Models.ProductModels;

public class UpdateProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string BrandName { get; set; }
    public string Barcode { get; set; }
    public string PackageInformation { get; set; }
    public string ProductionProcessInformation { get; set; }
    public string SustainabilityScore { get; set; }
    public string AverageScore { get; set; }
    public string Price { get; set; }
    public int StoreId { get; set; }
}
