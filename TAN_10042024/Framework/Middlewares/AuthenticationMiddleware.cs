using Microsoft.IdentityModel.Tokens;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Middlewares {
    public class AuthenticationMiddleware {
        private readonly RequestDelegate _next;
        private readonly IAuthenticationService _authService;

        public AuthenticationMiddleware(RequestDelegate next, IAuthenticationService authService) {
            _next = next;
            _authService = authService;
        }

        public async Task Authenticate(HttpContext context) {
            var headers = context
                .Request
                .Headers;

            if (!headers.TryGetValue("Authorization", out var token)) {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            if (token.IsNullOrEmpty()) {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }

            var details = _authService.Authenticate(token!);

            if (details == default) {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }

            context.Items["Locals"] = details;
            await _next(context);
        }
    }
}
