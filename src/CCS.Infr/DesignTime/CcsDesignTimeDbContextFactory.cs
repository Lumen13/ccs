using CCS.Core.Options;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CCS.Infr.DesignTime;

public sealed class CcsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CcsDbContext>
{
    public CcsDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CcsDbContext> optionsBuilder = new();

        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        string solutionRoot = Directory.GetCurrentDirectory();

        string webProjectPath = Path.Combine(solutionRoot, "src", "CCS");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.Exists(webProjectPath) ? webProjectPath : solutionRoot)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        CcsOptions ccsOptions = new();
        configuration.Bind(ccsOptions);

        string? connectionString = ccsOptions.ConnectionStrings?.Postgres ??
                                   configuration.GetConnectionString("postgres");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'postgres' is not configured.");
        }

        DbContextOptionsConfigurator.ConfigureCommon(optionsBuilder, connectionString);

        return new CcsDbContext(optionsBuilder.Options);
    }
}


