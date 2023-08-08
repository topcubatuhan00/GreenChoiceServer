using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Repositories.CommentRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentCommandRepository : Repository, ICommentCommandRepository
{
    #region Ctor
    public CommentCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(CreateCommentModel model)
    {
        var query = "INSERT INTO [Comment]" +
            "(ProductId, UserId, Text, CommentScore ,CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "@productId, @userId, @text, @commentScore ,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@productId", model.ProductId);
        command.Parameters.AddWithValue("@userId", model.UserId);
        command.Parameters.AddWithValue("@text", model.Text);
        command.Parameters.AddWithValue("@commentScore", 0);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", model.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var command = CreateCommand("delete from [Comment] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(UpdateCommentModel model)
    {
        var query = "update [Comment] set ProductId=@productId, UserId=@userId, Text=@text, CommentScore=@score where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@productId", model.ProductId);
        command.Parameters.AddWithValue("@userId", model.UserId);
        command.Parameters.AddWithValue("@text", model.Text);
        command.Parameters.AddWithValue("@score", model.CommentScore);

        await command.ExecuteNonQueryAsync();
    }
}
