﻿using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.SettingsRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SettingsRepositories;

public class SettingsCommandRepository : Repository, ISettingsCommandRepository
{
    #region Ctor
    public SettingsCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task AddAsync(Settings model)
    {
        var query = "INSERT INTO [Settings]" +
            "(Name, Value, CreatedDate,CreatorName) VALUES (" +
            "@name,@value, @date,@crname);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@value", model.Value);
        command.Parameters.AddWithValue("@date", model.CreatedDate);
        command.Parameters.AddWithValue("@crname", model.CreatorName);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var command = CreateCommand("delete from [Settings] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Settings model)
    {
        var query = "update [Settings] set Name=@name, Value=@value where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@value", model.Value);
        command.Parameters.AddWithValue("@id", model.Id);

        await command.ExecuteNonQueryAsync();
    }
    #endregion
}
