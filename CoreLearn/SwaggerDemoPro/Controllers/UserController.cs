using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemoPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public string Get(int length)
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// GetJwt
        /// </summary>
        /// <param name="tokenModel">tokenModel</param>
        /// <returns></returns>
        [HttpPost]
        public string GetJwt([FromBody] TokenModel tokenModel)
        {
            return Token.GetJWT(tokenModel);
        }
    }
}
