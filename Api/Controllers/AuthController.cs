using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult<string> Login([FromBody] WebUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = _authService.GetAuthenticationToken(user);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult<string> Register([FromBody] WebUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var registered = _authService.RegisterNewUser(user);

            if (registered)
            {
                var token = _authService.GetAuthenticationToken(user);

                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }
            }

            return Unauthorized();
        }
    }
}
