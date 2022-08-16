using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers;

public partial class EarthController
{
    public class EarthSurfaceDistanceRequest
    {
        /// <summary>
        /// A point latitude component. Valid values [-90,90] degree.
        /// </summary>
        [FromRoute(Name = "latitudeA")]
        public double LatitudeA { get; set; }

        /// <summary>
        /// A point longitude component. Valid values [-180,180] degree.
        /// </summary>
        [FromRoute(Name = "longitudeA")]
        public double LongitudeA { get; set; }

        /// <summary>
        /// B point latitude component. Valid values [-90,90] degree.
        /// </summary>
        [FromRoute(Name = "latitudeB")]
        public double LatitudeB { get; set; }

        /// <summary>
        /// B point longitude component. Valid values [-180,180] degree.
        /// </summary>
        [FromRoute(Name = "longitudeB")]
        public double LongitudeB { get; set; }
    }
}
