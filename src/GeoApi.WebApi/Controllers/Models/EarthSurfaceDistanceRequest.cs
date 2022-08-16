namespace Geo.Api.Controllers.Models
{
    public class EarthSurfaceDistanceRequest
    {
        /// <summary>
        /// A point latitude component. Valid values [-90,90] degree.
        /// </summary>
        public double LatitudeA { get; set; }

        /// <summary>
        /// A point longitude component. Valid values [-180,180] degree.
        /// </summary>
        public double LongitudeA { get; set; }

        /// <summary>
        /// B point latitude component. Valid values [-90,90] degree.
        /// </summary>
        public double LatitudeB { get; set; }

        /// <summary>
        /// B point longitude component. Valid values [-180,180] degree.
        /// </summary>
        public double LongitudeB { get; set; }
    }
}