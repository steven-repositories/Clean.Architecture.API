using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using TAN_10042024.Application.Models;
using TAN_10042024.Framework.Repositories;
using TAN_10042024.Utilities;

namespace TAN_10042024.Framework.Middlewares {
    public class RequestLoggerMiddleware {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger, RequestDelegate next, IServiceProvider serviceProvider) {
            _logger = logger;
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context) {
            var request = context.Request;
            var method = request.Method;
            var url = request.GetDisplayUrl();

            _logger.LogInformation("{0}: {1}"
                .FormatWith(method, url));

            var controllerName = request
                .RouteValues["controller"]!
                .ToString();

            if (controllerName != "Authentication") {
                var form = request.Form;

                if (form.Files.Count > 0) {
                    var file = form
                        .Files
                        .FirstOrDefault();

                    var fileName = file!.FileName;
                    var fileContent = await file.ReadFileContent();

                    _logger.LogInformation("File {0} content:\n{1}"
                        .FormatWith(fileName, fileContent));

                    //var persons = JsonConvert
                    //    .DeserializeObject<PersonList>(fileContent);

                    //context.Items["Persons"] = persons;

                    using var serviceScope = _serviceProvider.CreateScope();

                    var apiSessionRepo = serviceScope
                        .ServiceProvider
                        .GetRequiredService<ApiSessionsRepository>();

                    apiSessionRepo.SaveApiSession(method, url, fileName, fileContent);
                }
            }

            await _next(context);
        }
    }
}
