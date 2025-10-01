using CCS.Core.Interfaces;
using CCS.Core.Options;
using CCS.Infr.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CCS.Infr;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextPool<CcsDbContext>((sp, options) =>
        {
            CcsOptions ccs = sp.GetRequiredService<IOptions<CcsOptions>>().Value;
            string? connectionString = ccs.ConnectionStrings.Postgres;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'postgres' is not configured.");
            }

            DbContextOptionsConfigurator.ConfigureCommon(options, connectionString);
        });

        services.AddScoped<IOhlcvRepository, OhlcvRepository>();

        return services;
    }
}


