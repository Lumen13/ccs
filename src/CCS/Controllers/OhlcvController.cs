using Microsoft.AspNetCore.Mvc;
using CCS.Controllers.Dto;
using CCS.Controllers.Mappers;
using CCS.Core.Interfaces;
using CCS.Core.Models;

namespace CCS.Controllers;

/// <summary>
/// Controller for working with OHLCV data
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OhlcvController(
    IOhlcvService ohlcvService
    ) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<OhlcvDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OhlcvDto>>> Get(
        string symbol = "BTC/USDT",
        string timeFrame = "30m",
        long? since = 0,
        long limit = 10,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default)
    {
        List<OhlcvModel> data = await ohlcvService.Get(symbol, timeFrame, since, limit, parameters, ct);

        return data.ToDtoList();
    }
}
