using CCS.Core.Models;

namespace CCS.Core.Interfaces;

/// <summary>
/// Service for working with OHLCV data
/// </summary>
public interface IOhlcvService
{
    /// <summary>
    /// Main method for fetching OHLCV data
    /// </summary>
    /// <param name="request">Request model</param>
    /// <param name="ct">CancellationToken</param>
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    Task<OhlcvResponseModel> GetAsync(OhlcvRequestModel request, CancellationToken ct);
}
