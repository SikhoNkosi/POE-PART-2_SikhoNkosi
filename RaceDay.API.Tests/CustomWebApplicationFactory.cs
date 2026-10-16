using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RaceDay.API.Data;

namespace RaceDay.API.Tests
{
    // Starts the real API inside the test run, but with a fresh in-memory database
    // instead of SQL Server, so the tests can run on any machine (including GitHub).
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _databaseName = "RaceDayTests-" + Guid.NewGuid();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddDbContext<RaceDayContext>(options =>
                    options.UseInMemoryDatabase(_databaseName));
            });
        }
    }
}
