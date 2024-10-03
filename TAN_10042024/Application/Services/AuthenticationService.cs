using TAN_10042024.Application.Abstractions;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Framework.Repositories;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly AuthorizationTokensRepository _authTokensRepo;

        public AuthenticationService(ILogger<AuthenticationService> logger, AuthorizationTokensRepository authTokensRepo) {
            _logger = logger;
            _authTokensRepo = authTokensRepo;
        }

        public Guid GenerateToken() {
            _logger.LogInformation("Generating new token...");
            return Guid.NewGuid();
        }

        public async Task<AuthorizationTokens?> Authenticate(string token) {
            return await _authTokensRepo.GetAuthDetailsByToken(token);
        }
    }
}
