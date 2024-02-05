namespace GreenChoice.Domain.Models.ProductModels;

public class HomeResponseProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string BrandName { get; set; }
    public string AverageScore { get; set; }
    public string Price { get; set; }
    public int StoreId { get; set; }
}
