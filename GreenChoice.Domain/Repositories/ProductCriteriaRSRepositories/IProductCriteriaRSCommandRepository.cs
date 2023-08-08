using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;

namespace GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;

public interface IProductCriteriaRSCommandRepository
{
    Task AddAsync(ProductCriteriaRS model);
    Task UpdateAsync(ProductCriteriaRS model);
    Task RemoveByIdAsync(int id);
}
