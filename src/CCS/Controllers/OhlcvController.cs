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

    /// <summary>
    /// Execute OHLCV fetch across all known timeframes sequentially
    /// </summary>
    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<OhlcvResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<OhlcvResponseDto>>> GetAll([FromQuery] AllOhlcvRequestDto request, CancellationToken ct = default)
    {
        AllOhlcvRequestModel baseModel = request.ToAllOhlcvRequestModel();

        List<OhlcvResponseDto> results = new();
        foreach (var tf in CctxClient.Constants.BybitOhlcvConstants.Values.Select(v => v.TimeFrame))
        {
            OhlcvRequestModel single = new(
                baseModel.TimeInterval,
                baseModel.RunSingleRequest,
                baseModel.Symbol,
                tf,
                baseModel.Limit,
                baseModel.Parameters);

            OhlcvResponseModel response = await ohlcvService.GetAsync(single, ct);
            results.Add(response.ToOhlcvResponseDto());
        }

        return Ok(results);
    }
}
