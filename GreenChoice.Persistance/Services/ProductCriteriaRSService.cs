using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;

namespace GreenChoice.Application.Services;

public class ProductCriteriaRSService : IProductCriteriaRSService
{
    public Task Create(CreateProductCriteriaRSModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<ProductCriteriaRS>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<ProductCriteriaRS>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateProductCriteriaRSModel model)
    {
        throw new NotImplementedException();
    }
}
