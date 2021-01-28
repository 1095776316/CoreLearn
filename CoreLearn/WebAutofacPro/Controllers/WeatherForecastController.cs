using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Mvc;

namespace WebAutofacPro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Intercept(typeof(MyInterceptor))]
    public class WeatherForecastController : ControllerBase, IControllerBase
    {
        private readonly ITestService _service;
        private readonly ITestService _service2;
        private readonly IUnitTest  _unitTest; 

        public WeatherForecastController(ITestService service, ITestService service2, IUnitTest unitTest)
        {
            _service = service;
            _service2 = service2;
            _unitTest= unitTest;
        }

        [HttpGet]
        public dynamic Get()
        {
            var data= new { g1 = _service.No, g2 = _service2.No,u3= _unitTest.Get() };
            return data;
        }
    }
}
