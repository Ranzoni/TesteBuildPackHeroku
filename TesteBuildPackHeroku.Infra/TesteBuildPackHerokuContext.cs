using Microsoft.EntityFrameworkCore;
using TesteBuildPackHeroku.Core;

namespace TesteBuildPackHeroku.Infra
{
    public class TesteBuildPackHerokuContext : DbContext
    {
        public TesteBuildPackHerokuContext(DbContextOptions<TesteBuildPackHerokuContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
