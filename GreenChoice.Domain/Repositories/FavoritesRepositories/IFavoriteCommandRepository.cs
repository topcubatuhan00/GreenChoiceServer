namespace GreenChoice.Domain.Repositories.FavoritesRepositories;

public interface IFavoriteCommandRepository
{
    Task<int> CreateFavorites(int userId, int productId);
    Task RemoveFavorites(int id);
}
