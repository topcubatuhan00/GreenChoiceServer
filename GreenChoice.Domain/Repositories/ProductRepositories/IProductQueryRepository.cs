using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductQueryRepository
{
    PaginationHelper<Product> GetAll(PaginationRequest request);
    Task<GetByIdProductResponse> GetById(int id);
    Task<IList<GetByStoreIdProductModel>> GetWithStoreId(int storeId);
    Task<Product> GetByName(string Name);
    Task<IList<HomeResponseProductModel>> GetForHome(int productCount);
}
