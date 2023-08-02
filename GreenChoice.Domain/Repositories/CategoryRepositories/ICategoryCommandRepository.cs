using GreenChoice.Domain.Models.CategoryModels;

namespace GreenChoice.Domain.Repositories.CategoryRepositories;

public interface ICategoryCommandRepository
{
    Task AddAsync(CreateCategoryModel model);
    Task UpdateAsync(UpdateCategoryModel model);
    Task RemoveByIdAsync(int id);
}
