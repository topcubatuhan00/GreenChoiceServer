using GreenChoice.Domain.Models.SustainabilityCriteriaModels;

namespace GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;

public interface ISustainabilityCriteriaCommandRepository
{
    Task AddAsync(CreateSustainabilityCriteriaModel model);
    Task UpdateAsync(UpdateSustainabilityCriteriaModel model);
    Task RemoveByIdAsync(int id);
}
