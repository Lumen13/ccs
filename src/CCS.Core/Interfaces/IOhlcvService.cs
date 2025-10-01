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
    /// <param name="symbol">Exchange symbol</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="since">Starting point "since" (approximation)</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    Task<List<OhlcvModel>> Get(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default);
}
