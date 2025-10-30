using CCS.Core.Constants;
using CCS.Core.Interfaces;

namespace CCS.Core.Models;

/// <summary>
/// Request model for <see cref="IOhlcvService"/>
/// </summary>
/// <param name="TimeInterval">Total interval to take (e.g., "1m","1h","2d")</param>
/// <param name="RunSingleRequest">Single request run flag (without loop)</param>
/// <param name="Symbol">Exchange symbol</param>
/// <param name="TimeFrame">Timeframe to fetch</param>
/// <param name="Limit">Maximum number of records</param>
/// <param name="Parameters">Additional parameters. For example, "interval".
/// <param name="Ct">CancellationToken</param>
public record OhlcvRequestModel(
    string TimeInterval,
    bool RunSingleRequest = false,
    OhlcvSymbol? Symbol = null,
    string TimeFrame = "30m",
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null);

