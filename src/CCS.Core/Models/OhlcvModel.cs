namespace CCS.Core.Models;

/// <summary>
/// Domain OHLCV model (non-nullable)
/// </summary>
public struct OhlcvModel
{
    public OhlcvModel(
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

    public DateTime Timestamp { get; set; }
    public double Open { get; set; }
    public double Close { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Volume { get; set; }
}


