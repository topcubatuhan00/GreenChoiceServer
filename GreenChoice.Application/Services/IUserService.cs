using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserModels;

namespace GreenChoice.Application.Services;

public interface IUserService
{
    Task<ResponseDto<User>> GetById(int id);
    Task<ResponseDto<PaginationHelper<User>>> GetAll(PaginationRequest request);
    Task Create(CreateUserModel model);
    Task Update(UpdateUserModel model);
    Task Remove(int id);
}
