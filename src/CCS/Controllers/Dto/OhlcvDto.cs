namespace CCS.Controllers.Dto;

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
