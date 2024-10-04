using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Data;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Utilities;
using static TAN_10042024.Utilities.Exceptions;

namespace TAN_10042024.Framework.Repositories {
    public class AuthenticationSessionsRepository {
        private readonly ILogger<AuthenticationSessionsRepository> _logger;
        private readonly AppDbContext _dbContext;

        public AuthenticationSessionsRepository(ILogger<AuthenticationSessionsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<AuthenticationSessions?> GetAuthDetailsByKey(string key) {
            if (key.IsNullOrEmpty()) {
                throw new RepositoryException(Constants.ERR_MESSAGE_401);
            }

            var guid = Guid.Parse(key);

            var result = _dbContext
                .Set<AuthenticationSessions>()
                .Where(auth => auth.Key == guid)
                .FirstOrDefaultAsync();

            return await result;
        }

        public async Task SaveAuthKey(Guid key, string clientName) {
            _logger.LogInformation("Saving to database the auth key generated for client {0}."
            .FormatWith(clientName));

            try {
                var client = _dbContext
                    .Set<Clients>()
                    .Where(client => client.Name == clientName)
                    .FirstOrDefault()!;

                var authSession = new AuthenticationSessions() {
                    Key = key,
                    Clients = client
                };

                _dbContext
                    .Set<AuthenticationSessions>()
                    .Add(authSession);

                var id = await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Auth key is saved to database with key of: {0}."
                    .FormatWith(id));
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving auth key: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
