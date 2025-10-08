using System.ComponentModel.DataAnnotations;
using CCS.Controllers.Dto;
using CCS.Controllers.Mappers;
using CCS.Core.Constants;
using CCS.Core.Interfaces;
using CCS.Core.Models;
using Microsoft.AspNetCore.Mvc;

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
    /// <param name="days">Days count to take</param>
    /// <param name="runSingleRequest">Single request run flag (without loop)</param>
    /// <param name="symbol">Exchange symbol</param>
    /// <param name="timeFrame">Timeframe to fetch</param>
    /// <param name="limit">Maximum number of records</param>
    /// <param name="parameters">Additional parameters. For example, "interval".
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    [HttpGet]
    [ProducesResponseType(typeof(OhlcvDtoList), StatusCodes.Status200OK)]
    public async Task<ActionResult<OhlcvDtoList>> Get(
        [Required, Range(1, int.MaxValue)] int days,
        bool runSingleRequest = false,
        [FromQuery][EnumDataType(typeof(OhlcvSymbol))] OhlcvSymbol? symbol = null,
        string timeFrame = "30m",
        long limit = 1000,
        Dictionary<string, object>? parameters = null,
        CancellationToken ct = default)
    {
        OhlcvModels ohlcvModels = await ohlcvService.Get(days, runSingleRequest, symbol, timeFrame, limit, parameters, ct);

        return ohlcvModels.ToOhlcvDtoList();
    }
}
