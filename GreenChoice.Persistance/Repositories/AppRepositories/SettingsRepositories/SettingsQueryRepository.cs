using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.SettingsRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SettingsRepositories;

public class SettingsQueryRepository : Repository, ISettingsQueryRepository
{
    #region Ctor
    public SettingsQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }
    #endregion
    public PaginationHelper<Settings> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Settings]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Settings] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Settings> campaigns = new List<Settings>();
            while (reader.Read())
            {
                campaigns.Add(new Settings
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Value = reader["Value"] != DBNull.Value ? reader["Value"].ToString() : string.Empty,
                });
            }

            return new PaginationHelper<Settings>(totalCount, request.PageSize, request.PageNumber, campaigns);
        }
    }

    public async Task<Settings> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Settings] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Settings
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Value = reader["Value"] != DBNull.Value ? reader["Value"].ToString() : string.Empty,
                };
            }
            else
            {
                return null;
            }
        }
    }

    public async Task<Settings> GetByName(string Name)
    {
        var command = CreateCommand("SELECT * FROM [Settings] WHERE Name = @name");
        command.Parameters.AddWithValue("@name", Name);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Settings
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Value = reader["Value"] != DBNull.Value ? reader["Value"].ToString() : string.Empty,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
