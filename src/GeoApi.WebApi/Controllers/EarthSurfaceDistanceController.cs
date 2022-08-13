using GeoApi.Application;
using GeoApi.Domain.ValueObjets;
using GeoApi.WebApi.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EarthController : ControllerBase
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

    [HttpGet("surfaceDistanse/{latitudeA}/{longitudeA}/{latitudeB}/{longitudeB}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EarthSurfaceDistanceResponse))]
    public ActionResult<EarthSurfaceDistanceResponse> SphereDistanceController(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
    {
        Coordinate A, B;
        try
        {
            A = new(latitudeA, longitudeA);
            B = new(latitudeB, longitudeB);
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }

        var distanceKm = _earthCalculationApplicationService.GetEarthSurfaceDistanceKm(A, B);

        return Ok(new EarthSurfaceDistanceResponse { DistanceKm = distanceKm });
    }
}
