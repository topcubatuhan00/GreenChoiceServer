namespace GreenChoice.Domain.Repositories.FavoritesRepositories;

public interface IFavoriteCommandRepository
{
    Task CreateFavorites(int userId, int productId);
    Task RemoveFavorites(int id);
}
