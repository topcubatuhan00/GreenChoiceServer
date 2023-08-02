using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.CategoryRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CategoryRepositories;

public class CategoryQueryRepository : ICategoryQueryRepository
{
    public PaginationHelper<Category> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
