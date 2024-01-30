using GreenChoice.Domain.Dtos;

namespace GreenChoice.Domain.Repositories.CommentRepositories;

public interface ICommentQueryRepository
{
    Task<IList<CommentReponseDto>> GetAll(int userId, int productId);
    Task<CommentReponseDto> GetById(int Id);
    Task<IList<CommentReponseDto>> GetForHome(int commentCount);
}
