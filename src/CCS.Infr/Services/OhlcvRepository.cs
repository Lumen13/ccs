using CCS.Core.Entities;
using CCS.Core.Interfaces;
using CCS.Core.Models;
using CCS.Core.Options;
using CCS.Infr.Mappers;
using Microsoft.Extensions.Options;

namespace CCS.Infr.Services;

internal sealed class OhlcvRepository(CcsDbContext ccsDbContext, IOptions<CcsOptions> options) : IOhlcvRepository
{
    private readonly int batchSize = options.Value.DbDefaultBatchSize;
    private readonly CcsDbContext ccsDbContext = ccsDbContext;

    public async Task AddRangeAsync(string timeFrame, bool runSingleRequest, OhlcvResponseModel ohlcvModels, CancellationToken ct = default)
    {
        if (ohlcvModels.Count == 0 || runSingleRequest)
        {
            return;
        }

        // Map to base entity then route to per-TF tables
        List<OhlcvEntity> entities = ohlcvModels.Data.ToEntityList();

        int batchSize = this.batchSize;
        for (int i = 0; i < entities.Count; i += batchSize)
        {
            List<OhlcvEntity> batch = [.. entities.Skip(i).Take(batchSize)];
            switch (timeFrame)
            {
                case "1m":
                    await ccsDbContext.Ohlcv1m.AddRangeAsync(batch.Select(e => new Ohlcv1mEntity(e)), ct); break;
                case "3m":
                    await ccsDbContext.Ohlcv3m.AddRangeAsync(batch.Select(e => new Ohlcv3mEntity(e)), ct); break;
                case "5m":
                    await ccsDbContext.Ohlcv5m.AddRangeAsync(batch.Select(e => new Ohlcv5mEntity(e)), ct); break;
                case "15m":
                    await ccsDbContext.Ohlcv15m.AddRangeAsync(batch.Select(e => new Ohlcv15mEntity(e)), ct); break;
                case "30m":
                    await ccsDbContext.Ohlcv30m.AddRangeAsync(batch.Select(e => new Ohlcv30mEntity(e)), ct); break;
                case "1h":
                    await ccsDbContext.Ohlcv1h.AddRangeAsync(batch.Select(e => new Ohlcv1hEntity(e)), ct); break;
                case "2h":
                    await ccsDbContext.Ohlcv2h.AddRangeAsync(batch.Select(e => new Ohlcv2hEntity(e)), ct); break;
                case "4h":
                    await ccsDbContext.Ohlcv4h.AddRangeAsync(batch.Select(e => new Ohlcv4hEntity(e)), ct); break;
                case "6h":
                    await ccsDbContext.Ohlcv6h.AddRangeAsync(batch.Select(e => new Ohlcv6hEntity(e)), ct); break;
                case "12h":
                    await ccsDbContext.Ohlcv12h.AddRangeAsync(batch.Select(e => new Ohlcv12hEntity(e)), ct); break;
                case "1d":
                    await ccsDbContext.Ohlcv1d.AddRangeAsync(batch.Select(e => new Ohlcv1dEntity(e)), ct); break;
                default:
                    return; // unknown timeframe — do not write
            }
            await ccsDbContext.SaveChangesAsync(ct);
        }
    }
}
