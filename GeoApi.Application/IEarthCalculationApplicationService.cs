using GeoApi.Domain.ValueObjets;

namespace GeoApi.Application
{
    public interface IEarthCalculationApplicationService
    {
        double GetEarthSurfaceDistanceKm(Coordinate A, Coordinate B);
    }
}