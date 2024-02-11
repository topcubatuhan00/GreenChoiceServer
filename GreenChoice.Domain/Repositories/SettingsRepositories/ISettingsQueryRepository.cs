using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.SettingsRepositories;

public interface ISettingsQueryRepository
{
    PaginationHelper<Settings> GetAll(PaginationRequest request);
    Task<IList<Settings>> GetAllByUserName(string userName);
    Task<Settings> GetById(int Id);
    Task<Settings> GetByName(string Name);
}
