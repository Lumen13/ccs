using CCS.CctxClient.Clients;
using CCS.CctxClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CCS.CctxClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCctxClients(this IServiceCollection services)
    {
        services.AddScoped<IOhlcvClient, OhlcvClient>();

        return services;
    }
}
