using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CampaignModels;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Application.Services;

public interface ICampaignService
{
    Task<ResponseDto<Campaign>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Campaign>>> GetAll(PaginationRequest request);
    Task Create(CreateCampaignModel model);
    Task Update(UpdateCampaignModel model);
    Task Remove(int id);
}
