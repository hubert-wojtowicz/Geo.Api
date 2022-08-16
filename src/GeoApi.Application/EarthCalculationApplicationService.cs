using GeoApi.Domain;
using GeoApi.Domain.ValueObjets;

namespace GeoApi.Application
{
    public class EarthCalculationApplicationService : IEarthCalculationApplicationService
    {
        public const double AvEarthRadiusKm = 6371;

        public double GetEarthSurfaceDistanceKm(Coordinate A, Coordinate B)
        {
            var sphere = new Sphere(AvEarthRadiusKm);
            return sphere.CalculateSphereSurfaceDistance(A, B);
        }
    }
}
