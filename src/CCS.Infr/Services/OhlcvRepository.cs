using CCS.Core.Entities;
using CCS.Core.Interfaces;
using CCS.Core.Models;
using CCS.Infr.Mappers;

namespace CCS.Infr.Services;

internal sealed class OhlcvRepository(CcsDbContext ccsDbContext, Microsoft.Extensions.Options.IOptions<Core.Options.CcsOptions> options) : IOhlcvRepository
{
    private readonly int batchSize = options.Value.DbDefaultBatchSize;
    private readonly CcsDbContext ccsDbContext = ccsDbContext;

    public async Task AddRangeAsync(IEnumerable<OhlcvModel> data, CancellationToken ct = default)
    {
        List<OhlcvModel> items = data as List<OhlcvModel> ?? [.. data];
        if (items.Count == 0)
        {
            return;
        }

        List<OhlcvEntity> entities = items.ToEntityList();

        int batchSize = this.batchSize;
        for (int i = 0; i < entities.Count; i += batchSize)
        {
            List<OhlcvEntity> batch = [.. entities.Skip(i).Take(batchSize)];
            await ccsDbContext.Set<OhlcvEntity>().AddRangeAsync(batch, ct);
            await ccsDbContext.SaveChangesAsync(ct);
        }
    }
}
