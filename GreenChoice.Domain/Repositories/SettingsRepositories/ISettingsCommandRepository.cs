using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.SettingModels;

namespace GreenChoice.Domain.Repositories.SettingsRepositories;

public interface ISettingsCommandRepository
{
    Task AddAsync(Settings model);
    Task UpdateAsync(Settings model);
    Task UpdateValue(SettingsUpdateModel model);
    Task RemoveByIdAsync(int id);
}
