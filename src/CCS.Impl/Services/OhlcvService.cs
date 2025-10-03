using CCS.CctxClient.Interfaces;
using CCS.Core.Constants;
using CCS.Core.Interfaces;
using CCS.Core.Models;
using CCS.Core.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CCS.Impl.Services;

internal sealed class OhlcvService(
    IOhlcvClient ohlcvClient,
    IExportService fileExportService,
    IOhlcvRepository repository,
    IExportPathProvider exportPathProvider,
    IOptions<CcsOptions> options,
    ILogger<OhlcvService> logger
    ) : IOhlcvService
{
    private const int LastCandleIncrement = 1;
    private readonly string rootOutputDir = !string.IsNullOrWhiteSpace(options.Value.RootOutputDir)
        ? options.Value.RootOutputDir
        : throw new ArgumentNullException(nameof(options.Value.RootOutputDir));

    public async Task<List<OhlcvModel>> Get(
        OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        DateTime? from = null,
        DateTime? to = null,
        long limit = 1000,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default
    )
    {
        logger.LogInformation("FetchOHLCV. Prepare to get data");

        List<OhlcvModel> ohlcvList = await ohlcvClient.FetchOhlcv(
            parameters: parameters,
            symbol: symbol,
            timeFrame: timeFrame,
            from: from,
            to: to,
            limit: limit + LastCandleIncrement);
        if (ohlcvList.Count == 0)
        {
            logger.LogInformation("FetchOHLCV empty response");
            return [];
        }
        ohlcvList.RemoveAt(ohlcvList.Count - LastCandleIncrement);

        string outputDir = exportPathProvider.GetOutputDirectory(rootOutputDir, DateTime.UtcNow);
        Directory.CreateDirectory(outputDir);

        string csvPath = Path.Combine(outputDir, "OhlcvData.csv");
        string xlsxPath = Path.Combine(outputDir, "OhlcvData.xlsx");

        await fileExportService.ExportCsvAsync(ohlcvList, csvPath, ct);
        await fileExportService.ExportXlsxAsync(ohlcvList, xlsxPath, DateTimeConstants.DateFormat, ct);
        await repository.AddRangeAsync(ohlcvList, ct);

        logger.LogInformation("FetchOHLCV. Successfull");

        return ohlcvList;
    }
}
