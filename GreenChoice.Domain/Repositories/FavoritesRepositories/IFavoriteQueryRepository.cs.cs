using GreenChoice.Domain.Models.FavoritesModels;

namespace GreenChoice.Domain.Repositories.FavoritesRepositories;

public interface IFavoriteQueryRepository
{
    Task<IList<ResponseFavoritesModel>> GetAllFavorites(int userId);
    Task<ResponseFavoritesModel> GetFavorites(int userId, int productId);
}
