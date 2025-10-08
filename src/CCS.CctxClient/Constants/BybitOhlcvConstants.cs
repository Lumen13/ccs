namespace CCS.Core.Constants;

/// <summary>
/// Ohlcv value which identify the number of possible records received for a certain number of days
/// </summary>
public static class BybitOhlcvConstants
{
    public static readonly IReadOnlyCollection<OhlcvDaysConstant> Values = [
        new OhlcvDaysConstant("30m", 20, 959)
        ];
}

/// <summary>
/// Ohlcv record with data in context of Days-Timeframe-Count
/// </summary>
public sealed record OhlcvDaysConstant
{
    public OhlcvDaysConstant(string timeFrame, int maxDays, int maxRecords)
    {
        MaxDays = maxDays;
        TimeFrame = timeFrame;
        MaxRecords = maxRecords;
    }

    public OhlcvDaysConstant(int maxDays)
    {
        MaxDays = maxDays;
        TimeFrame = string.Empty;
        MaxRecords = int.MaxValue;
    }

    public string TimeFrame { get; init; }
    public int MaxDays { get; init; }
    public int MaxRecords { get; init; }
}
