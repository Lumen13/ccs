using ccxt;

namespace CSS.CctxClient.Interfaces;

/// <summary>
/// Validator for incoming OHLCV data from ccxt
/// </summary>
public interface IOhlcvValidator
{
    /// <summary>
    /// Validate ccxt OHLCV input and throw if invalid.
    /// Rules: timestamp > 0; open/high/low/close > 0; volume can be 0 or >0.
    /// </summary>
    /// <exception cref="InvalidCastException">Thrown when any required field is invalid</exception>
    void ValidateOrThrow(OHLCV source);
}


