using TAN_10042024.Application.Abstractions;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Framework.Repositories;
using TAN_10042024.Utilities;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly AuthenticationSessionsRepository _authSessionsRepo;

        public AuthenticationService(ILogger<AuthenticationService> logger, AuthenticationSessionsRepository authSessionsRepo) {
            _logger = logger;
            _authSessionsRepo = authSessionsRepo;
        }

        public Guid GenerateKey(string clientName) {
            _logger.LogInformation("Generating new authentication key for client {0}..."
                .FormatWith(clientName));

            var newKey = Guid.NewGuid();
            var isNew = default(bool);

            do {
                var authSession = _authSessionsRepo.GetAuthDetailsByKey(newKey.ToString());

                if (authSession.Result != null) {
                    newKey = Guid.NewGuid();
                    continue;
                }

                isNew = true;
            } while (!isNew);

            _logger.LogInformation("New authentication key is generated: {0}"
                .FormatWith(newKey.ToString()));

            _authSessionsRepo.SaveAuthKey(newKey, clientName);
            return newKey;
        }

        public async Task<AuthenticationSessions?> Authenticate(string key) {
            return await _authSessionsRepo.GetAuthDetailsByKey(key);
        }
    }
}
