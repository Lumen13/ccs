using CCS.Core.Constants;

namespace CCS.Core.Models;

public record BaseOhlcvRequestModel(
    string TimeInterval,
    bool RunSingleRequest = false,
    OhlcvSymbol? Symbol = null,
    long Limit = 1000,
    Dictionary<string, object>? Parameters = null);


