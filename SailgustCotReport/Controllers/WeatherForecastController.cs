using Microsoft.AspNetCore.Mvc;

namespace SailgustCotReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "AddTwoNumbers")]
        public int AddTwoNumbers()
        {
            int a = 10;
            int b = 35;

            int c = AddTwoNumber(a, b);

            return c;
        }

        private int AddTwoNumber(int a, int b)
        {
            int c = a + b;

            return c;
        }

        private object SeperateOranges(List<Orange> oranges)
        {

            var greenOranges = new List<Orange>();
            var yellowOranges = new List<Orange>();


            foreach (var orange in oranges)
            {
                if (orange.Colour== "Green")
                {
                    greenOranges.Add(orange);
                }
                else
                {
                    yellowOranges.Add(orange);
                }
            }

            var newBaskets = new { GreenOranges = greenOranges, YellowOranges = yellowOranges };


            return newBaskets;
        }

        public class Orange
        {
            public string Colour { get; set; }
        }
    }
}