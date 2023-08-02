using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;

public interface ISustainabilityCriteriaQueryRepository
{
    PaginationHelper<SustainabilityCriteria> GetAll(PaginationRequest request);
    Task<SustainabilityCriteria> GetById(int Id);
}
