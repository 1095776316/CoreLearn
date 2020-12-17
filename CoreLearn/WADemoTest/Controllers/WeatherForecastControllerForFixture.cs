using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WADemoTest.Controllers
{
    public class WeatherForecastControllerForFixture : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture fixture;
        private readonly ITestOutputHelper output;
        public WeatherForecastControllerForFixture(TestServerFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Fact]
        public async Task RunGetReturnAny()
        {
            var response = await fixture.HttpClient.GetAsync("/WeatherForecast");
            output.WriteLine(await response.Content.ReadAsStringAsync());
            Assert.NotNull(response);
        }
    }
}
