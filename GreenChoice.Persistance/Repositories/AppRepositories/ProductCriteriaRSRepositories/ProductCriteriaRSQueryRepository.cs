using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;

public class ProductCriteriaRSQueryRepository : IProductCriteriaRSQueryRepository
{
    public PaginationHelper<ProductCriteriaRS> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProductCriteriaRS> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
