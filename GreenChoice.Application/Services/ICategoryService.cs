using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CategoryModels;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public interface ICategoryService
{
    Task<ResponseDto<Category>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Category>>> GetAll(PaginationRequest request);
    Task Create(CreateCategoryModel model);
    Task Update(UpdateCategoryModel model);
    Task Remove(int id);
}
