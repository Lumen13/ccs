namespace CCS.Core.Constants;

/// <summary>
/// OhlcvSymbol constants. Identifies different types of coins
/// </summary>
public static class OhlcvSymbolConstants
{
    public const string Btc = "BTC/USDT";
    public const string Sol = "SOL/USDT";
    public const string Eth = "ETH/USDT";
}

/// <summary>
/// OhlcvSymbol record-based enum for type safety and Swagger dropdown
/// </summary>
public record OhlcvSymbol(string Value)
{
    public static readonly OhlcvSymbol Btc = new(OhlcvSymbolConstants.Btc);
    public static readonly OhlcvSymbol Sol = new(OhlcvSymbolConstants.Sol);
    public static readonly OhlcvSymbol Eth = new(OhlcvSymbolConstants.Eth);
    
    public static implicit operator string(OhlcvSymbol symbol) => symbol.Value;
    public static implicit operator OhlcvSymbol(string value) => new(value);
}

