using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SustainabilityCriteriaRepositories;

public class SustainabilityCriteriaCommandRepository : Repository, ISustainabilityCriteriaCommandRepository
{
    #region Ctor
    public SustainabilityCriteriaCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(SustainabilityCriteria model)
    {
        var query = "INSERT INTO [SustainabilityCriteria]" +
            "(Name, Description, CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "(@name, @description,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);
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
        var command = CreateCommand("delete from [SustainabilityCriteria] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(SustainabilityCriteria model)
    {
        var query = "update [SustainabilityCriteria] set Name=@name, Description=@description where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);

        await command.ExecuteNonQueryAsync();
    }
}
