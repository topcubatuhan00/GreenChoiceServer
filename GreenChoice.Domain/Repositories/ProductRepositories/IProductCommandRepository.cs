using GreenChoice.Domain.Models.ProductModels;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductCommandRepository
{
    Task AddAsync(CreateProductModel model);
    Task UpdateAsync(UpdateProductModel model);
    Task RemoveByIdAsync(int id);
}
