using CCS.Core.Constants;
using CCS.Core.Models;

namespace CCS.Core.Interfaces;

/// <summary>
/// Service for working with OHLCV data
/// </summary>
public interface IOhlcvService
{
    /// <summary>
    /// Main method for fetching OHLCV data
    /// </summary>
    /// <param name="days">Days count to take</param>
    /// <param name="runSingleRequest">Single request run flag (without loop)</param>
    /// <param name="symbol">Exchange symbol</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    Task<OhlcvModels> Get(
        int days,
        bool runSingleRequest = false,
        OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        long limit = 1000,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default);
}
