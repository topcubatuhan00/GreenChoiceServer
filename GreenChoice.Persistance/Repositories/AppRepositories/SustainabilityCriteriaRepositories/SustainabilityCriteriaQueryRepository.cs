using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SustainabilityCriteriaRepositories;

public class SustainabilityCriteriaQueryRepository : Repository, ISustainabilityCriteriaQueryRepository
{
    #region Ctor
    public SustainabilityCriteriaQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<SustainabilityCriteria> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [SustainabilityCriteria]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [SustainabilityCriteria] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<SustainabilityCriteria> suss = new List<SustainabilityCriteria>();
            while (reader.Read())
            {
                suss.Add(new SustainabilityCriteria
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                });
            }
            return new PaginationHelper<SustainabilityCriteria>(totalCount, request.PageSize, request.PageNumber, suss);
        }
    }

    public async Task<SustainabilityCriteria> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [SustainabilityCriteria] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new SustainabilityCriteria
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                };
            }
            else
                return null;
        }
    }
}
