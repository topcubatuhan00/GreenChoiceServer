using GreenChoice.Domain.Dtos;
using GreenChoice.Domain.Repositories.CommentRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentQueryRepository : Repository, ICommentQueryRepository
{
    #region Ctor
    public CommentQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task<IList<CommentReponseDto>> GetAll(int userId, int productId)
    {
        var command = CreateCommand($@"
            SELECT C.*, U.UserName as UserName,U.Photo as PhotoName, P.Name as ProductName
            FROM [Comment] C
            JOIN [User] U ON C.UserId = U.Id
            JOIN [Product] P ON C.ProductId = P.Id
            where U.Id = @uid and P.Id=@pid;
        ");
        command.Parameters.AddWithValue("@uid", userId);
        command.Parameters.AddWithValue("@pid", productId);

        using (var reader = command.ExecuteReader())
        {
            List<CommentReponseDto> comments = new List<CommentReponseDto>();
            while (reader.Read())
            {
                comments.Add(new CommentReponseDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Text = reader["Text"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CommentScore = Convert.ToInt32(reader["CommentScore"]),
                    UserPhotoName = reader["PhotoName"].ToString(),
                });
            }
            return comments;
        }
    }

    public async Task<CommentReponseDto> GetById(int Id)
    {
        var command = CreateCommand($"SELECT c.*, p.Name AS ProductName, u.UserName " +
                      $"FROM [Comment] c " +
                      $"INNER JOIN [Product] p ON c.ProductId = p.Id " +
                      $"INNER JOIN [User] u ON c.UserId = u.Id " +
                      $"WHERE c.Id = @id ORDER BY CommentScore DESC ");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new CommentReponseDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Text = reader["Text"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CommentScore = float.Parse(reader["CommentScore"].ToString())
                };
            }
            else
                return null;
        }
    }

    public async Task<IList<CommentReponseDto>> GetForHome(int commentCount)
    {
        var command = CreateCommand($"SELECT TOP {commentCount} c.*, p.Name AS ProductName, u.UserName " +
                      $"FROM [Comment] c " +
                      $"INNER JOIN [Product] p ON c.ProductId = p.Id " +
                      $"INNER JOIN [User] u ON c.UserId = u.Id " +
                      $"ORDER BY CommentScore DESC;");

        using (var reader = command.ExecuteReader())
        {
            List<CommentReponseDto> comments = new List<CommentReponseDto>();
            while (reader.Read())
            {
                comments.Add(new CommentReponseDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Text = reader["Text"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CommentScore = Convert.ToInt32(reader["CommentScore"])
                });
            }
            return comments;
        }
    }
}
