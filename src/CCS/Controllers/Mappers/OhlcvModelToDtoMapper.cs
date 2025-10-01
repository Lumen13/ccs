using CCS.Controllers.Dto;
using CCS.Core.Models;

namespace CCS.Controllers.Mappers;

/// <summary>
/// OHLCV mapper: Model -> DTO
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
