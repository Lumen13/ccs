using ccxt;
using CCS.CctxClient.Interfaces;
using CCS.CctxClient.Mappers;
using CCS.Core.Models;

namespace CCS.CctxClient.Clients;

internal sealed class OhlcvClient : IOhlcvClient
{
    private readonly Bybit _exchange = new();
    private readonly IOhlcvValidator _validator;

    public OhlcvClient(IOhlcvValidator validator)
    {
        _validator = validator;
    }

    public async Task<List<OhlcvModel>> FetchOHLCV(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null
    )
    {
        if (parameters == null)
        {
            parameters = new() { { "category", "linear" } };
        }
        else
        {
            parameters.TryAdd("category", "linear");
        }

        List<OHLCV> ohlcvList = await _exchange.FetchOHLCV(
            symbol: symbol,
            timeframe: timeFrame,
            since2: since,
            limit2: limit,
            parameters: parameters);

        return ohlcvList.ToModelList(_validator);
    }
}
