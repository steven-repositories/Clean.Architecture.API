using Microsoft.AspNetCore.Http.Extensions;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Infrastructure.Data.Repositories;

namespace TAN_10042024.Infrastructure.Middlewares {
    public class RequestLoggerMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger, RequestDelegate next, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var method = request.Method;
            var url = request.GetDisplayUrl();

            _logger.LogInformation("{0}: {1}"
                .FormatWith(method, url));

            var controllerName = request
                .RouteValues["controller"]!
                .ToString();

            if (controllerName == "FileUpload")
            {
                var form =  request.Form;

                if (form.Files.Count > 0)
                {
                    var file = form
                        .Files
                        .FirstOrDefault();

                    var fileName = file!.FileName;
                    var fileContent = await file.ReadFileContent();

                    _logger.LogInformation("File {0} content:\n{1}"
                        .FormatWith(fileName, fileContent));

                    context.Items["FileContent"] = fileContent;

                    using var serviceScope = _serviceProvider.CreateScope();

                    var apiSessionRepo = serviceScope
                        .ServiceProvider
                        .GetRequiredService<ApiSessionsRepository>();

                    apiSessionRepo.SaveApiSession(method, url);
                }
            }

            await _next(context);
        }
    }
}
