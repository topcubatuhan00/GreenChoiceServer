using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class UserService : IUserService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateUserModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userQueryRepository.GetByUserName(model.UserName);
            if (check != null) throw new Exception("Already Defined User");

            var entity = _mapper.Map<User>(model);
            await context.Repositories.userCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<User>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.userQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<User>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var users = result.Items.Select(item => _mapper.Map<User>(item)).ToList();

            paginationHelper.Items = users;

            return ResponseDto<PaginationHelper<User>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<User>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.userQueryRepository.GetById(id);
            return ResponseDto<User>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.userCommandRepository.RemoveById(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateUserModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            var entity = _mapper.Map<User>(model);
            entity.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            context.Repositories.userCommandRepository.Update(entity);
            context.SaveChanges();
        }
    }
}
