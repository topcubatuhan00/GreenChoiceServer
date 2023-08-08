using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.StoreModels;

namespace GreenChoice.Domain.Repositories.StoreRepositories;

public interface IStoreCommandRepository
{
    Task AddAsync(Store model);
    Task UpdateAsync(Store model);
    Task RemoveByIdAsync(int id);
}
