using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.CampaignRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CampaignRepositories;

public class CampaignCommandRepository :Repository, ICampaignCommandRepository
{
    public CampaignCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }

    public async Task AddAsync(Campaign model)
    {
        var query = "INSERT INTO [Campaign]" +
            "(Name, Description, BeginDate, EndDate, CreatedDate, CreatorName, DeletedDate, DeleterName, UpdatedDate, UpdaterName) VALUES (" +
            "@name,@description,@beginDate,@endDate,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);
        command.Parameters.AddWithValue("@beginDate", model.BeginDate);
        command.Parameters.AddWithValue("@endDate", model.EndDate);
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
        var command = CreateCommand("delete from [Campaign] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Campaign model)
    {
        var query = "update [Campaign] set Name=@name, Description=@description where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);
        command.Parameters.AddWithValue("@id", model.Id);

        await command.ExecuteNonQueryAsync();
    }
}
