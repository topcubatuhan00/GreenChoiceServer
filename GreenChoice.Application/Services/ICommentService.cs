using GreenChoice.Domain.Dtos;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public interface ICommentService
{
    Task<ResponseDto<CommentReponseDto>> GetById(int id);
    Task<ResponseDto<PaginationHelper<CommentReponseDto>>> GetAll(PaginationRequest request);
    Task Create(CreateCommentModel model);
    Task Update(UpdateCommentModel model);
    Task Remove(int id);
    Task<ResponseDto<IList<CommentReponseDto>>> GetForHome(int commentCount);
}
