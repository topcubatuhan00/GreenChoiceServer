using GreenChoice.Domain.Entities;

namespace GreenChoice.Application.Services;

public interface IAuthService
{
    Task<User> CheckByUser(string userName);
}
