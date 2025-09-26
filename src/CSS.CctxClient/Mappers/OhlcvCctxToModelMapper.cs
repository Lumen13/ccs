using ccxt;
using CSS.CctxClient.Models;

namespace CSS.CctxClient.Mappers;

/// <summary>
/// Ohlcv маппер
/// </summary>
public static class OhlcvCctxToModelMapper
{
    public static OhlcvModel ToModel(this OHLCV ohlcv)
    {
        OhlcvModel ohlcvDto = new(
            timestamp: ohlcv.timestamp,
            open: ohlcv.open,
            close: ohlcv.close,
            high: ohlcv.high,
            low: ohlcv.low,
            volume: ohlcv.volume);

        return ohlcvDto;
    }

    public static List<OhlcvModel> ToModelList(this List<OHLCV> ohlcvList)
    {
        List<OhlcvModel> ohlcvModelList = [.. ohlcvList.Select(ToModel)];

        return ohlcvModelList;
    }
}
