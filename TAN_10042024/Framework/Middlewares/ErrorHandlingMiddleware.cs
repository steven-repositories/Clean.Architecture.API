using Newtonsoft.Json;
using TAN_10042024.Application.Models;

namespace TAN_10042024.Framework.Middlewares {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception e) {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var internalServerResponse = new ErrorResponse() {
                    Status = "Internal Server Error",
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };

                var internalServerResponseJson = JsonConvert.SerializeObject(internalServerResponse);

                await context
                    .Response
                    .WriteAsJsonAsync(internalServerResponseJson);
            }
        }
    }
}
