using System.ComponentModel.DataAnnotations;
using CCS.Core.Constants;

namespace CCS.Controllers.Dto;

/// <summary>
/// Base request dto for OHLCV (common fields)
/// </summary>
public record BaseOhlcvRequestDto(
    [Required, RegularExpression(@"^\d+(m|h|d)$")] string TimeInterval,
    bool RunSingleRequest = false,
    [EnumDataType(typeof(OhlcvSymbol))] OhlcvSymbol? Symbol = null,
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null);


