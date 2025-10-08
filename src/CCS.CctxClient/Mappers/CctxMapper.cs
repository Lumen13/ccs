using CCS.CctxClient.Interfaces;
using CCS.Core.Models;
using ccxt;

namespace CCS.CctxClient.Mappers;

/// <summary>
/// Ohlcv маппер
/// </summary>
public static class CctxMapper
{
    public static OhlcvModel ToModel(this OHLCV ohlcv, IOhlcvValidator validator)
    {
        validator.ValidateOrThrow(ohlcv);

        DateTime timestamp = DateTime.UnixEpoch.AddMilliseconds(ohlcv.timestamp!.Value).ToLocalTime();
        double open = ohlcv.open!.Value;
        double close = ohlcv.close!.Value;
        double high = ohlcv.high!.Value;
        double low = ohlcv.low!.Value;
        double volume = ohlcv.volume ?? 0d;

        OhlcvModel ohlcvModel = new(
            timestamp: timestamp,
            open: open,
            close: close,
            high: high,
            low: low,
            volume: volume);

        return ohlcvModel;
    }

    public static List<OhlcvModel> ToModelList(this List<OHLCV> ohlcvList, IOhlcvValidator validator)
    {
        List<OhlcvModel> ohlcvModelList = [.. ohlcvList.Select(x => x.ToModel(validator))];

        return ohlcvModelList;
    }
}
