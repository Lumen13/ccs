using CCS.Core.Options;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CCS.Infr;

public sealed class CcsDbContextFactory : IDesignTimeDbContextFactory<CcsDbContext>
{
    public CcsDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "CCS"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        CcsOptions options = new();
        configuration.Bind(options);

        DbContextOptionsBuilder<CcsDbContext> builder = new();
        builder.UseNpgsql(configuration.GetConnectionString("postgres"));
        builder.UseSnakeCaseNamingConvention();

        return new CcsDbContext(builder.Options);
    }
}


