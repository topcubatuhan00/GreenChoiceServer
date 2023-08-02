using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.CommentRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentQueryRepository : ICommentQueryRepository
{
    public PaginationHelper<Comment> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
