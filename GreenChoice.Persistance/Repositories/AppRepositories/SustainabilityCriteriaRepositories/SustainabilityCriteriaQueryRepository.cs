using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.SustainabilityCriteriaRepositories;

public class SustainabilityCriteriaQueryRepository : ISustainabilityCriteriaQueryRepository
{
    public PaginationHelper<SustainabilityCriteria> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<SustainabilityCriteria> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
