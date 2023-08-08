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
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
