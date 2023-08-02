using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public class CommentService : ICommentService
{
    public Task Create(CreateCommentModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<Comment>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<Comment>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateCommentModel model)
    {
        throw new NotImplementedException();
    }
}
