using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

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
        public  async Task<IActionResult> Get(string city)
        {
            var client = new HttpClient();
            var getCurrentWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?q="+city+"&APPID=edd8a536615baec9136dec2c86cdb211";
            try{
                HttpResponseMessage response = await client.GetAsync(getCurrentWeatherUrl);
                Console.Write(response.Content.ReadAsStreamAsync().Result);
                return Ok(response.Content.ReadAsStringAsync().Result);
            }
            catch{

                return BadRequest("API call failed");
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
        public async Task<IActionResult> Get(string city)
        {
            var client = new HttpClient();
            var getWeatherForecastUrl = "http://api.openweathermap.org/data/2.5/forecast?q="+city+"&mode=json&units=imperial&cnt=7&APPID=edd8a536615baec9136dec2c86cdb211";
            try{
                HttpResponseMessage response = await client.GetAsync(getWeatherForecastUrl);
                Console.Write(response.Content.ReadAsStreamAsync().Result);
                return Ok(response.Content.ReadAsStringAsync().Result);
            }
            catch{
             
                return BadRequest("Api call failed");
            }
           
        }
    }
}
