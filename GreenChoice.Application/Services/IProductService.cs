using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;

namespace GreenChoice.Application.Services;

public interface IProductService
{
    Task<ResponseDto<GetByIdProductResponse>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Product>>> GetAll(PaginationRequest request);
    Task Create(CreateProductModel model);
    Task Update(UpdateProductModel model);
    Task Remove(int id);
    Task<ResponseDto<IList<HomeResponseProductModel>>> GetForHome(int productCount);
    Task UpdateScore(UpdateSustainabilityScoreModel model);
}
