using AutoMapper;
using GreenChoice.Domain.Dtos;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class CommentService : ICommentService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateCommentModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<Comment>(model);
            await context.Repositories.commentCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<IList<CommentReponseDto>> GetAll(int userId, int productId)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetAll(userId, productId);

            return result;
        }
    }

    public async Task<ResponseDto<CommentReponseDto>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetById(id);
            return ResponseDto<CommentReponseDto>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<IList<CommentReponseDto>>> GetForHome(int commentCount)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetForHome(commentCount);
            return ResponseDto<IList<CommentReponseDto>>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkComment = await context.Repositories.commentQueryRepository.GetById(id);
            if (checkComment == null) throw new Exception("Not Found");

            await context.Repositories.commentCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateCommentModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkComment = await context.Repositories.commentQueryRepository.GetById(model.Id);
            if (checkComment == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Comment>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.commentCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }

    public async Task UpdateLike(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var commentModel = await context.Repositories.commentQueryRepository.GetById(id);
            var comment = _mapper.Map<Comment>(commentModel);
            comment.CommentScore += 1;

            await context.Repositories.commentCommandRepository.UpdateAsync(comment);
        }
    }
}
