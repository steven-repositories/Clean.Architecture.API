namespace TAN_10042024.Framework.Middlewares {
    public class ErrorMiddleware {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var statusCode = context.Response.StatusCode;
        }
    }
}
