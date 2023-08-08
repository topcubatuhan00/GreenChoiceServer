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
