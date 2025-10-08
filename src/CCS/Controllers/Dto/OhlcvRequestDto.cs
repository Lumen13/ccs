using System.ComponentModel.DataAnnotations;
using CCS.Core.Constants;

namespace CCS.Controllers.Dto;

/// <summary>
/// Main request dto for fetching OHLCV data
/// </summary>
/// <param name="Days">Days count to take</param>
/// <param name="RunSingleRequest">Single request run flag (without loop)</param>
/// <param name="Symbol">Exchange symbol</param>
/// <param name="TimeFrame">Timeframe to fetch</param>
/// <param name="Limit">Maximum number of records</param>
/// <param name="Parameters">Additional parameters. For example, "interval".
public record OhlcvRequestDto(
    [Required, Range(1, int.MaxValue)] int Days,
    bool RunSingleRequest = false,
    [EnumDataType(typeof(OhlcvSymbol))] OhlcvSymbol? Symbol = null,
    string TimeFrame = "30m",
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null);
