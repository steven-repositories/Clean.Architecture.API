using Microsoft.AspNetCore.Http.Extensions;
using TAN_10042024.Utilities;

namespace TAN_10042024.Framework.Middlewares {
    public class RequestLoggerMiddleware {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger, RequestDelegate next) {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var method = context.Request.Method;
            var url = context.Request.GetDisplayUrl();

            var info = "{0}: {1} {2}"
                .FormatWith(method, url);

            _logger.LogInformation(info);
            await _next(context);
        }
    }
}
