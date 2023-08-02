using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserCampaignRSModels;

namespace GreenChoice.Application.Services;

public class UserCampaignRSService : IUserCampaignRSService
{
    public Task Create(CreateUserCampaignRSModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<UserCampaignRS>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<UserCampaignRS>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateUserCampaignRSModel model)
    {
        throw new NotImplementedException();
    }
}
