namespace CCS.Controllers.Dto;

/// <summary>
/// DTO for an OHLCV candle
/// </summary>
public record OhlcvDtoList
{
    public OhlcvDtoList(List<OhlcvDto> data, DateTime min, DateTime max, int days, int count)
    {
        Data = data;
        Min = min;
        Max = max;
        Days = days;
        Count = count;
    }

    /// <summary>
    /// Data list
    /// </summary>
    public List<OhlcvDto> Data { get; init; }

    /// <summary>
    /// Min data timestamp
    /// </summary>
    public DateTime Min { get; init; }

    /// <summary>
    /// Max data timestamp
    /// </summary>
    public DateTime Max { get; init; }

    /// <summary>
    /// Days taked
    /// </summary>
    public int Days { get; init; }

    /// <summary>
    /// Data records count
    /// </summary>
    public int Count { get; init; }
}

/// <summary>
/// DTO for an OHLCV candle
/// </summary>
public readonly record struct OhlcvDto
{
    public OhlcvDto(
        DateTime timestamp,
        double open,
        double close,
        double high,
        double low,
        double volume)
    {
        Timestamp = timestamp;
        Open = open;
        Close = close;
        High = high;
        Low = low;
        Volume = volume;
    }

    /// <summary>
    /// Timestamp
    /// </summary>
    public DateTime Timestamp { get; init; }

    /// <summary>
    /// Open price
    /// </summary>
    public double Open { get; init; }

    /// <summary>
    /// Close price
    /// </summary>
    public double Close { get; init; }

    /// <summary>
    /// Highest price during the interval
    /// </summary>
    public double High { get; init; }

    /// <summary>
    /// Lowest price during the interval
    /// </summary>
    public double Low { get; init; }

    /// <summary>
    /// Traded volume during the interval (approximation)
    /// </summary>
    public double Volume { get; init; }
}