namespace CCS.Controllers.Dto;

/// <summary>
/// DTO Ohlcv candle
/// </summary>
public readonly record struct OhlcvDto
{
    public OhlcvDto(
        long? timestamp,
        double? open,
        double? close,
        double? high,
        double? low,
        double? volume)
    {
        Timestamp = timestamp;
        Open = open;
        Close = close;
        High = high;
        Low = low;
        Volume = volume;
    }

    /// <summary>
    /// Время 
    /// </summary>
    public long? Timestamp { get; init; }

    /// <summary>
    /// Сумма на момент открытия Body
    /// </summary>
    public double? Open { get; init; }

    /// <summary>
    /// Сумма на момент закрытия Body
    /// </summary>
    public double? Close { get; init; }

    /// <summary>
    /// Предельная достигнутая сумма Wiki
    /// </summary>
    public double? High { get; init; }

    /// <summary>
    /// Минимальная достигнутая сумма Wiki
    /// </summary>
    public double? Low { get; init; }

    /// <summary>
    /// Кол-во сделок в рамках текущей candle (НЕ ТОЧНО)
    /// </summary>
    public double? Volume { get; init; }
}
