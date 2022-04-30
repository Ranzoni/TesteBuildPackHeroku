using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBuildPackHeroku.Core;

namespace TesteBuildPackHeroku.Infra
{
    public class SeedingService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly TesteBuildPackHerokuContext _context;

        public SeedingService(TesteBuildPackHerokuContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.WeatherForecasts.Any())
                return;

            var rng = new Random();
            var weatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            _context.WeatherForecasts.AddRange(weatherForecast);
            _context.SaveChanges();
        }
    }
}
