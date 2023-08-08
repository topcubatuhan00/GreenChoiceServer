using AutoMapper;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.Models.CampaignModels;
using GreenChoice.Domain.Models.CategoryModels;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.Domain.Models.StoreModels;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;
using GreenChoice.Domain.Models.UserCampaignRSModels;

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

        #region Comment
        CreateMap<Comment, CreateCommentModel>().ReverseMap();
        CreateMap<Comment, UpdateCommentModel>().ReverseMap();
        #endregion

        #region Product
        CreateMap<Product, CreateProductModel>().ReverseMap();
        CreateMap<Product, UpdateProductModel>().ReverseMap();
        #endregion

        #region ProductCriteriaRS
        CreateMap<ProductCriteriaRS, CreateProductCriteriaRSModel>().ReverseMap();
        CreateMap<ProductCriteriaRS, UpdateProductCriteriaRSModel>().ReverseMap();
        #endregion

        #region Store
        CreateMap<Store, CreateStoreModel>().ReverseMap();
        CreateMap<Store, UpdateStoreModel>().ReverseMap();
        #endregion

        #region SustainabilityCriteria
        CreateMap<SustainabilityCriteria, CreateSustainabilityCriteriaModel>().ReverseMap();
        CreateMap<SustainabilityCriteria, UpdateSustainabilityCriteriaModel>().ReverseMap();
        #endregion

        #region UserCampaignRS
        CreateMap<UserCampaignRS, CreateSustainabilityCriteriaModel>().ReverseMap();
        CreateMap<UserCampaignRS, UpdateUserCampaignRSModel>().ReverseMap();
        #endregion
    }
}
