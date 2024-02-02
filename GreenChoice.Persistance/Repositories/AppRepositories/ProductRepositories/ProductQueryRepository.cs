using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.Domain.Repositories.ProductRepositories;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

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
                    BrandName = reader["BrandName"] != null ? reader["BrandName"].ToString() : "",
                    Barcode = reader["Barcode"] != null ? reader["Barcode"].ToString() : "",
                    PackageInformation = reader["PackageInformation"] != null ? reader["PackageInformation"].ToString() : "",
                    ProductionProcessInformation = reader["ProductionProcessInformation"] != null ? reader["ProductionProcessInformation"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                    Price = reader["Price"] != null ? reader["Price"].ToString() : "",
                    StoreId = Convert.ToInt32(reader["StoreId"])
                });
            }
            return new PaginationHelper<Product>(totalCount, request.PageSize, request.PageNumber, products);
        }
    }

    public async Task<GetByIdProductResponse> GetById(int id)
    {
        var command = CreateCommand($@"
            SELECT P.*, C.Name as CategoryName, S.Name as StoreName
            FROM [Product] P
            JOIN [Category] C ON P.CategoryId = C.Id
            JOIN [Store] S ON P.StoreId = S.Id
            where P.Id = @id;
        ");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new GetByIdProductResponse
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryName = reader["CategoryName"] != null ? reader["CategoryName"].ToString() : "",
                    BrandName = reader["BrandName"] != null ? reader["BrandName"].ToString() : "",
                    Barcode = reader["Barcode"] != null ? reader["Barcode"].ToString() : "",
                    PackageInformation = reader["PackageInformation"] != null ? reader["PackageInformation"].ToString() : "",
                    ProductionProcessInformation = reader["ProductionProcessInformation"] != null ? reader["ProductionProcessInformation"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                    Price = reader["Price"] != null ? reader["Price"].ToString() : "",
                    StoreName = reader["StoreName"] != null ? reader["StoreName"].ToString() : "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    StoreId = Convert.ToInt32(reader["StoreId"]),
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
                    BrandName = reader["BrandName"] != null ? reader["BrandName"].ToString() : "",
                    Barcode = reader["Barcode"] != null ? reader["Barcode"].ToString() : "",
                    PackageInformation = reader["PackageInformation"] != null ? reader["PackageInformation"].ToString() : "",
                    ProductionProcessInformation = reader["ProductionProcessInformation"] != null ? reader["ProductionProcessInformation"].ToString() : "",
                    SustainabilityScore = Convert.ToSingle(reader["SustainabilityScore"]),
                    AverageScore = Convert.ToSingle(reader["AverageScore"]),
                    Price = reader["Price"] != null ? reader["Price"].ToString() : "",
                    StoreId = Convert.ToInt32(reader["StoreId"])
                };
            }
            else
                return null;
        }
    }

    public async Task<IList<HomeResponseProductModel>> GetForHome(int productCount)
    {
        var command = CreateCommand($@"
            SELECT TOP {productCount} P.*, C.Name as CategoryName
            FROM [Product] P
            JOIN [Category] C ON P.CategoryId = C.Id
            ORDER BY P.AverageScore DESC;
        ");

        using (var reader = command.ExecuteReader())
        {
            List<HomeResponseProductModel> products = new List<HomeResponseProductModel>();
            while (reader.Read())
            {
                products.Add(new HomeResponseProductModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Description = reader["Description"] != null ? reader["Description"].ToString() : "",
                    CategoryName = reader["CategoryName"] != null ? reader["CategoryName"].ToString() : "",
                    BrandName = reader["BrandName"] != null ? reader["BrandName"].ToString() : "",
                    AverageScore = float.Parse(reader["AverageScore"].ToString()),
                    Price = reader["Price"] != null ? reader["Price"].ToString() : "",
                    StoreId = Convert.ToInt32(reader["StoreId"])
                });
            }
            return products;
        }
    }

    public async Task<IList<GetByStoreIdProductModel>> GetWithStoreId(int storeId)
    {
        var command = CreateCommand($@" SELECT * FROM [Product] where StoreId=@sid;");

        command.Parameters.AddWithValue("@sid", storeId);

        using (var reader = command.ExecuteReader())
        {
            List<GetByStoreIdProductModel> products = new List<GetByStoreIdProductModel>();
            while (reader.Read())
            {
                products.Add(new GetByStoreIdProductModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != null ? reader["Name"].ToString() : "",
                    Price = reader["Price"] != null ? reader["Price"].ToString() : "",
                });
            }
            return products;
        }
    }
}
