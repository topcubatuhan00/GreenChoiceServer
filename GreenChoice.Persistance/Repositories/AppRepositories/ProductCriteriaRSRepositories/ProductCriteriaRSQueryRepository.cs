using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;

public class ProductCriteriaRSQueryRepository : Repository,IProductCriteriaRSQueryRepository
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
        throw new NotImplementedException();
    }

    public Task<ProductCriteriaRS> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
