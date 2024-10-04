using Newtonsoft.Json;
using TAN_10042024.Application.Models;
using TAN_10042024.Utilities;

namespace TAN_10042024.Framework.Middlewares {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            if (!context.Response.HasStarted) {

                await _next(context);
            }
        }
    }
}
