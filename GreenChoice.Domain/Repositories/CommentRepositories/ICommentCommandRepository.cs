using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.CommentModels;

namespace GreenChoice.Domain.Repositories.CommentRepositories;

public interface ICommentCommandRepository
{
    Task AddAsync(Comment model);
    Task UpdateAsync(Comment model);
    Task RemoveByIdAsync(int id);
}
