using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace dotnet_core_weather_api.Controllers
{
    [ApiController]
    [Route("/api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{city}")]
        public IActionResult Get(String city)
        {
            try{
                return Ok("Returns weather for " + city);
            }
            catch{
                _logger.LogError("unable to find weather for given city");
                return BadRequest("unable to find weather for given city");
            }
            
        }
    }

    [Route("/api/Forecast")]
    public class ForecastController : ControllerBase
    {

        private readonly ILogger<ForecastController> _logger;

        public ForecastController(ILogger<ForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{city}")]
        public IActionResult Get(String city)
        {
            try{
                return Ok("Returns forecast for " + city);
            }
            catch{
                _logger.LogError("unable to find forecast for given city");
                return BadRequest("unable to find forecast for given city");
            }
           
        }
    }
}
