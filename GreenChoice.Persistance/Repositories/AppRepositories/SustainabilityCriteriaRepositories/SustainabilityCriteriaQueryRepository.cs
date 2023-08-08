using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SustainabilityCriteriaRepositories;

public class SustainabilityCriteriaQueryRepository : Repository, ISustainabilityCriteriaQueryRepository
{
    #region Ctor
    public SustainabilityCriteriaQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<SustainabilityCriteria> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<SustainabilityCriteria> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
