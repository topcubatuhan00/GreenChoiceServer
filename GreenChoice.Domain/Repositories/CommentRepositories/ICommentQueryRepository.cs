using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.CommentRepositories;

public interface ICommentQueryRepository
{
    PaginationHelper<Comment> GetAll(PaginationRequest request);
    Task<Comment> GetById(int Id);
}
