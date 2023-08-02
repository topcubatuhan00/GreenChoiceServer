using GreenChoice.Domain.Models.UserCampaignRSModels;

namespace GreenChoice.Domain.Repositories.UserCampaignRSRepositories;

public interface IUserCampaignRSCommandRepository
{
    Task AddAsync(CreateUserCampaignRSModel model);
    Task UpdateAsync(UpdateUserCampaignRSModel model);
    Task RemoveByIdAsync(int id);
}
