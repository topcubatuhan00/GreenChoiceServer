using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductCommandRepository
{
    Task AddAsync(Product model);
    Task UpdateAsync(Product model);
    Task RemoveByIdAsync(int id);
}
