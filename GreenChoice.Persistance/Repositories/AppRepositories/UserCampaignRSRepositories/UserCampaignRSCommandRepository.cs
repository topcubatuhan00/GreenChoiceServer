using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.UserCampaignRSRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.UserCampaignRSRepositories;

public class UserCampaignRSCommandRepository : Repository, IUserCampaignRSCommandRepository
{
    #region Ctor
    public UserCampaignRSCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(UserCampaignRS model)
    {
        var query = "INSERT INTO [UserCampaignRS]" +
            "(UserId, CampaignId, CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "(@userId, @campaignId, @createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@userId", model.UserId);
        command.Parameters.AddWithValue("@campaignId", model.CampaignId);
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
        var command = CreateCommand("delete from [UserCampaignRS] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(UserCampaignRS model)
    {
        var query = "update [UserCampaignRS] set UserId=@userId, CampaignId=@campaignId where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@userId", model.UserId);
        command.Parameters.AddWithValue("@campaignId", model.CampaignId);

        await command.ExecuteNonQueryAsync();
    }
}
