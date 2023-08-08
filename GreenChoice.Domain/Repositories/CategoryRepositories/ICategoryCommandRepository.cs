using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.CategoryRepositories;

public interface ICategoryCommandRepository
{
    Task AddAsync(Category model);
    Task UpdateAsync(Category model);
    Task RemoveByIdAsync(int id);
}
