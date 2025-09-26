using CCS.Controllers.Dto;
using CCS.Controllers.Mappers;
using CSS.CctxClient.Models;
using CSS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CCS.Controllers;

/// <summary>
/// Контроллер для работы с Ohlcv
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
        Dictionary<string, object>? parameters = null)
    {
        List<OhlcvModel> data = await ohlcvService.Get();

        return data.ToDtoList();
    }
}
