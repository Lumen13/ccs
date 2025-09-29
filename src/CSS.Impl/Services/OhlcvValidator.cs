using ccxt;
using CSS.CctxClient.Interfaces;

namespace CSS.Impl.Services;

internal sealed class OhlcvValidator : IOhlcvValidator
{
    public void ValidateOrThrow(OHLCV source)
    {
        if (!source.timestamp.HasValue || source.timestamp.Value <= 0)
        {
            throw new InvalidCastException("Invalid timestamp: must be > 0");
        }
        if (!source.open.HasValue || source.open.Value <= 0)
        {
            throw new InvalidCastException("Invalid open: must be > 0");
        }
        if (!source.high.HasValue || source.high.Value <= 0)
        {
            throw new InvalidCastException("Invalid high: must be > 0");
        }
        if (!source.low.HasValue || source.low.Value <= 0)
        {
            throw new InvalidCastException("Invalid low: must be > 0");
        }
        if (!source.close.HasValue || source.close.Value <= 0)
        {
            throw new InvalidCastException("Invalid close: must be > 0");
        }
        // volume can be null/0/>0; mapper converts null to 0
    }
}


