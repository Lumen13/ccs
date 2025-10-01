using CCS.Core.Entities;
using CCS.Core.Models;

namespace CCS.Infr.Mappers;

/// <summary>
/// OHLCV mapper: Model -> Entity
/// </summary>
public static class OhlcvModelToEntityMapper
{
    public static OhlcvEntity ToEntity(this OhlcvModel model)
    {
        DateTime timestampUtc = model.Timestamp;
        OhlcvEntity entity = new()
        {
            Timestamp = timestampUtc,
            Open = model.Open,
            Close = model.Close,
            High = model.High,
            Low = model.Low,
            Volume = model.Volume
        };

        return entity;
    }

    public static List<OhlcvEntity> ToEntityList(this IEnumerable<OhlcvModel> models)
    {
        List<OhlcvEntity> entities = [.. models.Select(ToEntity)];
        return entities;
    }
}


