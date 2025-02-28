using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Domain.Builders;

namespace Clean.Architecture.API.Application.Services {
    public class ApiSessionService : IApiSession {
        private readonly ILogger<ApiSessionService> _logger;
        private readonly IApiSessionRepository _apiSessionRepo;

        public ApiSessionService(ILogger<ApiSessionService> logger, IApiSessionRepository apiSessionRepo) {
            _logger = logger;
            _apiSessionRepo = apiSessionRepo;
        }

        public async Task SaveSession(string method, string url) {
            var newApiSession = ApiSessionBuilder
                .Initialize()
                .WithMethod(method)
                .WithURL(url)
                .Build();

            await _apiSessionRepo.SaveApiSession(newApiSession);
        }
    }
}
