using CCS.CctxClient.Constants;
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

    public async Task<OhlcvResponseModel> GetAsync(OhlcvRequestModel request, CancellationToken ct)
    {
        logger.LogInformation("FetchOHLCV. Prepare to get data");

        OhlcvDaysConstant? daysConstant = OhlcvDaysConstantCreate(request.RunSingleRequest, request.TimeFrame, request.Days);
        if (daysConstant == null) return new();

        OhlcvResponseModel? response = await FetchOhlcvAsync(request, daysConstant);
        if (response == null) return new();

        await ExportDataToFileAsync(response, ct);
        await repository.AddRangeAsync(response, ct);

        logger.LogInformation("FetchOHLCV. Successfull");

        return response;
    }

    private async Task ExportDataToFileAsync(OhlcvResponseModel response, CancellationToken ct)
    {
        string outputDir = exportPathProvider.GetOutputDirectory(rootOutputDir, DateTime.Now);
        Directory.CreateDirectory(outputDir);

        string csvPath = Path.Combine(outputDir, "OhlcvData.csv");
        string xlsxPath = Path.Combine(outputDir, "OhlcvData.xlsx");

        await fileExportService.ExportCsvAsync(response, csvPath, ct);
        await fileExportService.ExportXlsxAsync(response, xlsxPath, DateTimeConstants.DateFormat, ct);
    }

    private async Task<OhlcvResponseModel?> FetchOhlcvAsync(OhlcvRequestModel request, OhlcvDaysConstant daysConstant)
    {
        OhlcvResponseModel response = new();
        int daysRemains = request.Days;
        bool firstIteration = true;
        DateTime lastTimestamp = DateTime.Now;
        while (true)
        {
            int daysToTake = daysRemains > daysConstant.MaxDays ? daysConstant.MaxDays : daysRemains;
            DateTime to = lastTimestamp;
            DateTime from = to.AddDays(-daysToTake);

            List<OhlcvModel> data = await ohlcvClient.FetchOhlcvAsync(
                parameters: request.Parameters,
                symbol: (request.Symbol ?? OhlcvSymbol.Btc).ToStringValue(),
                timeFrame: request.TimeFrame,
                from: from,
                to: to,
                limit: request.Limit + LastCandleIncrement);
            if (firstIteration)
            {
                data.RemoveAt(data.Count - LastCandleIncrement);
                firstIteration = false;
            }
            response.Data.AddRange(data);

            daysRemains -= daysToTake;
            if (daysRemains == 0) break;

            lastTimestamp = data[0].Timestamp;
        }

        response.Min = response.Data.Min(x => x.Timestamp);
        response.Max = response.Data.Max(x => x.Timestamp);
        response.Days = request.Days;
        response.Count = response.Data.Count;

        if (response.Count == 0) logger.LogWarning("FetchOHLCV empty response");

        return response.Count == 0 ? null : response;
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
