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

    public async Task AddRangeAsync(OhlcvResponseModel ohlcvModels, CancellationToken ct = default)
    {
        if (ohlcvModels.Count == 0)
        {
            return;
        }

        List<OhlcvEntity> entities = ohlcvModels.Data.ToEntityList();

        int batchSize = this.batchSize;
        for (int i = 0; i < entities.Count; i += batchSize)
        {
            List<OhlcvEntity> batch = [.. entities.Skip(i).Take(batchSize)];
            await ccsDbContext.Set<OhlcvEntity>().AddRangeAsync(batch, ct);
            await ccsDbContext.SaveChangesAsync(ct);
        }
    }
}
