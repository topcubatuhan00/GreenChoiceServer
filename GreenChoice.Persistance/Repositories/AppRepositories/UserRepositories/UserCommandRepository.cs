using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.UserRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserCommandRepository : Repository, IUserCommandRepository
{
    #region Ctor
    public UserCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task AddAsync(User model)
    {
        var query = "INSERT INTO [User]" +
            "(Username, Password, Email, Photo, Role," +
            "CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate," +
            "UpdaterName) VALUES" +
            "(@username,@password,@email,@photo,@role," +
            "@createddate,@creatorname,@deletedDate,@deletername," +
            "@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@username", model.UserName);
        command.Parameters.AddWithValue("@password", model.Password);
        command.Parameters.AddWithValue("@email", model.Email);
        command.Parameters.AddWithValue("@photo", model.Photo);
        command.Parameters.AddWithValue("@role", model.Role);
        command.Parameters.AddWithValue("@createddate", model.CreatedDate);
        command.Parameters.AddWithValue("@creatorname", model.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        await command.ExecuteNonQueryAsync();
    }

    public Task AddRangeAsync(IEnumerable<User> model)
    {
        throw new NotImplementedException();
    }

    public void Remove(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveById(int id)
    {
        var command = CreateCommand("delete from [User] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public void RemoveRange(IEnumerable<User> model)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        var query = "update [User] set UserName=@uname,Password=@pass,Email=@email,Photo=@photo,Role=@role where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@uname", entity.UserName);
        command.Parameters.AddWithValue("@pass", entity.Password);
        command.Parameters.AddWithValue("@email", entity.Email);
        command.Parameters.AddWithValue("@photo", entity.Photo);
        command.Parameters.AddWithValue("@role", entity.Role);
        command.Parameters.AddWithValue("@id", entity.Id);

        command.ExecuteNonQuery();
    }

    public void UpdatePassword(User entity)
    {
        var query = "update [User] set Password=@pass where Email=@email";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@pass", entity.Password);
        command.Parameters.AddWithValue("@email", entity.Email);

        command.ExecuteNonQuery();
    }

    public void UpdateRange(IEnumerable<User> model)
    {
        throw new NotImplementedException();
    }
    #endregion
}
