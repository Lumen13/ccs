namespace CCS.Core.Models;

/// <summary>
/// <see cref="OhlcvModel"/> with counter
/// </summary>
public class OhlcvModels(List<OhlcvModel>? data = null, DateTime? min = null, DateTime? max = null, int days = 0, int count = 0)
{
    /// <summary>
    /// Data list
    /// </summary>
    public List<OhlcvModel> Data { get; set; } = data ?? [];

    /// <summary>
    /// Min data timestamp
    /// </summary>
    public DateTime Min { get; set; } = min ?? DateTime.MinValue;

    /// <summary>
    /// Max data timestamp
    /// </summary>
    public DateTime Max { get; set; } = max ?? DateTime.MaxValue;

    /// <summary>
    /// Days taked
    /// </summary>
    public int Days { get; set; } = days;

    /// <summary>
    /// Data records count
    /// </summary>
    public int Count { get; set; } = count;
}

/// <summary>
/// Domain OHLCV model (non-nullable)
/// </summary>
public struct OhlcvModel(
    DateTime timestamp,
    double open,
    double close,
    double high,
    double low,
    double volume)
{
    public DateTime Timestamp { get; set; } = timestamp;
    public double Open { get; set; } = open;
    public double Close { get; set; } = close;
    public double High { get; set; } = high;
    public double Low { get; set; } = low;
    public double Volume { get; set; } = volume;
}