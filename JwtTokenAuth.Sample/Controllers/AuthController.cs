using JwtTokenAuth.Sample.Interface;
using JwtTokenAuth.Sample.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace JwtTokenAuth.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Login işlemlerinin yapıldığı controller

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService= authService;
        }

        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await _authService.LoginUserAsync(request);
            return result;
        }
    }
}
