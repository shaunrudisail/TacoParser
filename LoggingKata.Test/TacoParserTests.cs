using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.785605, -85.770014, Taco Bell Jacksonville...", -85.770014)]
        [InlineData("34.719613, -86.578994, Taco Bell Huntsville...", -86.578994)]
        [InlineData("33.352214, -84.124288, Taco Bell Locust Grov...", -84.124288)]
        [InlineData("34.027895, -84.334729, Taco Bell Roswel...",  -84.334729)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        { 
            //Arrange
            var longitudeParser = new TacoParser();

            //Act
            var actual = longitudeParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("31.570771, -84.10353, Taco Bell Albany...", 31.570771)]
        [InlineData("32.92496, -85.961342, Taco Bell Alexander Cit...",  32.92496)]
        [InlineData("34.795116, -86.97191, Taco Bell Athens...", 34.795116)]
        [InlineData("33.556383, -86.889051, Taco Bell Birmingha...", 33.556383)]
        [InlineData("30.22841, -85.649286, Taco Bell Lynn Have...", 30.22841)]

        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var latitudeParser = new TacoParser();

            //Act
            var actual = latitudeParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
