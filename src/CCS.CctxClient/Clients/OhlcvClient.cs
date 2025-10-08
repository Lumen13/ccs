using CCS.CctxClient.Interfaces;
using CCS.CctxClient.Mappers;
using CCS.Core.Constants;
using CCS.Core.Models;
using ccxt;

namespace CCS.CctxClient.Clients;

internal sealed class OhlcvClient(IOhlcvValidator validator) : IOhlcvClient
{
    private readonly Bybit _exchange = new();

    public async Task<List<OhlcvModel>> FetchOhlcvAsync(
        DateTime from,
        DateTime to,
        string symbol = OhlcvSymbolConstants.Btc,
        string timeFrame = "30m",
        long limit = 1000,
        Dictionary<string, object>? parameters = null
    )
    {
        List<OHLCV> ohlcvList = await _exchange.FetchOHLCV(
            symbol: symbol,
            timeframe: timeFrame,
            since2: AddSince(from, to),
            limit2: limit,
            parameters: AddParameters(parameters));

        return ohlcvList.ToModelList(validator);
    }

    private long AddSince(DateTime from, DateTime to)
    {
        TimeSpan dateDiff = to.Subtract(from);
        var totalMs = (long)dateDiff.TotalMilliseconds;
        long since = _exchange.milliseconds() - totalMs;

        return since;
    }

    private static Dictionary<string, object> AddParameters(Dictionary<string, object>? parameters)
    {
        parameters ??= new() { { "category", "linear" } };
        parameters.TryAdd("category", "linear");

        return parameters;
    }
}
