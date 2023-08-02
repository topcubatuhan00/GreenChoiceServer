using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.CategoryRepositories;

public interface ICategoryQueryRepository
{
    PaginationHelper<Category> GetAll(PaginationRequest request);
    Task<Category> GetById(int Id);
}
