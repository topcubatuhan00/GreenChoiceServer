using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;

namespace GreenChoice.Application.Services;

public interface IAuthService
{
    Task<User> CheckByUser(string userName);
    Task<bool> UserIsExist(string userName);
    Task Register(UserRegisterModel userModel);
    Task<string> Login(UserLoginModel userLoginModel);
}
