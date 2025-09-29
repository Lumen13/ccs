using CCS.Controllers.Dto;
using CSS.Core.Models;

namespace CCS.Controllers.Mappers;

/// <summary>
/// Ohlcv маппер
/// </summary>
public static class OhlcvModelToDtoMapper
{
    public static OhlcvDto ToDto(this OhlcvModel ohlcv)
    {
        OhlcvDto ohlcvDto = new(
            timestamp: ohlcv.Timestamp,
            open: ohlcv.Open,
            close: ohlcv.Close,
            high: ohlcv.High,
            low: ohlcv.Low,
            volume: ohlcv.Volume);

        return ohlcvDto;
    }

    public static List<OhlcvDto> ToDtoList(this List<OhlcvModel> ohlcvList)
    {
        List<OhlcvDto> ohlcvModelList = [.. ohlcvList.Select(ToDto)];

        return ohlcvModelList;
    }
}
