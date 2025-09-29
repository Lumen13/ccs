using ccxt;
using CSS.Core.Models;
using CSS.CctxClient.Interfaces;

namespace CSS.CctxClient.Mappers;

/// <summary>
/// Ohlcv маппер
/// </summary>
public static class OhlcvCctxToModelMapper
{
    public static OhlcvModel ToModel(this OHLCV ohlcv, IOhlcvValidator validator)
    {
        validator.ValidateOrThrow(ohlcv);

        long timestamp = ohlcv.timestamp!.Value;
        double open = ohlcv.open!.Value;
        double close = ohlcv.close!.Value;
        double high = ohlcv.high!.Value;
        double low = ohlcv.low!.Value;
        double volume = ohlcv.volume ?? 0d;

        OhlcvModel ohlcvDto = new(
            timestamp: timestamp,
            open: open,
            close: close,
            high: high,
            low: low,
            volume: volume);

        return ohlcvDto;
    }

    public static List<OhlcvModel> ToModelList(this List<OHLCV> ohlcvList, IOhlcvValidator validator)
    {
        List<OhlcvModel> ohlcvModelList = [.. ohlcvList.Select(x => x.ToModel(validator))];

        return ohlcvModelList;
    }
}
