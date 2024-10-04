using Microsoft.IdentityModel.Tokens;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Middlewares {
    public class AuthenticationMiddleware {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationMiddleware(RequestDelegate next, IServiceProvider serviceProvider) {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context) {
            var controllerName = context
                .Request
                .RouteValues["controller"]!
                .ToString();

            if (controllerName != "Authentication") {
                var headers = context
                    .Request
                    .Headers;

                if (!headers.TryGetValue("Authorization", out var token)) {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }

                if (token.IsNullOrEmpty()) {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                }

                using var serviceScope = _serviceProvider.CreateScope();

                var authService = serviceScope
                    .ServiceProvider
                    .GetRequiredService<IAuthenticationService>();

                var details = await authService.Authenticate(token!);

                if (details == null) {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                }

                context.Items["Locals"] = details;
            }

            await _next(context);
        }
    }
}
