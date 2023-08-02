using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CategoryModels;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public class CategoryService : ICategoryService
{
    public Task Create(CreateCategoryModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<Category>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<Category>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateCategoryModel model)
    {
        throw new NotImplementedException();
    }
}
