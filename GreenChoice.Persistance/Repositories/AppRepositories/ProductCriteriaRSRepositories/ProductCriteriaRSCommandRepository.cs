using GreenChoice.Domain.Models.ProductCriteriaRSModels;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;

public class ProductCriteriaRSCommandRepository : Repository, IProductCriteriaRSCommandRepository
{
    public async Task AddAsync(CreateProductCriteriaRSModel model)
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

    public Task RemoveByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateProductCriteriaRSModel model)
    {
        throw new NotImplementedException();
    }
}
