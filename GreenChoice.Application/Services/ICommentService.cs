using GreenChoice.Domain.Dtos;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Models.CommentModels;

namespace GreenChoice.Application.Services;

public interface ICommentService
{
    Task<ResponseDto<CommentReponseDto>> GetById(int id);
    Task<IList<CommentReponseDto>> GetAll(int userId, int productId);
    Task Create(CreateCommentModel model);
    Task Update(UpdateCommentModel model);
    Task Remove(int id);
    Task<ResponseDto<IList<CommentReponseDto>>> GetForHome(int commentCount);
    Task UpdateLike(int id);
    
}
