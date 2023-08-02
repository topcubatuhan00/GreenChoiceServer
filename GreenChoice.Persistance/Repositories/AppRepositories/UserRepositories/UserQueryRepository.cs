using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
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

    #region Methods
    public async Task<bool> CheckDatabaseForUserName(string userName)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [User] WHERE UserName = @userName");

        command.Parameters.AddWithValue("@userName", userName);
        var result = await command.ExecuteScalarAsync();

        int count;
        if (int.TryParse(result?.ToString(), out count))
        {
            return count > 0;
        }

        return false;
    }

    public async Task<bool> CheckUserId(int userId)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [User] WHERE Id = @id");

        command.Parameters.AddWithValue("@id", userId);
        var result = await command.ExecuteScalarAsync();

        int count;
        if (int.TryParse(result?.ToString(), out count))
        {
            return count > 0;
        }

        return false;
    }

    public async Task<User> CheckUserNameAndPassword(string userName)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE UserName = @UserName");

        command.Parameters.AddWithValue("@UserName", userName);

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                    Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty,
                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                    Photo = reader["Photo"] != DBNull.Value ? reader["Photo"].ToString() : string.Empty,
                    Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : string.Empty
                };

                return user;
            }
        }
        return null;
    }

    public PaginationHelper<User> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                Photo = reader["Photo"] != DBNull.Value ? reader["Photo"].ToString() : string.Empty,
                Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : string.Empty
            };
        }
    }

    public async Task<User> GetByMail(string email)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE Email = @email");
        command.Parameters.AddWithValue("@email", email);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                Photo = reader["Photo"] != DBNull.Value ? reader["Photo"].ToString() : string.Empty,
                Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : string.Empty
            };
        }
    }

    public async Task<User> GetByUserName(string userName)
    {
        var user = new User();

        var command = CreateCommand("SELECT * FROM [User] WHERE UserName = @username");
        command.Parameters.AddWithValue("@username", userName);

        using (var reader = await command.ExecuteReaderAsync())
        {
            if (await reader.ReadAsync())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty;
                user.Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
                user.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                user.Photo = reader["Photo"] != DBNull.Value ? reader["Photo"].ToString() : string.Empty;
                user.Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : string.Empty;
            }
            reader.Close();
        }

        return user;
    }

    #endregion
}
