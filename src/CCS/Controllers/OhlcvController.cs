using CCS.Controllers.Dto;
using CCS.Controllers.Mappers;
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
    /// <param name="request">Request dto</param>
    /// Parameter "category" ("linear") is required to obtain correct information</param>
    /// <returns>List of OHLCV models</returns>
    [HttpGet]
    [ProducesResponseType(typeof(OhlcvResponseDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<OhlcvResponseDto>> Get([FromQuery] OhlcvRequestDto request, CancellationToken ct = default)
    {
        OhlcvResponseModel ohlcvModels = await ohlcvService.GetAsync(request.ToOhlcvRequestModel(), ct);

        return ohlcvModels.ToOhlcvResponseDto();
    }
}
