using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.Domain.Repositories.ProductRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductRepositories;

public class ProductCommandRepository : Repository, IProductCommandRepository
{
    public async Task AddAsync(CreateProductModel model)
    {
        var query = "INSERT INTO [Campaign]" +
            "(CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName) VALUES" +
            "@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
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
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UpdateProductModel model)
    {
        throw new NotImplementedException();
    }
}
