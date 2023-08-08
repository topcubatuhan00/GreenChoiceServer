using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.StoreRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.StoreRepositories;

public class StoreQueryRepository :Repository, IStoreQueryRepository
{
    #region Ctor
    public StoreQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Store> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Store> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
