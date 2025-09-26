using CSS.CctxClient.Clients;
using CSS.CctxClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CSS.CctxClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCctxClients(this IServiceCollection services)
    {
        services.AddScoped<IOhlcvClient, OhlcvClient>();

        return services;
    }
}
