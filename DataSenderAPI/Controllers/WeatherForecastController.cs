using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataSenderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Darn Cold!", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// WeatherForecastController (constructor)
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            List<WeatherForecast> forecasts = new List<WeatherForecast>()
            {
                new WeatherForecast()
                {
                    Date = DateTime.Now.Date,
                    TemperatureC = 0,
                    Summary = "I am sending this back in json!"
                },
                new WeatherForecast()
                {
                    Date = DateTime.Now.Date.AddDays(3),
                    TemperatureC = 100,
                    Summary = "Holy baked goods Batman!"
                }
            };

            

            return forecasts;

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
