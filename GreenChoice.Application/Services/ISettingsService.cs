using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SettingModels;

namespace GreenChoice.Application.Services;

public interface ISettingsService
{
    Task<ResponseDto<Settings>> GetById(int Id);
    Task<ResponseDto<Settings>> GetByName(string Name);
    Task<IList<Settings>> GetAllByUserName(string userName);
    Task<ResponseDto<PaginationHelper<Settings>>> GetAll(PaginationRequest request);
    Task Create(SettingCreateModel model);
    Task Update(Settings model);
    Task Remove(int id);
}
