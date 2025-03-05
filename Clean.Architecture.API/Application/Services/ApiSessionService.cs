using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Domain.Factories;

namespace Clean.Architecture.API.Application.Services {
    public class ApiSessionService : IApiSession {
        private readonly ILogger<ApiSessionService> _logger;
        private readonly IApiSessionRepository _apiSessionRepo;
        private readonly ApiSessionBuilderFactory _apiSessionBuilderFactory;

        public ApiSessionService(ILogger<ApiSessionService> logger, IApiSessionRepository apiSessionRepo, ApiSessionBuilderFactory apiSessionBuilderFactory) {
            _logger = logger;
            _apiSessionRepo = apiSessionRepo;
            _apiSessionBuilderFactory = apiSessionBuilderFactory;
        }

        public async Task SaveSession(string method, string url) {
            var apiSessionBuilder = _apiSessionBuilderFactory
                .CreateBuilder();

            var newApiSession = apiSessionBuilder
                .WithMethod(method)
                .WithURL(url)
                .Build();

            await _apiSessionRepo.SaveApiSession(newApiSession);
        }
    }
}
