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
/// OhlcvSymbol enum for type safety and Scalar dropdown
/// </summary>
public enum OhlcvSymbol
{
    /// <summary>
    /// Bitcoin/USDT symbol
    /// </summary>
    Btc,
    
    /// <summary>
    /// Solana/USDT symbol
    /// </summary>
    Sol,
    
    /// <summary>
    /// Ethereum/USDT symbol
    /// </summary>
    Eth
}

/// <summary>
/// Extension methods for OhlcvSymbol enum
/// </summary>
public static class OhlcvSymbolExtensions
{
    public static string ToStringValue(this OhlcvSymbol symbol) => symbol switch
    {
        OhlcvSymbol.Btc => OhlcvSymbolConstants.Btc,
        OhlcvSymbol.Sol => OhlcvSymbolConstants.Sol,
        OhlcvSymbol.Eth => OhlcvSymbolConstants.Eth,
        _ => throw new ArgumentException("Unknown symbol")
    };
    
    public static OhlcvSymbol FromStringValue(string value) => value switch
    {
        OhlcvSymbolConstants.Btc => OhlcvSymbol.Btc,
        OhlcvSymbolConstants.Sol => OhlcvSymbol.Sol,
        OhlcvSymbolConstants.Eth => OhlcvSymbol.Eth,
        _ => throw new ArgumentException($"Unknown symbol: {value}")
    };
}

