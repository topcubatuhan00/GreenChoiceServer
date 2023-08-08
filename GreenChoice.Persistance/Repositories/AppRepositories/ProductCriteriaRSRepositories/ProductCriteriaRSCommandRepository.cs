using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;

public class ProductCriteriaRSCommandRepository : Repository, IProductCriteriaRSCommandRepository
{
    #region Ctor
    public ProductCriteriaRSCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(ProductCriteriaRS model)
    {
        var query = "INSERT INTO [ProductCriteriaRS]" +
            "(ProductId,SustainabilityCriteriaId, Score, CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "(@productId,@sustainabilityCriteriaId,@score,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@productId", model.ProductId);
        command.Parameters.AddWithValue("@sustainabilityCriteriaId", model.SustainabilityCriteriaId);
        command.Parameters.AddWithValue("@score", model.Score);
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
        var command = CreateCommand("delete from [ProductCriteriaRS] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(ProductCriteriaRS model)
    {
        var query = "update [ProductCriteriaRS] set ProductId=@productId, SustainabilityCriteriaId=@sustainabilityCriteriaId, Score=@score where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@productId", model.ProductId);
        command.Parameters.AddWithValue("@sustainabilityCriteriaId", model.SustainabilityCriteriaId);
        command.Parameters.AddWithValue("@score", model.Score);

        await command.ExecuteNonQueryAsync();
    }
}
