using GreenChoice.Domain.Repositories.FavoritesRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.FavoritesRepositories;

public class FavoriteCommandRepository : Repository, IFavoriteCommandRepository
{
    #region Ctor
    public FavoriteCommandRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    public async Task CreateFavorites(int userId, int productId)
    {
        var query = "INSERT INTO [Favorites]" +
            "(ProductId, UserId) VALUES" +
            "(@productId, @userId);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@productId", productId);
        command.Parameters.AddWithValue("@userId", userId);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveFavorites(int id)
    {
        var command = CreateCommand("delete from [Favorites] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }
}
