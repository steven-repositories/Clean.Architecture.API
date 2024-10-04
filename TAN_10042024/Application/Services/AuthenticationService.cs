using TAN_10042024.Application.Abstractions;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Framework.Repositories;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly AuthenticationSessionsRepository _authTokensRepo;

        public AuthenticationService(ILogger<AuthenticationService> logger, AuthenticationSessionsRepository authTokensRepo) {
            _logger = logger;
            _authTokensRepo = authTokensRepo;
        }

        public Guid GenerateKey() {
            _logger.LogInformation("Generating new authentication key...");
            return Guid.NewGuid();
        }

        public async Task<AuthenticationSessions?> Authenticate(string token) {
            return await _authTokensRepo.GetAuthDetailsByToken(token);
        }
    }
}
