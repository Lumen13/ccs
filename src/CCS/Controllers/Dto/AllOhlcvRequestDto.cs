namespace CCS.Controllers.Dto;

/// <summary>
/// Request dto for GET api/Ohlcv/all (executes across all known timeframes)
/// </summary>
public record AllOhlcvRequestDto(
    string TimeInterval,
    bool RunSingleRequest = false,
    Core.Constants.OhlcvSymbol? Symbol = null,
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null) : BaseOhlcvRequestDto(TimeInterval, RunSingleRequest, Symbol, Limit, Parameters);


