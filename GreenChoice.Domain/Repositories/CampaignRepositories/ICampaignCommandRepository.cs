using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.CampaignModels;

namespace GreenChoice.Domain.Repositories.CampaignRepositories;

public interface ICampaignCommandRepository
{
    Task AddAsync(Campaign model);
    Task UpdateAsync(Campaign model);
    Task RemoveByIdAsync(int id);
}
