using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.UserCampaignRSRepositories;

public interface IUserCampaignRSCommandRepository
{
    Task AddAsync(UserCampaignRS model);
    Task UpdateAsync(UserCampaignRS model);
    Task RemoveByIdAsync(int id);
}
