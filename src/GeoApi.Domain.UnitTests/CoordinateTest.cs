using FluentAssertions;
using GeoApi.Domain.Exceptions;
using GeoApi.Domain.ValueObjets;
using Xunit.Abstractions;
using static FluentAssertions.FluentActions;

namespace GeoApi.Domain.UnitTests
{
    public class CoordinateTest
    {
        private readonly ITestOutputHelper _testOutput;

        public CoordinateTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Ctor_CalledWithValidParams_ItShouldCreate()
        {
            var latitude = 1d;
            var longitude = 2d;
            var sut = new Coordinate(latitude, longitude);

            sut.Latitiude.Should().Be(latitude);
            sut.Longitude.Should().Be(longitude);
        }

        [Theory]
        [InlineData(-91d,1d)]
        [InlineData(91d,1d)]
        [InlineData(1d,181d)]
        [InlineData(1d,-181d)]
        public void Ctor_CalledWithExeedingRangeValue_ItThrowsDomainArgumentException(double latitude, double longitude)
        {
            _testOutput.WriteLine($"Test for coordinate ({latitude},{longitude}).");
            Invoking(() =>
            {
                _ = new Coordinate(latitude, longitude);
            }).Should().Throw<DomainArgumentException>()
            .And.Message.Contains("incorrect value");
            //.WithMessage("expected message"); - asserting messages is bad practice as it gives minimal value and high maintenance cost in bigger projects.
            // btw as I deicded inline data to test there is no more option to assert message - it woould require two separate tests for long and lat
        }
    }
}