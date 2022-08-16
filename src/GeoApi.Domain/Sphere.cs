using GeoApi.Domain.Exceptions;
using GeoApi.Domain.Extensions;
using GeoApi.Domain.ValueObjets;

namespace GeoApi.Domain
{
    public class Sphere
    {
        private readonly double _sphereRadius;

        public Sphere(double sphereRadius)
        {
            if (sphereRadius < 0)
            {
                throw new DomainArgumentException("Sphere value must be grater than zero.", nameof(sphereRadius));
            }

            _sphereRadius = sphereRadius;
        }

        public double CalculateSphereSurfaceDistance(Coordinate A, Coordinate B)
        {
            double a = (90d - B.Latitiude).ToRadians();
            double b = (90d - A.Latitiude).ToRadians();
            double phi = (A.Longitude - B.Longitude).ToRadians();
            double component = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(phi);
            return _sphereRadius * Math.Acos(component);
        }
    }
}
