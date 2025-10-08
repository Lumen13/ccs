using CCS.CctxClient.Interfaces;
using CCS.Core.Constants;
using CCS.Core.Interfaces;
using CCS.Core.Models;
using CCS.Core.Options;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
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

    public async Task<OhlcvModels> Get(
        int days,
        bool runSingleRequest = false,
        OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        long limit = 1000,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default
    )
    {
        logger.LogInformation("FetchOHLCV. Prepare to get data");

        OhlcvModels ohlcvModels = new();

        OhlcvDaysConstant? daysConstant = OhlcvDaysConstantCreate(runSingleRequest, timeFrame, days);
        if (daysConstant == null) return ohlcvModels;

        int daysRemains = days;
        bool firstIteration = true;
        DateTime lastTimestamp = DateTime.Now;
        while (true)
        {
            int daysToTake = daysRemains > daysConstant.MaxDays ? daysConstant.MaxDays : daysRemains;
            DateTime to = lastTimestamp;
            DateTime from = to.AddDays(-daysToTake);

            List<OhlcvModel> data = await ohlcvClient.FetchOhlcv(
                parameters: parameters,
                symbol: (symbol ?? OhlcvSymbol.Btc).ToStringValue(),
                timeFrame: timeFrame,
                from: from,
                to: to,
                limit: limit + LastCandleIncrement);
            if (firstIteration)
            {
                data.RemoveAt(data.Count - LastCandleIncrement);
                firstIteration = false;
            }
            ohlcvModels.Data.AddRange(data);

            daysRemains -= daysToTake;
            if (daysRemains == 0) break;

            lastTimestamp = data[0].Timestamp;
        }

        ohlcvModels.Min = ohlcvModels.Data.Min(x => x.Timestamp);
        ohlcvModels.Max = ohlcvModels.Data.Max(x => x.Timestamp);
        ohlcvModels.Days = days;
        ohlcvModels.Count = ohlcvModels.Data.Count;

        if (ohlcvModels.Count == 0)
        {
            logger.LogWarning("FetchOHLCV empty response");
            return ohlcvModels;
        }

        string outputDir = exportPathProvider.GetOutputDirectory(rootOutputDir, DateTime.Now);
        Directory.CreateDirectory(outputDir);

        string csvPath = Path.Combine(outputDir, "OhlcvData.csv");
        string xlsxPath = Path.Combine(outputDir, "OhlcvData.xlsx");

        await fileExportService.ExportCsvAsync(ohlcvModels, csvPath, ct);
        await fileExportService.ExportXlsxAsync(ohlcvModels, xlsxPath, DateTimeConstants.DateFormat, ct);
        await repository.AddRangeAsync(ohlcvModels, ct);

        logger.LogInformation("FetchOHLCV. Successfull");

        return ohlcvModels;
    }

    private OhlcvDaysConstant? OhlcvDaysConstantCreate(bool runSingleRequest, string timeFrame, int days)
    {
        if (runSingleRequest == false)
        {
            OhlcvDaysConstant? daysConstantValue = BybitOhlcvConstants.Values.FirstOrDefault(x => x.TimeFrame == timeFrame);
            if (daysConstantValue == null)
            {
                logger.LogWarning("FetchOHLCV. Wrong timestamp");
                return null;
            }

            return daysConstantValue;
        }
        else
        {
            return new OhlcvDaysConstant(days);
        }
    }
}
