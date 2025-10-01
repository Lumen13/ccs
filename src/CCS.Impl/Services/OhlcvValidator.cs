using System.ComponentModel.DataAnnotations;
using CCS.CctxClient.Interfaces;
using ccxt;

namespace CCS.Impl.Services;

internal sealed class OhlcvValidator : IOhlcvValidator
{
    public void ValidateOrThrow(OHLCV source)
    {
        if (!source.timestamp.HasValue || source.timestamp.Value <= 0)
        {
            throw new ValidationException("Invalid timestamp: must be > 0");
        }
        if (!source.open.HasValue || source.open.Value <= 0)
        {
            throw new ValidationException("Invalid open: must be > 0");
        }
        if (!source.high.HasValue || source.high.Value <= 0)
        {
            throw new ValidationException("Invalid high: must be > 0");
        }
        if (!source.low.HasValue || source.low.Value <= 0)
        {
            throw new ValidationException("Invalid low: must be > 0");
        }
        if (!source.close.HasValue || source.close.Value <= 0)
        {
            throw new ValidationException("Invalid close: must be > 0");
        }
    }
}


