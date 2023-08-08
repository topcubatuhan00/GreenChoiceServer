using AutoMapper;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.Models.CampaignModels;
using GreenChoice.Domain.Models.CategoryModels;

namespace GreenChoice.Persistance.Mapping;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<User, UserRegisterModel>().ReverseMap();
        #endregion

        #region Campaign
        CreateMap<Campaign, CreateCampaignModel>().ReverseMap();
        CreateMap<Campaign, UpdateCampaignModel>().ReverseMap();
        #endregion

        #region Category
        CreateMap<Category, CreateCategoryModel>().ReverseMap();
        CreateMap<Category, UpdateCategoryModel>().ReverseMap();
        #endregion
    }
}
