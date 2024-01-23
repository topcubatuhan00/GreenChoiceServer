using Azure.Core;
using GreenChoice.Domain.Dtos;
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
    public PaginationHelper<CommentReponseDto> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Comment]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT c.*, p.Name AS ProductName, u.UserName " +
                      $"FROM [Comment] c " +
                      $"INNER JOIN [Product] p ON c.ProductId = p.Id " +
                      $"INNER JOIN [User] u ON c.UserId = u.Id " +
                      $"ORDER BY c.Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";

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
            return new PaginationHelper<CommentReponseDto>(totalCount, request.PageSize, request.PageNumber, comments);
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
