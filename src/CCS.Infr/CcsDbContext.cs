using CCS.Core.Entities;
using CCS.Infr.Converters;

namespace CCS.Infr;

public sealed class CcsDbContext(DbContextOptions<CcsDbContext> options) : DbContext(options)
{
    public DbSet<Ohlcv1mEntity> Ohlcv1m { get; set; } = default!;
    public DbSet<Ohlcv3mEntity> Ohlcv3m { get; set; } = default!;
    public DbSet<Ohlcv5mEntity> Ohlcv5m { get; set; } = default!;
    public DbSet<Ohlcv15mEntity> Ohlcv15m { get; set; } = default!;
    public DbSet<Ohlcv30mEntity> Ohlcv30m { get; set; } = default!;
    public DbSet<Ohlcv1hEntity> Ohlcv1h { get; set; } = default!;
    public DbSet<Ohlcv2hEntity> Ohlcv2h { get; set; } = default!;
    public DbSet<Ohlcv4hEntity> Ohlcv4h { get; set; } = default!;
    public DbSet<Ohlcv6hEntity> Ohlcv6h { get; set; } = default!;
    public DbSet<Ohlcv12hEntity> Ohlcv12h { get; set; } = default!;
    public DbSet<Ohlcv1dEntity> Ohlcv1d { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnTablesCreating(modelBuilder);

        DateTimeToUtcConvert(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void OnTablesCreating(ModelBuilder builder)
    {
        builder.Entity<Ohlcv1mEntity>().ToTable("ohlcv_1m");
        builder.Entity<Ohlcv1mEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_1m_timestamp");

        builder.Entity<Ohlcv3mEntity>().ToTable("ohlcv_3m");
        builder.Entity<Ohlcv3mEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_3m_timestamp");

        builder.Entity<Ohlcv5mEntity>().ToTable("ohlcv_5m");
        builder.Entity<Ohlcv5mEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_5m_timestamp");

        builder.Entity<Ohlcv15mEntity>().ToTable("ohlcv_15m");
        builder.Entity<Ohlcv15mEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_15m_timestamp");

        builder.Entity<Ohlcv30mEntity>().ToTable("ohlcv_30m");
        builder.Entity<Ohlcv30mEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_30m_timestamp");

        builder.Entity<Ohlcv1hEntity>().ToTable("ohlcv_1h");
        builder.Entity<Ohlcv1hEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_1h_timestamp");

        builder.Entity<Ohlcv2hEntity>().ToTable("ohlcv_2h");
        builder.Entity<Ohlcv2hEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_2h_timestamp");

        builder.Entity<Ohlcv4hEntity>().ToTable("ohlcv_4h");
        builder.Entity<Ohlcv4hEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_4h_timestamp");

        builder.Entity<Ohlcv6hEntity>().ToTable("ohlcv_6h");
        builder.Entity<Ohlcv6hEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_6h_timestamp");

        builder.Entity<Ohlcv12hEntity>().ToTable("ohlcv_12h");
        builder.Entity<Ohlcv12hEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_12h_timestamp");

        builder.Entity<Ohlcv1dEntity>().ToTable("ohlcv_1d");
        builder.Entity<Ohlcv1dEntity>().HasIndex(x => x.Timestamp).HasDatabaseName("ix_ohlcv_1d_timestamp");
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
