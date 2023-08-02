using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.UserRepositories;

public interface IUserQueryRepository
{
    PaginationHelper<User> GetAll(PaginationRequest request);
    Task<User> GetById(int Id);
    Task<User> GetByMail(string email);
    Task<User> GetByUserName(string userName);
    Task<bool> CheckUserId(int userId);
    Task<bool> CheckDatabaseForUserName(string userName);
    Task<User> CheckUserNameAndPassword(string userName);
}
