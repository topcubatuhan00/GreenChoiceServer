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
        throw new NotImplementedException();
    }

    public Task<UserCampaignRS> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
