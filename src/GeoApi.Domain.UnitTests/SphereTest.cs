using FluentAssertions;
using GeoApi.Domain.Exceptions;
using GeoApi.Domain.ValueObjets;
using Xunit.Abstractions;
using static FluentAssertions.FluentActions;

namespace GeoApi.Domain.UnitTests
{
    public class SphereTest
    {
        const double ExpectedCalculationAccuracyKm = 1d;

        [Fact]
        public void Ctor_WhenRadiusIsNegative_ItThrowsDomainArgumentException()
        {
            Invoking(() =>
            {
                _ = new Sphere(-1);
            }).Should().Throw<DomainArgumentException>()
            .WithMessage("Sphere value must be grater than zero.");
        }

        [Fact]
        public void CalculateSphereSurfaceDistance_WhenDistanceBetweenTwoSamePoints_ItShouldReturnZero()
        {
            var A = new Coordinate(1, 1);
            var sut = new Sphere(6371);

            var distanceKm = sut.CalculateSphereSurfaceDistance(A, A);
            distanceKm.Should().BeApproximately(0, ExpectedCalculationAccuracyKm);
        }

        [Fact]
        public void CalculateSphereSurfaceDistance_WhenRadiusOne_ItShouldReturnValue()
        {
            var spartanMartialArtsDublinIreland = new Coordinate(53.297975, -6.372663);
            var chipotleMexicanGrillFoodClevelandUS = new Coordinate(41.385101, 81.440440);
            var sut = new Sphere(6371);

            var distanceKm = sut.CalculateSphereSurfaceDistance(spartanMartialArtsDublinIreland, chipotleMexicanGrillFoodClevelandUS);
            distanceKm.Should().BeApproximately(6318, ExpectedCalculationAccuracyKm);
        }
    }
}