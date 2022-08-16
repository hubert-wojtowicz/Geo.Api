using FluentValidation;
using Geo.Api.Controllers.Models;
using GeoApi.Application;
using GeoApi.Domain.Exceptions;
using GeoApi.Domain.ValueObjets;
using GeoApi.WebApi.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public partial class EarthController : ControllerBase
{
    private readonly ILogger<EarthController> _logger;
    private readonly IValidator<EarthSurfaceDistanceRequest> _earthSurfaceDistanceRequestValidator;
    private readonly IEarthCalculationApplicationService _earthCalculationApplicationService;

    public EarthController(
        ILogger<EarthController> logger,
        IValidator<EarthSurfaceDistanceRequest> earthSurfaceDistanceRequestValidator,
        IEarthCalculationApplicationService earthCalculationApplicationService)
    {
        _logger = logger;
        _earthSurfaceDistanceRequestValidator = earthSurfaceDistanceRequestValidator;
        _earthCalculationApplicationService = earthCalculationApplicationService;
    }

    /// <summary>
    /// Returns approximate earth surface distance calculated with sphere model.
    /// </summary>
    /// <param name="request">A and B point coordinates.</param>
    /// <returns></returns>
    [HttpPost("surfaceDistanse")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EarthSurfaceDistanceResponse))]
    public ActionResult<EarthSurfaceDistanceResponse> SphereDistanceController([FromBody] EarthSurfaceDistanceRequest request)
    {
        var validationResult = _earthSurfaceDistanceRequestValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ErrorResponse { Messages = validationResult.Errors.Select(x => x.ErrorMessage) });
        }

        try
        {
            Coordinate A = new(request.LatitudeA, request.LongitudeA);
            Coordinate B = new(request.LatitudeB, request.LongitudeB);
            var distanceKm = _earthCalculationApplicationService.GetEarthSurfaceDistanceKm(A, B);

            return Ok(new EarthSurfaceDistanceResponse { DistanceKm = distanceKm });
        }
        catch (DomainException e)
        {
            return BadRequest(new ErrorResponse { Messages = new[] { e.Message } });
        }
    }
}
