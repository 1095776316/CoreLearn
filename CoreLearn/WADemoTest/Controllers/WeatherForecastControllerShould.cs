using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WADemo;
using WADemo.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace WADemoTest.Controllers
{
    public class WeatherForecastControllerShould
    {
        private readonly WeatherForecastController _con;
        private readonly ITestOutputHelper _output;
        public WeatherForecastControllerShould(ITestOutputHelper _output)
        {
            var logger = new Mock<ILogger<WeatherForecastController>>();
            _con = new WeatherForecastController(logger.Object);
            this._output = _output;
        }

        [Fact]
        public void GetReturnAny()
        {
            var result = _con.Get();
            _output.WriteLine(result.ToList().FirstOrDefault()?.Summary);
            Assert.IsType<WeatherForecast[]>(result);
        }

        [Fact]
        public async Task UseTestHostRunGetRtuenAny()
        {
            var builder = WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>();
            using var server = new TestServer(builder);
            var httpClient = server.CreateClient();
            var response = await httpClient.GetAsync("/WeatherForecast");
            _output.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
