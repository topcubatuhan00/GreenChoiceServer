using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.CampaignRepositories;

public interface ICampaignQueryRepository
{
    PaginationHelper<Campaign> GetAll(PaginationRequest request);
    Task<Campaign> GetById(int Id);
    Task<Campaign> GetByName(string Name);
}
