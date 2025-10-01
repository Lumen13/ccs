using Microsoft.Extensions.DependencyInjection;
using CCS.Core.Interfaces;
using CCS.Excel.Services;

namespace CCS.Excel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExcelExports(this IServiceCollection services)
    {
        services.AddScoped<IExportService, ExportService>();
        return services;
    }
}
