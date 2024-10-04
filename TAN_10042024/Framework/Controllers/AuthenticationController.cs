using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/auth")]
    [ApiController, Produces("application/json")]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService) {
            _authService = authService;
        }

        [HttpPost, Route("key")]
        public async Task<IActionResult> Key([FromBody] KeyRequest request) {
            var key = await _authService
                .GenerateKey(request.ClientName);

            return Ok(new {
                access_key = key
            });
        }
    }
}
