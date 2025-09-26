namespace CSS.CctxClient.Models;

/// <summary>
/// Модель Ohlcv
/// </summary>
public struct OhlcvModel
{
    public OhlcvModel(
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
    public long? Timestamp { get; set; }

    /// <summary>
    /// Сумма на момент открытия Body
    /// </summary>
    public double? Open { get; set; }

    /// <summary>
    /// Сумма на момент закрытия Body
    /// </summary>
    public double? Close { get; set; }

    /// <summary>
    /// Предельная достигнутая сумма Wiki
    /// </summary>
    public double? High { get; set; }

    /// <summary>
    /// Минимальная достигнутая сумма Wiki
    /// </summary>
    public double? Low { get; set; }

    /// <summary>
    /// Кол-во сделок в рамках текущей candle (НЕ ТОЧНО)
    /// </summary>
    public double? Volume { get; set; }
}
