using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.ProductRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductRepositories;

public class ProductQueryRepository : IProductQueryRepository
{
    public PaginationHelper<Product> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
