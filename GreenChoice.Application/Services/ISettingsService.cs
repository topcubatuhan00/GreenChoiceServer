using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public interface ISettingsService
{
    Task<ResponseDto<Settings>> GetById(int Id);
    Task<ResponseDto<Settings>> GetByName(string Name);
    Task<ResponseDto<PaginationHelper<Settings>>> GetAll(PaginationRequest request);
    Task Create(Settings model);
    Task Update(Settings model);
    Task Remove(int id);
}
