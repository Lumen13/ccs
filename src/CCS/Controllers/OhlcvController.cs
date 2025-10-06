using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using CCS.Controllers.Dto;
using CCS.Controllers.Mappers;
using CCS.Core.Constants;
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
    /// <summary>
    /// Main method for fetching OHLCV data
    /// </summary>
    /// <param name="symbol">Exchange symbol</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="from">Starting "since" date</param>
    /// <param name="to">Ending "since" date</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<OhlcvDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OhlcvDto>>> Get(
        [FromQuery] 
        [EnumDataType(typeof(OhlcvSymbol))]
        OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        DateTime? from = null,
        DateTime? to = null,
        long limit = 1000,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default)
    {
        List<OhlcvModel> data = await ohlcvService.Get(symbol, timeFrame, from, to, limit, parameters, ct);

        return data.ToDtoList();
    }
}
