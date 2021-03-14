using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonAPI;
using System;

namespace PersonAPITests
{

    [TestClass]
    public class UnitTest1
    {
        WeatherForecast testForecast { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.testForecast = new WeatherForecast();
        }

        [TestMethod]
        public void TestWeatherForecastClass()
        {
            var expected = new WeatherForecast()
            {
                Date = DateTime.Now.Date,
                Summary = "Hot!",
                TemperatureC = 32
            };

            var tempF = expected.TemperatureF;

            Assert.AreEqual(tempF, 89);


        }
    }
}
