using GreenChoice.Domain.Models.FavoritesModels;

namespace GreenChoice.Application.Services;

public interface IFavoritesService
{
    Task<IList<ResponseFavoritesModel>> GetAllFavorites(int userId);
    Task<ResponseFavoritesModel> GetFavorites(int userId, int productId);
    Task<int> CreateFavorites(int userId, int productId);
    Task RemoveFavorites(int id);
}
