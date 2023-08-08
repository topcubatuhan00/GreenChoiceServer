using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.UserCampaignRSRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.UserCampaignRSRepositories;

public class UserCampaignRSQueryRepository : Repository, IUserCampaignRSQueryRepository
{
    #region Ctor
    public UserCampaignRSQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<UserCampaignRS> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [UserCampaignRS]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [UserCampaignRS] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<UserCampaignRS> rs = new List<UserCampaignRS>();
            while (reader.Read())
            {
                rs.Add(new UserCampaignRS
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CampaignId = Convert.ToInt32(reader["CampaignId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                });
            }
            return new PaginationHelper<UserCampaignRS>(totalCount, request.PageSize, request.PageNumber, rs);
        }
    }

    public async Task<UserCampaignRS> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [UserCampaignRS] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new UserCampaignRS
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CampaignId = Convert.ToInt32(reader["CampaignId"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                };
            }
            else
                return null;
        }
    }
}
