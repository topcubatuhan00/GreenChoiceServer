using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.StoreRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.StoreRepositories;

public class StoreCommandRepository : Repository, IStoreCommandRepository
{
    #region Ctor
    public StoreCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(Store model)
    {
        var query = "INSERT INTO [Store]" +
            "(Name, Adress, PhoneNumber, IsOnlineAvailable,CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "(@name, @adress, @phone, @online, @createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@adress", model.Adress);
        command.Parameters.AddWithValue("@phone", model.PhoneNumber);
        command.Parameters.AddWithValue("@online", model.IsOnlineAvailable);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", model.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var command = CreateCommand("delete from [Store] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Store model)
    {
        var query = "update [Store] set Name=@name, Adress=@adress, PhoneNumber=@phoneNumber, IsOnlineAvailable=@online where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@adress", model.Adress);
        command.Parameters.AddWithValue("@phoneNumber", model.PhoneNumber);
        command.Parameters.AddWithValue("@online", model.IsOnlineAvailable);

        await command.ExecuteNonQueryAsync();
    }
}
