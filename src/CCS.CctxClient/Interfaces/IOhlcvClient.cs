using CCS.Core.Constants;
using CCS.Core.Models;

namespace CCS.CctxClient.Interfaces;

/// <summary>
/// Cctx client for working with OHLCV data
/// </summary>
public interface IOhlcvClient
{
    /// <summary>
    /// Main method for fetching OHLCV data
    /// </summary>
    /// <param name="from">Starting "since" date</param>
    /// <param name="to">Ending "since" date</param>
    /// <param name="symbol">Exchange symbol</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    Task<List<OhlcvModel>> FetchOhlcvAsync(
        DateTime from,
        DateTime to,
        string symbol = OhlcvSymbolConstants.Btc,
        string timeFrame = "30m",
        long limit = 1000,
        Dictionary<string, object>? parameters = null
    );
}
