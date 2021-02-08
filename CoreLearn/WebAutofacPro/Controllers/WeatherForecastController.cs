using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebAutofacPro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly ITestService _service;
        private readonly ITestService _service2;
        private readonly IUnitTest  _unitTest;
        private readonly ILogger _logger;
        public WeatherForecastController(ITestService service, ITestService service2, IUnitTest unitTest, ILoggerFactory _loggerFactory)
        {
            _service = service;
            _service2 = service2;
            _unitTest= unitTest;
            _logger = _loggerFactory.CreateLogger<WeatherForecastController>();
        }

        [HttpGet]
        public dynamic Get()
        {
            try
            {
                throw new Exception("you object is null.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            
            var data= new { g1 = _service.No, g2 = _service2.No,u3= _unitTest.Get() };
            return data;
        }
    }
}
