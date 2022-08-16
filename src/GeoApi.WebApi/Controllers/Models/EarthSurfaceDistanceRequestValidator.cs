using FluentValidation;
using Geo.Api.Controllers.Models;

namespace GeoApi.WebApi.Controllers.Models
{
    public class EarthSurfaceDistanceRequestValidator: AbstractValidator<EarthSurfaceDistanceRequest>
    {
        public EarthSurfaceDistanceRequestValidator()
        {
            RuleFor(x => x.LatitudeA)
                .NotNull()
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.LatitudeB)
                .NotNull()
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.LongitudeA)
                .NotNull()
                .InclusiveBetween(-180, 180);

            RuleFor(x => x.LongitudeB)
                .NotNull()
                .InclusiveBetween(-180, 180);
        }
    }
}
