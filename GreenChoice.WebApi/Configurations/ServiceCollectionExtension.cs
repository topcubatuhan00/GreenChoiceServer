using GreenChoice.Application.Services;
using GreenChoice.Application.Services.Utilities;
using GreenChoice.Domain.UnitOfWork;
using GreenChoice.Persistance.Mapping;
using GreenChoice.Persistance.Services;
using GreenChoice.Persistance.Services.Utilities;
using GreenChoice.Persistance.UnitOfWorks;

namespace GreenChoice.WebApi.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServiceConfigurations(this IServiceCollection services)
    {
        #region App Scopes
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ICampaignService, CampaignService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductCriteriaRSService, ProductCriteriaRSService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<ISustainabilityCriteriaService, SustainabilityCriteriaService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserCampaignRSService, UserCampaignRSService>();
        services.AddScoped<ISettingsService, SettingsService>();
        services.AddScoped<IFavoritesService, FavoritesService>();
        #endregion

        #region Utilities
        services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        #endregion

        return services;
    }
}
