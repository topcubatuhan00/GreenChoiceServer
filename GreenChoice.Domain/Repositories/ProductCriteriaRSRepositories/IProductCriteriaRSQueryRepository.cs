using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;

public interface IProductCriteriaRSQueryRepository
{
    PaginationHelper<ProductCriteriaRS> GetAll(PaginationRequest request);
    Task<ProductCriteriaRS> GetById(int Id);
}
