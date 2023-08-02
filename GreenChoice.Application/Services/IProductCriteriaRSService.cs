using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;

namespace GreenChoice.Application.Services;

public interface IProductCriteriaRSService
{
    Task<ResponseDto<ProductCriteriaRS>> GetById(int id);
    Task<ResponseDto<PaginationHelper<ProductCriteriaRS>>> GetAll(PaginationRequest request);
    Task Create(CreateProductCriteriaRSModel model);
    Task Update(UpdateProductCriteriaRSModel model);
    Task Remove(int id);
}
