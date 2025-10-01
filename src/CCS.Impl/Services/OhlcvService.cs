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

    /// <summary>
    /// Retrieve OHLCV data
    /// </summary>
    /// <param name="symbol">Exchange symbol (e.g., BTC/USDT)</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="since">Starting point "since" (approximation)</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    public async Task<List<OhlcvModel>> Get(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default
    )
    {
        logger.LogInformation("FetchOHLCV. Prepare to get data");

        List<OhlcvModel> ohlcvList = await ohlcvClient.FetchOHLCV(
            parameters: parameters,
            symbol: symbol,
            timeFrame: timeFrame,
            since: since,
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
