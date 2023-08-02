using AutoMapper;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.Models.CampaignModels;

namespace GreenChoice.Persistance.Mapping;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserRegisterModel>().ReverseMap();
        CreateMap<Campaign, CreateCampaignModel>().ReverseMap();
        CreateMap<Campaign, UpdateCampaignModel>().ReverseMap();
    }
}
