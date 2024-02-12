using GreenChoice.Domain.Models.FavoritesModels;
using GreenChoice.Domain.Repositories.FavoritesRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.FavoritesRepositories;

public class FavoriteQueryRepository : Repository, IFavoriteQueryRepository
{
    #region Ctor
    public FavoriteQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task<IList<ResponseFavoritesModel>> GetAllFavorites(int userId)
    {
        var command = CreateCommand($@"
            SELECT F.*, U.UserName as UserName, P.Name as ProductName
            FROM [Favorites] F
            JOIN [User] U ON F.UserId = U.Id
            JOIN [Product] P ON F.ProductId = P.Id
            where F.UserId = @uid;
        ");
        command.Parameters.AddWithValue("@uid", userId);

        using (var reader = command.ExecuteReader())
        {
            List<ResponseFavoritesModel> favorites = new List<ResponseFavoritesModel>();
            while (reader.Read())
            {
                favorites.Add(new ResponseFavoritesModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    ProductName = reader["ProductName"].ToString(),
                });
            }
            return favorites;
        }
    }

    public async Task<ResponseFavoritesModel> GetFavorites(int userId, int productId)
    {
        var command = CreateCommand($@"
            SELECT F.*, U.UserName as UserName, P.Name as ProductName
            FROM [Favorites] F
            JOIN [User] U ON F.UserId = U.Id
            JOIN [Product] P ON F.ProductId = P.Id
            where F.UserId = @uid and F.ProductId = @pid;
        ");
        command.Parameters.AddWithValue("@uid", userId);
        command.Parameters.AddWithValue("@pid", productId);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new ResponseFavoritesModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    ProductName = reader["ProductName"].ToString(),
                };
            }
            else { return null; }
        }
    }

    public async Task<bool> Check(int userId, int productId)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Favorites] WHERE UserId=@uid AND ProductId=@pid");

        command.Parameters.AddWithValue("@uid", userId);
        command.Parameters.AddWithValue("@pid", productId);

        var count = await command.ExecuteScalarAsync();

        return Convert.ToInt32(count) > 0;
    }
}
