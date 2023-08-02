using GreenChoice.Domain.Models.ProductCriteriaRSModels;

namespace GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;

public interface IProductCriteriaRSCommandRepository
{
    Task AddAsync(CreateProductCriteriaRSModel model);
    Task UpdateAsync(UpdateProductCriteriaRSModel model);
    Task RemoveByIdAsync(int id);
}
