using GreenChoice.Domain.Models.UserCampaignRSModels;
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
    public async Task AddAsync(CreateUserCampaignRSModel model)
    {
        var query = "INSERT INTO [Campaign]" +
            "(CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", model.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        await command.ExecuteNonQueryAsync();
    }

    public Task RemoveByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateUserCampaignRSModel model)
    {
        throw new NotImplementedException();
    }
}
