using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductCommandRepository
{
    Task AddAsync(Product model);
    Task UpdateScoreAsync(string newScore, int id);
    Task UpdateAsync(Product product);
    Task RemoveByIdAsync(int id);
}
