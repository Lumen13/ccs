using CCS.Core.Options;

namespace CCS;

/// <summary>
/// Core ServiceCollectionExtensions
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<CcsOptions>(config);

        return services;
    }
}
