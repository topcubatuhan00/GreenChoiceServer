using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserModels;

namespace GreenChoice.Application.Services;

public class UserService : IUserService
{
    public Task Create(CreateUserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<User>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<User>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateUserModel model)
    {
        throw new NotImplementedException();
    }
}
