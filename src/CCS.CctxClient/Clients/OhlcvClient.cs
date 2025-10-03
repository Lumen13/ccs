using CCS.CctxClient.Interfaces;
using CCS.CctxClient.Mappers;
using CCS.Core.Constants;
using CCS.Core.Models;
using ccxt;

namespace CCS.CctxClient.Clients;

internal sealed class OhlcvClient(IOhlcvValidator validator) : IOhlcvClient
{
    private readonly Bybit _exchange = new();

    public async Task<List<OhlcvModel>> FetchOhlcv(
        OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        DateTime? from = null,
        DateTime? to = null,
        long limit = 1000,
        Dictionary<string, object>? parameters = null
    )
    {
        List<OHLCV> ohlcvList = await _exchange.FetchOHLCV(
            symbol: symbol ?? OhlcvSymbol.Btc,
            timeframe: timeFrame,
            since2: AddSince(from, to),
            limit2: limit,
            parameters: AddParameters(parameters));

        return ohlcvList.ToModelList(validator);
    }

    private long AddSince(DateTime? from, DateTime? to)
    {
        long since = 0;
        if (from != null && to != null)
        {
            TimeSpan dateDiff = to.Value.Subtract(from.Value);
            var totalMs = (long)dateDiff.TotalMilliseconds;
            since = _exchange.milliseconds() - totalMs;
        }

        return since;
    }

    private static Dictionary<string, object> AddParameters(Dictionary<string, object>? parameters)
    {
        parameters ??= new() { { "category", "linear" } };
        parameters.TryAdd("category", "linear");

        return parameters;
    }
}
