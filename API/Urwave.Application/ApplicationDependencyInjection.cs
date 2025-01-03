using Microsoft.Extensions.DependencyInjection;
using Urwave.Application.MappingProfiles;
using Urwave.Application.Services.Core;
using Urwave.Application.Services.Implementation;

namespace Urwave.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        services.RegisterAutoMapper();

        return services;
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}