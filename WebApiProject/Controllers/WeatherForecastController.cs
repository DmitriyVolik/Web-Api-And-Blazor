using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class WeatherForecastController : ControllerBase
    {
        public List<WeatherForecast> Forecasts;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, List<WeatherForecast> opt)
        {
            _logger = logger;
            Forecasts = opt;
        }
        
        
        [EnableCors("CorsPolicy")]
        [HttpDelete("{date}")]
        public async Task<IActionResult> DeleteWeatherForecast(string date)
        {
            Forecasts.Remove(Forecasts.FirstOrDefault(x => x.Date.ToShortDateString()== date));
            return  NoContent();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Forecasts;
        }
    }
}