namespace CCS.Infr;

public static class DbContextOptionsConfigurator
{
    public static void ConfigureCommon(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }
}


