namespace TAN_10042024.Framework.Middlewares {
    public class AuthenticationMiddleware {
        private RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Authenticate(HttpContext context) {
            var headers = context
                .Request
                .Headers;

            if (!headers.TryGetValue("Authorization", out var token)) {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            // validate token here
        }
    }
}
