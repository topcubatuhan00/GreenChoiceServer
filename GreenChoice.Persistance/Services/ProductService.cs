using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;

namespace GreenChoice.Application.Services;

public class ProductService : IProductService
{
    public Task Create(CreateProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<Product>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<Product>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateProductModel model)
    {
        throw new NotImplementedException();
    }
}
