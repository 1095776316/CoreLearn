using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExample2.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {

        [Route("api/demo/{id}")]
        [HttpGet]
        public dynamic Get(int id)
        {
            return new
            {
                id = id,
                ApiName = "ApiExample2",
                Timespan = DateTime.Now.Ticks
            };
        }
    }
}
