using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.CategoryRepositories;
using GreenChoice.Domain.Repositories.SettingsRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CategoryRepositories;

public class CategoryQueryRepository : Repository, ICategoryQueryRepository
{
    public CategoryQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    public PaginationHelper<Category> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Category]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Category] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                });
            }
            return new PaginationHelper<Category>(totalCount, request.PageSize, request.PageNumber, categories);
        }
    }

    public async Task<Category> GetById(int Id)
    {
        var command = CreateCommand("SELECT * FROM [Category] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", Id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Category
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty
                };
            }
            else
                return null;
        }
    }

    public async Task<Category> GetByName(string Name)
    {
        var command = CreateCommand("SELECT * FROM [Category] WHERE Name = @name");
        command.Parameters.AddWithValue("@name", Name);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Category
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty
                };
            }
            else
                return null;
        }
    }
}
