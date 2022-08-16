using FluentAssertions;
using GeoApi.WebApi.Controllers.Models;
using GeoApi.WebApi.IntegrationTests.Helpers;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;
using static Geo.Api.Controllers.EarthController;

namespace GeoApi.WebApi.IntegrationTests
{
    public class EarthSurfaceDistanceControllerTests
    {
        const double ExpectedCalculationAccuracyKm = 1d;

        private readonly IConfiguration _configuration;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly RequestHelper _requestHelper;

        public EarthSurfaceDistanceControllerTests(ITestOutputHelper testOutputHelper)
        {
            _configuration = ConfigurationFactory.Build();
            _testOutputHelper = testOutputHelper;
            _requestHelper = new RequestHelper(_testOutputHelper);
        }

        [Fact]
        public async Task EarthSphereDistanceController_WhenCalled_RetunsOk200WithCalculatedDistance()
        {
            using var client = BuildShopperMessageManagementApiHttpClient();
            var request = new EarthSurfaceDistanceRequest
            {
                LatitudeA = 53.297975, 
                LongitudeA = -6.372663,
                LatitudeB = 41.385101,
                LongitudeB = 81.440440
            };
            var path = $"api/v1/Earth/surfaceDistanse/​{request.LatitudeA}​/{request.LongitudeA}​/{request.LatitudeB}​/{request.LongitudeB}";
            var (code, response) = await _requestHelper.GetRequestAsync<EarthSurfaceDistanceResponse>(client, path);

            response.Should().NotBeNull();
            response.DistanceKm.Should().BeApproximately(6318, ExpectedCalculationAccuracyKm);
            code.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(-91d, 1d)]
        [InlineData(91d, 1d)]
        [InlineData(1d, 181d)]
        [InlineData(1d, -181d)]
        public async Task Ctor_CalledWithExeedingRangeValue_ItThrowsDomainArgumentException(double latitude, double longitude)
        {
            using var client = BuildShopperMessageManagementApiHttpClient();
            var request = new EarthSurfaceDistanceRequest
            {
                LatitudeA = latitude,
                LongitudeA = longitude,
                LatitudeB = 41.385101,
                LongitudeB = 81.440440
            };
            var path = $"api/v1/Earth/surfaceDistanse/​{request.LatitudeA}​/{request.LongitudeA}​/{request.LatitudeB}​/{request.LongitudeB}";
            var (code, response) = await _requestHelper.GetRequestAsync<EarthSurfaceDistanceResponse>(client, path);

            response.Should().NotBeNull();
            code.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private HttpClient BuildShopperMessageManagementApiHttpClient()
        {
            var host = _configuration["Host"];
            var client =  new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            return client;
        }
    }
}