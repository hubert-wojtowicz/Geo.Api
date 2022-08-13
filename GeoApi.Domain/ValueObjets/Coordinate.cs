using GeoApi.Domain.Exceptions;

namespace GeoApi.Domain.ValueObjets
{
    public struct Coordinate
    {
        public Coordinate(double latitiude, double longitude)
        {
            if (Math.Abs(latitiude) > 90)
            {
                throw new DomainArgumentException($"Latitude coordinate has incorrect value '{latitiude}' - grater than 90 degree.", nameof(latitiude));
            }
            if (Math.Abs(longitude) > 190)
            {
                throw new DomainArgumentException($"Longitude coordinate has incorrect value '{latitiude}' - grater than 180 degree.", nameof(latitiude));
            }

            Latitiude = latitiude;
            Longitude = longitude;
        }

        public double Latitiude { get; }
        public double Longitude { get; }
    }
}