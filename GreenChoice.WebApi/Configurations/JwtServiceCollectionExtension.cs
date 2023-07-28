using GreenChoice.Application.Services.Utilities;
using GreenChoice.Infrastructure.Jwt;

namespace GreenChoice.WebApi.Configurations;

public static class JwtServiceCollectionExtension
{
    public static IServiceCollection JwtServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
