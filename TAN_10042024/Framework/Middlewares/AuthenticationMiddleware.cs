using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Application.Utilities;

namespace TAN_10042024.Infrastructure.Middlewares {
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

                if (!headers.TryGetValue("Auth-Key", out var key)) {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    var unauthorizedResponse = new ErrorResponse() {
                        Status = "Unauthorized",
                        Message = Constants.ERR_MESSAGE_401
                    };

                    await context
                        .Response
                        .WriteAsJsonAsync(unauthorizedResponse);

                    return;
                }

                using var serviceScope = _serviceProvider.CreateScope();

                var authService = serviceScope
                    .ServiceProvider
                    .GetRequiredService<IAuthenticationService>();

                var details = await authService.Authenticate(key!);

                if (details == null) {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;

                    var forbiddenResponse = new ErrorResponse() {
                        Status = "Forbidden",
                        Message = Constants.ERR_MESSAGE_403
                    };

                    await context
                        .Response
                        .WriteAsJsonAsync(forbiddenResponse);

                    return;
                }

                context.Items["Locals"] = details;
            }

            await _next(context);
        }
    }
}
