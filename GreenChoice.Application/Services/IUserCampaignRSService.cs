using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserCampaignRSModels;

namespace GreenChoice.Application.Services;

public interface IUserCampaignRSService
{
    Task<ResponseDto<UserCampaignRS>> GetById(int id);
    Task<ResponseDto<PaginationHelper<UserCampaignRS>>> GetAll(PaginationRequest request);
    Task Create(CreateUserCampaignRSModel model);
    Task Update(UpdateUserCampaignRSModel model);
    Task Remove(int id);
}
