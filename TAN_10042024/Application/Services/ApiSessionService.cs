using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Domain.Builders;

namespace TAN_10042024.Application.Services {
    public class ApiSessionService : IApiSessionService {
        private readonly ILogger<ApiSessionService> _logger;
        private readonly IApiSessionRepository _apiSessionRepo;

        public ApiSessionService(ILogger<ApiSessionService> logger, IApiSessionRepository apiSessionRepo) {
            _logger = logger;
            _apiSessionRepo = apiSessionRepo;
        }

        public async Task SaveSession(string method, string url) {
            var apiSession = ApiSessionBuilder
                .Initialize()
                .WithMethod(method)
                .WithURL(url)
                .Build();

            await _apiSessionRepo.SaveApiSession(apiSession);
        }
    }
}
