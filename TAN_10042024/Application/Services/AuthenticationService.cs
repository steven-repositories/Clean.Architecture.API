﻿using TAN_10042024.Application.Abstractions.Controllers;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Application.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IAuthenticationSessionsRepository _authSessionsRepo;
        private readonly IAuthenticationSessionsQueryService _authSessionsQueryService;
        private readonly IClientsQueryService _clientsQueryService;

        public AuthenticationService(ILogger<AuthenticationService> logger, IAuthenticationSessionsRepository authSessionsRepo,
            IAuthenticationSessionsQueryService authSessionsQueryService, IClientsQueryService clientsQueryService) {
            _logger = logger;
            _authSessionsRepo = authSessionsRepo;
            _authSessionsQueryService = authSessionsQueryService;
            _clientsQueryService = clientsQueryService;
        }

        public async Task<Guid> GenerateKey(string clientName) {
            var client = await _clientsQueryService.GetClientByName(clientName);

            if (client == null) {
                throw new ServiceException("Client cannot be found.");
            }

            _logger.LogInformation("Generating new authentication key for client {0}..."
                .FormatWith(clientName));

            var newKey = Guid.NewGuid();
            var isNew = default(bool);

            do {
                var authSession = await _authSessionsQueryService
                    .GetAuthDetailsByKey(newKey.ToString());

                if (authSession != null) {
                    newKey = Guid.NewGuid();
                    continue;
                }

                isNew = true;
            } while (!isNew);

            _logger.LogInformation("New authentication key is generated: {0}"
                .FormatWith(newKey.ToString()));

            await _authSessionsRepo.SaveAuthKey(newKey, clientName);
            return newKey;
        }

        public async Task<AuthenticationSessionsSchema?> Authenticate(string key) {
            return await _authSessionsQueryService.GetAuthDetailsByKey(key);
        }
    }
}
