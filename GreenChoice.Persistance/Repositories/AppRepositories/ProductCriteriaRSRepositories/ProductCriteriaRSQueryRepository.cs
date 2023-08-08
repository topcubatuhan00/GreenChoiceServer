using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;

public class ProductCriteriaRSQueryRepository : Repository, IProductCriteriaRSQueryRepository
{
    #region Ctor
    public ProductCriteriaRSQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<ProductCriteriaRS> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [ProductCriteriaRS]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [ProductCriteriaRS] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<ProductCriteriaRS> productCriteriaRS = new List<ProductCriteriaRS>();
            while (reader.Read())
            {
                productCriteriaRS.Add(new ProductCriteriaRS
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    SustainabilityCriteriaId = Convert.ToInt32(reader["SustainabilityCriteriaId"]),
                    Score = Convert.ToSingle(reader["Score"]),
                });
            }
            return new PaginationHelper<ProductCriteriaRS>(totalCount, request.PageSize, request.PageNumber, productCriteriaRS);
        }
    }

    public async Task<ProductCriteriaRS> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [ProductCriteriaRS] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new ProductCriteriaRS
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    SustainabilityCriteriaId = Convert.ToInt32(reader["SustainabilityCriteriaId"]),
                    Score = Convert.ToSingle(reader["Score"]),
                };
            }
            else
                return null;
        }
    }
}
