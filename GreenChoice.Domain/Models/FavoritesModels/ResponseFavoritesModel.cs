namespace GreenChoice.Domain.Models.FavoritesModels;

public class ResponseFavoritesModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string ProductName { get; set; }
}
