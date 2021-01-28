using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHangfirePro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBackGourdJob _backGourdJob;
        public WeatherForecastController(IBackGourdJob backGourdJob)
        {
            _backGourdJob = backGourdJob;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            await _backGourdJob.ExecuteAsync();
            return "ok";
        }
    }
}
