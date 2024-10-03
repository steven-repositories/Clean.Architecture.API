using TAN_10042024.Application.Abstractions;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly ILogger<AuthenticationService> _logger;
        public AuthenticationService(ILogger<AuthenticationService> logger) {
            _logger = logger;
        }

        public Guid GenerateToken() {
            _logger.LogInformation("Generating new token...");
            return Guid.NewGuid();
        }

        public async Task<AuthorizationTokens> Authenticate(string token) {

            return await default(Task<AuthorizationTokens>)!;
        }
    }
}
