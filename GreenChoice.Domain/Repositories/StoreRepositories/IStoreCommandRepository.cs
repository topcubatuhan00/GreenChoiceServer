using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.StoreRepositories;

public interface IStoreCommandRepository
{
    Task AddAsync(Store model);
    Task UpdateAsync(Store model);
    Task RemoveByIdAsync(int id);
}
