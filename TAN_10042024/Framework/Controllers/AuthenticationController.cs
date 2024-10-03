using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/auth")]
    [ApiController, Produces("application/json")]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService) {
            _authService = authService;
        }

        [HttpPost, Route("token")]
        public IActionResult Token() {
            var token = _authService
                .GenerateToken()
                .ToString();

            return Ok();
        }
    }
}
