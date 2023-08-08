using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.UserCampaignRSModels;

namespace GreenChoice.Domain.Repositories.UserCampaignRSRepositories;

public interface IUserCampaignRSCommandRepository
{
    Task AddAsync(UserCampaignRS model);
    Task UpdateAsync(UserCampaignRS model);
    Task RemoveByIdAsync(int id);
}
