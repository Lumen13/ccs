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

        OhlcvIntervalConstant? intervalConstant = OhlcvIntervalConstantCreate(request.RunSingleRequest, request.TimeFrame, request.TimeInterval);
        if (intervalConstant == null) return new();

        OhlcvResponseModel? response = await FetchOhlcvAsync(request, intervalConstant);
        if (response == null) return new();

        await ExportDataToFileAsync(response, request.TimeFrame, request.RunSingleRequest, ct);
        await repository.AddRangeAsync(request.TimeFrame, request.RunSingleRequest, response, ct);

        logger.LogInformation("FetchOHLCV. Successfull");

        return response;
    }

    private async Task ExportDataToFileAsync(OhlcvResponseModel response, string timeFrame, bool runSingleRequest, CancellationToken ct)
    {
        // Skip export if single request or timeframe is not known in constants
        if (runSingleRequest || BybitOhlcvConstants.Values.All(v => v.TimeFrame != timeFrame))
        {
            return;
        }

        string outputDir = rootOutputDir;
        Directory.CreateDirectory(outputDir);

        string csvPath = Path.Combine(outputDir, $"ohlcv_{timeFrame}.csv");
        string xlsxPath = Path.Combine(outputDir, "ohlcv.xlsx");

        await fileExportService.ExportCsvAsync(response, csvPath, ct);
        await fileExportService.ExportXlsxAsync(
            response,
            xlsxPath,
            timeFrame,
            DateTimeConstants.DateFormat,
            BybitOhlcvConstants.Values.Select(v => v.TimeFrame),
            ct);
    }

    private async Task<OhlcvResponseModel?> FetchOhlcvAsync(OhlcvRequestModel request, OhlcvIntervalConstant intervalConstant)
    {
        OhlcvResponseModel response = new();
        TimeSpan totalInterval = ParseInterval(request.TimeInterval);
        TimeSpan remain = totalInterval;
        bool firstIteration = true;
        DateTime lastTimestamp = DateTime.Now;
        while (true)
        {
            TimeSpan maxChunk = ParseInterval(intervalConstant.MaxInterval);
            TimeSpan take = remain > maxChunk ? maxChunk : remain;
            DateTime to = lastTimestamp;
            DateTime from = to - take;

            List<OhlcvModel> data = await ohlcvClient.FetchOhlcvAsync(
                parameters: request.Parameters,
                symbol: (request.Symbol ?? OhlcvSymbol.Btc).ToStringValue(),
                timeFrame: request.TimeFrame,
                from: from,
                to: to,
                limit: request.Limit + LastCandleIncrement);
            if (firstIteration)
            {
                if (data.Count >= LastCandleIncrement)
                {
                    data.RemoveAt(data.Count - LastCandleIncrement);
                }
                firstIteration = false;
            }

            if (data.Count == 0)
            {
                break;
            }

            response.Data.AddRange(data);

            remain -= take;
            if (remain <= TimeSpan.Zero) break;

            lastTimestamp = data[0].Timestamp;
        }

        if (response.Data.Count > 0)
        {
            response.Min = response.Data.Min(x => x.Timestamp);
            response.Max = response.Data.Max(x => x.Timestamp);
        }
        response.TimeInterval = request.TimeInterval;
        response.Count = response.Data.Count;

        if (response.Count == 0) logger.LogWarning("FetchOHLCV empty response");

        return response;
    }

    private OhlcvIntervalConstant? OhlcvIntervalConstantCreate(bool runSingleRequest, string timeFrame, string interval)
    {
        if (runSingleRequest == false)
        {
            OhlcvIntervalConstant? value = BybitOhlcvConstants.Values.FirstOrDefault(x => x.TimeFrame == timeFrame);
            if (value == null)
            {
                logger.LogWarning("FetchOHLCV. Wrong timestamp");
                return null;
            }

            return value;
        }
        else
        {
            return new OhlcvIntervalConstant(interval);
        }
    }

    private static TimeSpan ParseInterval(string interval)
    {
        if (string.IsNullOrWhiteSpace(interval)) throw new ArgumentException("timeInterval is empty");
        interval = interval.Trim().ToLowerInvariant();
        int num = int.Parse(new string(interval.TakeWhile(char.IsDigit).ToArray()));
        char unit = interval[^1];
        return unit switch
        {
            'm' => TimeSpan.FromMinutes(num),
            'h' => TimeSpan.FromHours(num),
            'd' => TimeSpan.FromDays(num),
            _ => throw new ArgumentException($"Unsupported interval unit: {unit}")
        };
    }
}
