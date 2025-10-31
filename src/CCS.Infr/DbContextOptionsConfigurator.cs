namespace CCS.Infr;

public static class DbContextOptionsConfigurator
{
    /// <summary>
    /// via EFCore.NamingConventions
    /// ALTER TABLE "__EFMigrationsHistory" RENAME COLUMN "migration_id" TO "MigrationId";
    /// ALTER TABLE "__EFMigrationsHistory" RENAME COLUMN product_version TO "ProductVersion";
    /// or
    /// ALTER TABLE "__EFMigrationsHistory" RENAME COLUMN "MigrationId" TO "migration_id";
    /// ALTER TABLE "__EFMigrationsHistory" RENAME column "ProductVersion" TO "product_version";
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="connectionString"></param>
    public static void ConfigureCommon(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }
}


