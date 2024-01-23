using Azure.Core;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.ProductRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductRepositories;

public class ProductQueryRepository : Repository, IProductQueryRepository
{
    #region Ctor
    public ProductQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Product> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Product]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Product] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    BrandName = reader["Description"] != null ? reader["Description"].ToString() : "",
                    Barcode = reader["Description"] != null ? reader["Description"].ToString() : "",
                    PackageInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    ProductionProcessInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                });
            }
            return new PaginationHelper<Product>(totalCount, request.PageSize, request.PageNumber, products);
        }
    }

    public async Task<Product> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Product] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    BrandName = reader["Description"] != null ? reader["Description"].ToString() : "",
                    Barcode = reader["Description"] != null ? reader["Description"].ToString() : "",
                    PackageInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    ProductionProcessInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                };
            }
            else
                return null;
        }
    }

    public async Task<Product> GetByName(string Name)
    {
        var command = CreateCommand("SELECT * FROM [Product] WHERE Name=@name");
        command.Parameters.AddWithValue("@name", Name);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    BrandName = reader["Description"] != null ? reader["Description"].ToString() : "",
                    Barcode = reader["Description"] != null ? reader["Description"].ToString() : "",
                    PackageInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    ProductionProcessInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                };
            }
            else
                return null;
        }
    }

    public async Task<IList<Product>> GetForHome(int productCount)
    {
        var command = CreateCommand($"SELECT TOP {productCount} * FROM [Product] ORDER BY AverageScore DESC;");

        using (var reader = command.ExecuteReader())
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    BrandName = reader["Description"] != null ? reader["Description"].ToString() : "",
                    Barcode = reader["Description"] != null ? reader["Description"].ToString() : "",
                    PackageInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    ProductionProcessInformation = reader["Description"] != null ? reader["Description"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = float.Parse(reader["AverageScore"].ToString()),
                });
            }
            return products;
        }
    }
}
