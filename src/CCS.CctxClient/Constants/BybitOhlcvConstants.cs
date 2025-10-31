namespace CCS.CctxClient.Constants;

/// <summary>
/// Ohlcv value which identify the number of possible records received for a certain number of days
/// </summary>
public static class BybitOhlcvConstants
{
    public static readonly IReadOnlyCollection<OhlcvIntervalConstant> Values = [
        new OhlcvIntervalConstant("30m", "20d", 959),
        new OhlcvIntervalConstant("1m", "16h", 959),
        new OhlcvIntervalConstant("3m", "2d", 959),
        new OhlcvIntervalConstant("5m", "3d", 863),
        new OhlcvIntervalConstant("15m", "10d", 959),
        new OhlcvIntervalConstant("1h", "40d", 959),
        new OhlcvIntervalConstant("2h", "80d", 959),
        new OhlcvIntervalConstant("4h", "160d", 959),
        new OhlcvIntervalConstant("6h", "240d", 959),
        new OhlcvIntervalConstant("12h", "480d", 959),
        new OhlcvIntervalConstant("1d", "995d", 994)
        ];
}

/// <summary>
/// Ohlcv record with data in context of Days-Timeframe-Count
/// </summary>
public sealed record OhlcvIntervalConstant
{
    public OhlcvIntervalConstant(string timeFrame, string maxInterval, int maxRecords)
    {
        MaxInterval = maxInterval;
        TimeFrame = timeFrame;
        MaxRecords = maxRecords;
    }

    public OhlcvIntervalConstant(string maxInterval)
    {
        MaxInterval = maxInterval;
        TimeFrame = string.Empty;
        MaxRecords = int.MaxValue;
    }

    public string TimeFrame { get; init; }
    public string MaxInterval { get; init; }
    public int MaxRecords { get; init; }
}
