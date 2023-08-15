using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.SettingsRepositories;

public interface ISettingsCommandRepository
{
    Task AddAsync(Settings model);
    Task UpdateAsync(Settings model);
    Task RemoveByIdAsync(int id);
}
