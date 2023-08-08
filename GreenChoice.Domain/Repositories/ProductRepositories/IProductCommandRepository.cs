using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.ProductModels;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductCommandRepository
{
    Task AddAsync(Product model);
    Task UpdateAsync(Product model);
    Task RemoveByIdAsync(int id);
}
