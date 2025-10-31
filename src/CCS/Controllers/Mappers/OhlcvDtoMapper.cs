using CCS.Controllers.Dto;
using CCS.Core.Models;

namespace CCS.Controllers.Mappers;

/// <summary>
/// OHLCV mapper: Model -> DTO
/// </summary>
public static class OhlcvDtoMapper
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

    public static OhlcvRequestModel ToOhlcvRequestModel(this OhlcvRequestDto dto)
    {
        OhlcvRequestModel model = new(
            dto.TimeInterval,
            dto.RunSingleRequest,
            dto.Symbol,
            dto.TimeFrame,
            dto.Limit,
            dto.Parameters);

        return model;
    }

    public static AllOhlcvRequestModel ToAllOhlcvRequestModel(this AllOhlcvRequestDto dto)
    {
        AllOhlcvRequestModel model = new(
            dto.TimeInterval,
            dto.RunSingleRequest,
            dto.Symbol,
            dto.Limit,
            dto.Parameters);

        return model;
    }

    public static OhlcvResponseDto ToOhlcvResponseDto(this OhlcvResponseModel model)
    {
        OhlcvResponseDto ohlcvDtoList = new(
            model.Data.ToDtoList(),
            model.Min,
            model.Max,
            model.TimeInterval,
            model.Count);

        return ohlcvDtoList;
    }
}
