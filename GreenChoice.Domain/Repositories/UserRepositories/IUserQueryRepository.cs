using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.UserRepositories;

public interface IUserQueryRepository
{
    //PaginationHelper<UserListModel> GetAll(int pageNumber, int pageSize);
    Task<User> GetById(int Id);
    Task<User> GetByMail(string email);
    Task<bool> CheckUserId(int userId);
    Task<bool> CheckDatabaseForUserName(string userName);
    Task<User> CheckUserNameAndPassword(string userName);
}
