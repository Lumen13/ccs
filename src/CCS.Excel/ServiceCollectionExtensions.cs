using CCS.Core.Interfaces;
using CCS.Excel.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CCS.Excel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExcelExports(this IServiceCollection services)
    {
        services.AddScoped<IExportService, ExportService>();
        return services;
    }
}
