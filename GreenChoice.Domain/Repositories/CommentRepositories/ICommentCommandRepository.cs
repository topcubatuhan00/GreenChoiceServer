using GreenChoice.Domain.Models.CommentModels;

namespace GreenChoice.Domain.Repositories.CommentRepositories;

public interface ICommentCommandRepository
{
    Task AddAsync(CreateCommentModel model);
    Task UpdateAsync(UpdateCommentModel model);
    Task RemoveByIdAsync(int id);
}
