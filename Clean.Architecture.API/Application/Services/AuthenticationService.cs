using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Entities;
using Clean.Architecture.API.Domain.Factories;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Application.Services {
    public class AuthenticationService : IAuthentication {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IAuthenticationSessionRepository _authSessionRepo;
        private readonly IAuthenticationSessionQueryService _authSessionQueryService;
        private readonly IClientQueryService _clientQueryService;
        private readonly AuthenticationSessionBuilderFactory _authSessionBuilderFactory;

        public AuthenticationService(ILogger<AuthenticationService> logger, IAuthenticationSessionRepository authSessionRepo,
            IAuthenticationSessionQueryService authSessionQueryService, IClientQueryService clientQueryService, AuthenticationSessionBuilderFactory authSessionBuilderFactory) {
            _logger = logger;
            _authSessionRepo = authSessionRepo;
            _authSessionQueryService = authSessionQueryService;
            _clientQueryService = clientQueryService;
            _authSessionBuilderFactory = authSessionBuilderFactory;
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

            var authSessionBuilder = _authSessionBuilderFactory
                .CreateBuilder();

            var newAuthSession = authSessionBuilder
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
