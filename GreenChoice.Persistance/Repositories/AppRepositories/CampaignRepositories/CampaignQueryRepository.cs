using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.CampaignRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CampaignRepositories;

public class CampaignQueryRepository : Repository, ICampaignQueryRepository
{
    #region Ctor
    public CampaignQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Campaign> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Campaign]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Campaign] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Campaign> campaigns = new List<Campaign>();
            while (reader.Read())
            {
                campaigns.Add(new Campaign
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                    BeginDate = reader["BeginDate"] != DBNull.Value ? (DateTime)reader["BeginDate"] : DateTime.MinValue,
                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"] : DateTime.MinValue
                });
            }

            return new PaginationHelper<Campaign>(totalCount, request.PageSize, request.PageNumber, campaigns);
        }
    }

    public async Task<Campaign> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Campaign] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Campaign
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                    BeginDate = reader["BeginDate"] != DBNull.Value ? (DateTime)reader["BeginDate"] : DateTime.MinValue,
                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"] : DateTime.MinValue
                };
            }
            else
            {
                return null;
            }
        }
    }

    public async Task<Campaign> GetByName(string Name)
    {
        var command = CreateCommand("SELECT * FROM [Campaign] WHERE Name = @name");
        command.Parameters.AddWithValue("@name", Name);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Campaign
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                    BeginDate = reader["BeginDate"] != DBNull.Value ? (DateTime)reader["BeginDate"] : DateTime.MinValue,
                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"] : DateTime.MinValue
                };
            }
            else
            {
                return null;
            }
        }
    }
}

