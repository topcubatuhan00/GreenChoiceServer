using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;

namespace GreenChoice.Application.Services;

public interface IAuthService
{
    Task<User> CheckByUser(string userName);
    Task<bool> CheckDatabaseForUser(string userName);
    Task Register(UserRegisterModel userModel);
}
