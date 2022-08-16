using GeoApi.Application;
using GeoApi.Domain.ValueObjets;
using GeoApi.WebApi.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public partial class EarthController : ControllerBase
{
    private readonly ILogger<EarthController> _logger;
    private readonly IEarthCalculationApplicationService _earthCalculationApplicationService;

    public EarthController(
        ILogger<EarthController> logger,
        IEarthCalculationApplicationService earthCalculationApplicationService)
    {
        _logger = logger;
        _earthCalculationApplicationService = earthCalculationApplicationService;
    }

    /// <summary>
    /// Returns approximate earth surface distance calculated with sphere model.
    /// </summary>
    /// <param name="request">A and B point coordinates.</param>
    /// <returns></returns>
    [HttpGet("surfaceDistanse/{latitudeA}/{longitudeA}/{latitudeB}/{longitudeB}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EarthSurfaceDistanceResponse))]
    public ActionResult<EarthSurfaceDistanceResponse> SphereDistanceController([FromRoute] EarthSurfaceDistanceRequest request)
    {
        Coordinate A, B;
        try
        {
            A = new(request.LatitudeA, request.LongitudeA);
            B = new(request.LatitudeB, request.LongitudeB);
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }

        var distanceKm = _earthCalculationApplicationService.GetEarthSurfaceDistanceKm(A, B);

        return Ok(new EarthSurfaceDistanceResponse { DistanceKm = distanceKm });
    }
}
