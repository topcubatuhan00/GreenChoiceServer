using GreenChoice.Domain.Models.StoreModels;

namespace GreenChoice.Domain.Repositories.StoreRepositories;

public interface IStoreCommandRepository
{
    Task AddAsync(CreateStoreModel model);
    Task UpdateAsync(UpdateStoreModel model);
    Task RemoveByIdAsync(int id);
}
