using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.StoreRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.StoreRepositories;

public class StoreQueryRepository : Repository, IStoreQueryRepository
{
    #region Ctor
    public StoreQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Store> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Store]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Store] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                stores.Add(new Store
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Adress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    IsOnlineAvailable = bool.Parse(reader["IsOnlineAvailable"].ToString()),
                    AverageScore = float.Parse(reader["AverageScore"].ToString())
                });
            }
            return new PaginationHelper<Store>(totalCount, request.PageSize, request.PageNumber, stores);
        }
    }

    public async Task<Store> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Store] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Store
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Adress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    IsOnlineAvailable = bool.Parse(reader["IsOnlineAvailable"].ToString()),
                    AverageScore = float.Parse(reader["AverageScore"].ToString())
                };
            }
            else
                return null;
        }
    }

    public async Task<IList<Store>> GetForHome(int storeCount)
    {
        var command = CreateCommand($"SELECT TOP {storeCount} * FROM [Store] ORDER BY AverageScore DESC;");

        using (var reader = command.ExecuteReader())
        {
            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                stores.Add(new Store
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Adress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    IsOnlineAvailable = bool.Parse(reader["IsOnlineAvailable"].ToString()),
                    AverageScore = float.Parse(reader["AverageScore"].ToString())
                });
            }
            return stores;
        }
    }
}
