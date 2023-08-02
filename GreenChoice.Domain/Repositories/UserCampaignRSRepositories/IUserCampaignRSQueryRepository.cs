using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.UserCampaignRSRepositories;

public interface IUserCampaignRSQueryRepository
{
    PaginationHelper<UserCampaignRS> GetAll(PaginationRequest request);
    Task<UserCampaignRS> GetById(int Id);
}
