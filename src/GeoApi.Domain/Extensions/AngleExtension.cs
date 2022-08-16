namespace GeoApi.Domain.Extensions
{
    public static class AngleExtension
    {
        public static double ToRadians(this double degree)
        {
            return degree * Math.PI / 180d;
        }
    }
}
