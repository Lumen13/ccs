using CSS.CctxClient.Interfaces;
using CSS.Core.Interfaces;
using CSS.Impl.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSS.Impl;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOhlcvExportService, OhlcvExportService>();
        services.AddScoped<IOhlcvValidator, OhlcvValidator>();
        services.AddScoped<IOhlcvService, OhlcvService>();

        return services;
    }
}
