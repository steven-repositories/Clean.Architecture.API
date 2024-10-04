using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Data;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Utilities;
using static TAN_10042024.Utilities.Exceptions;

namespace TAN_10042024.Framework.Repositories {
    public class AuthenticationSessionsRepository {
        private readonly ILogger<AuthenticationSessionsRepository> _logger;
        private AppDbContext _dbContext;

        public AuthenticationSessionsRepository(ILogger<AuthenticationSessionsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        private IQueryable<AuthenticationSessions> GetQueryable() {
            return _dbContext
                .Set<AuthenticationSessions>()
                .Include(c => c.Clients);
        }

        public Task<AuthenticationSessions?> GetAuthDetailsByKey(string token) {
            if (token.IsNullOrEmpty()) {
                throw new RepositoryException(Constants.ERR_MESSAGE_401);
            }

            var guid = Guid.Parse(token);
            var query = GetQueryable();
            var result = query
                .Where(auth => auth.Key == guid)
                .FirstOrDefault();

            return Task.FromResult(result);
        }
    }
}
