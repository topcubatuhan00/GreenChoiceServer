using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.UserRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserQueryRepository : Repository, IUserQueryRepository
{
    #region Ctor
    public UserQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public Task<bool> CheckDatabaseForUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CheckUserNameAndPassword(string userName)
    {
        var command = CreateCommand("SELECT *  FROM Users WHERE UserName = @UserName");

        command.Parameters.AddWithValue("@UserName", userName);

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                    PasswordHash = reader["PasswordHash"] != DBNull.Value ? reader["PasswordHash"].ToString() : string.Empty,
                    Photo = reader["Photo"] != DBNull.Value ? reader["Photo"].ToString() : string.Empty,
                    RoleName = reader["RoleName"] != DBNull.Value ? reader["RoleName"].ToString() : string.Empty
                };

                return user;
            }
        }

        return null;
    }

    public Task<User> GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByMail(string email)
    {
        throw new NotImplementedException();
    }
}
