using System.ComponentModel.DataAnnotations;
using CCS.Core.Constants;

namespace CCS.Controllers.Dto;

/// <summary>
/// Main request dto for fetching OHLCV data
/// </summary>
/// <param name="TimeInterval">Total interval to take (e.g., "1m","1h","2d")</param>
/// <param name="RunSingleRequest">Single request run flag (without loop)</param>
/// <param name="Symbol">Exchange symbol</param>
/// <param name="TimeFrame">Timeframe to fetch</param>
/// <param name="Limit">Maximum number of records</param>
/// <param name="Parameters">Additional parameters. For example, "interval".
public record OhlcvRequestDto(
    [Required, RegularExpression(@"^\d+(m|h|d)$")] string TimeInterval,
    bool RunSingleRequest = false,
    [EnumDataType(typeof(OhlcvSymbol))] OhlcvSymbol? Symbol = null,
    string TimeFrame = "30m",
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null);
