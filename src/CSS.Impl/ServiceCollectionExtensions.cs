using CSS.Core.Interfaces;
using CSS.Impl.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSS.Impl;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOhlcvService, OhlcvService>();

        return services;
    }
}
