using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
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
    public PaginationHelper<Comment> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Comment]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Comment] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Comment> comments = new List<Comment>();
            while (reader.Read())
            {
                comments.Add(new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Text = reader["Text"].ToString(),
                });
            }
            return new PaginationHelper<Comment>(totalCount, request.PageSize, request.PageNumber, comments);
        }
    }

    public async Task<Comment> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Comment] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Text = reader["Text"].ToString(),
                };
            }
            else
                return null;
        }
    }
}
