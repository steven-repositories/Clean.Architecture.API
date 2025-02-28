using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Models;

namespace Clean.Architecture.API.Framework.APIs.Controllers {
    [Route("api/auth")]
    [ApiController, Produces("application/json")]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthentication _authService;

        public AuthenticationController(IAuthentication authService) {
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
