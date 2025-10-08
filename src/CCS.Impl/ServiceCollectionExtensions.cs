using CCS.CctxClient.Interfaces;
using CCS.Core.Interfaces;
using CCS.Impl.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CCS.Impl;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOhlcvValidator, OhlcvValidator>();
        services.AddScoped<IOhlcvService, OhlcvService>();
        services.AddScoped<IExportPathProvider, DefaultExportPathProvider>();

        return services;
    }
}
