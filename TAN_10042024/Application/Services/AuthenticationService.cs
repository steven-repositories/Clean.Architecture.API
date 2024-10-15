using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Builders;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthentication {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IAuthenticationSessionRepository _authSessionRepo;
        private readonly IAuthenticationSessionQueryService _authSessionQueryService;
        private readonly IClientQueryService _clientQueryService;

        public AuthenticationService(ILogger<AuthenticationService> logger, IAuthenticationSessionRepository authSessionRepo,
            IAuthenticationSessionQueryService authSessionQueryService, IClientQueryService clientQueryService) {
            _logger = logger;
            _authSessionRepo = authSessionRepo;
            _authSessionQueryService = authSessionQueryService;
            _clientQueryService = clientQueryService;
        }

        public async Task<Guid> GenerateKey(string clientName) {
            var client = await _clientQueryService.GetClientByName(clientName);

            if (client == null) {
                throw new ServiceException("Client cannot be found.");
            }

            _logger.LogInformation("Generating new authentication key for client {0}..."
                .FormatWith(clientName));

            var newKey = Guid.NewGuid();
            var isNew = default(bool);

            do {
                var authSession = await _authSessionQueryService
                    .GetAuthDetailsByKey(newKey.ToString());

                if (authSession != null) {
                    newKey = Guid.NewGuid();
                    continue;
                }

                isNew = true;
            } while (!isNew);

            _logger.LogInformation("New authentication key is generated: {0}"
                .FormatWith(newKey.ToString()));

            var newAuthSession = AuthenticationSessionBuilder
                .Initialize()
                .WithKey(newKey)
                .WithClient(client)
                .Build();

            await _authSessionRepo.SaveAuthKey(newAuthSession);
            return newKey;
        }

        public async Task<AuthenticationSession?> Authenticate(string key) {
            return await _authSessionQueryService.GetAuthDetailsByKey(key);
        }
    }
}
