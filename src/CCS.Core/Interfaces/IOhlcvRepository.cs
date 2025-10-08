using CCS.Core.Models;

namespace CCS.Core.Interfaces;

/// <summary>
/// Repository abstraction for persisting OHLCV data
/// </summary>
public interface IOhlcvRepository
{
    /// <summary>
    /// Persist OHLCV data-list to the database
    /// </summary>
    /// <param name="data">OHLCV data-list</param>
    /// <param name="ct">CancellationToken</param>
    Task AddRangeAsync(OhlcvResponseModel ohlcvModels, CancellationToken ct = default);
}
