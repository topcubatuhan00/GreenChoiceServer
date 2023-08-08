using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;

namespace GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;

public interface ISustainabilityCriteriaCommandRepository
{
    Task AddAsync(SustainabilityCriteria model);
    Task UpdateAsync(SustainabilityCriteria model);
    Task RemoveByIdAsync(int id);
}
