using GreenChoice.Domain.Dtos;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.CommentRepositories;

public interface ICommentQueryRepository
{
    PaginationHelper<CommentReponseDto> GetAll(PaginationRequest request);
    Task<CommentReponseDto> GetById(int Id);
}
