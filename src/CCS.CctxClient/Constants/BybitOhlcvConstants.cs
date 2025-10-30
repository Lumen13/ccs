namespace CCS.CctxClient.Constants;

/// <summary>
/// Ohlcv value which identify the number of possible records received for a certain number of days
/// </summary>
public static class BybitOhlcvConstants
{
    public static readonly IReadOnlyCollection<OhlcvIntervalConstant> Values = [
        new OhlcvIntervalConstant("30m", "20d", 959)
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
