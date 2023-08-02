using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.UserCampaignRSRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.UserCampaignRSRepositories;

public class UserCampaignRSQueryRepository : IUserCampaignRSQueryRepository
{
    public PaginationHelper<UserCampaignRS> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UserCampaignRS> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
