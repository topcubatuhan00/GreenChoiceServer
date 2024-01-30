using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Repositories.ProductRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductRepositories;

public class ProductCommandRepository : Repository, IProductCommandRepository
{
    #region Ctor
    public ProductCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(Product model)
    {
        string averageScore = model.AverageScore.ToString();
        averageScore = averageScore.Replace('.', ',');

        string susScore = model.SustainabilityScore.ToString();
        susScore = susScore.Replace('.', ',');

        var query = "INSERT INTO [Product]" +
            "(Name, Description, CategoryId, BrandName, Barcode, PackageInformation, ProductionProcessInformation, SustainabilityScore, AverageScore, Price, StoreId," +
            "CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "(@name, @description, @categoryId, @brandName, @barcode, @packageInformation, @productionProcessInformation, @sustainabilityScore, @averageScore, @price, @storeId," +
            "@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);
        command.Parameters.AddWithValue("@categoryId", model.CategoryId);
        command.Parameters.AddWithValue("@brandName", model.BrandName);
        command.Parameters.AddWithValue("@barcode", model.Barcode);
        command.Parameters.AddWithValue("@packageInformation", model.PackageInformation);
        command.Parameters.AddWithValue("@productionProcessInformation", model.ProductionProcessInformation);
        command.Parameters.AddWithValue("@sustainabilityScore", susScore);
        command.Parameters.AddWithValue("@averageScore", averageScore);
        command.Parameters.AddWithValue("@price", model.Price);
        command.Parameters.AddWithValue("@storeId", model.StoreId);
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
        var command = CreateCommand("delete from [Product] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Product model)
    {
        var query = "update [Product] set " +
            "Name=@name,Description=@description,CategoryId=@categoryId," +
            "BrandName=@brandName,Barcode=@barcode,PackageInformation=@packageInformation," +
            "ProductionProcessInformation=@productionProcessInformation, " +
            "SustainabilityScore=@sustainabilityScore,AverageScore=@averageScore, StoreId=@store, Price=@price " +
            "where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", model.Id);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@description", model.Description);
        command.Parameters.AddWithValue("@categoryId", model.CategoryId);
        command.Parameters.AddWithValue("@brandName", model.BrandName);
        command.Parameters.AddWithValue("@barcode", model.Barcode);
        command.Parameters.AddWithValue("@packageInformation", model.PackageInformation);
        command.Parameters.AddWithValue("@productionProcessInformation", model.ProductionProcessInformation);
        command.Parameters.AddWithValue("@sustainabilityScore", model.SustainabilityScore);
        command.Parameters.AddWithValue("@averageScore", model.AverageScore);
        command.Parameters.AddWithValue("@store", model.StoreId);
        command.Parameters.AddWithValue("@price", model.Price);

        await command.ExecuteNonQueryAsync();
    }
}
