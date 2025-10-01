using CCS.Core.Entities;
using CCS.Infr.Converters;

namespace CCS.Infr;

public sealed class CcsDbContext(DbContextOptions<CcsDbContext> options) : DbContext(options)
{
    public DbSet<OhlcvEntity> OhlcvEntities { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnTablesCreating(modelBuilder);

        DateTimeToUtcConvert(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void OnTablesCreating(ModelBuilder builder)
    {
        builder.Entity<OhlcvEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_timestamp");
    }

    private static void DateTimeToUtcConvert(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(new DateTimeUtcConverter());
                    property.SetColumnType("timestamp with time zone");
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new NullableDateTimeUtcConverter());
                    property.SetColumnType("timestamp with time zone");
                }
            }
        }
    }
}
