using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Data;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Utilities;
using static TAN_10042024.Utilities.Exceptions;

namespace TAN_10042024.Framework.Repositories {
    public class AuthorizationTokensRepository {
        private readonly ILogger<AuthorizationTokensRepository> _logger;
        private AppDbContext _dbContext;

        public AuthorizationTokensRepository(ILogger<AuthorizationTokensRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        private IQueryable<AuthorizationTokens> GetQueryable() {
            return _dbContext
                .Set<AuthorizationTokens>()
                .Include(c => c.Clients);
        }

        public Task<AuthorizationTokens?> GetAuthDetailsByToken(string token) {
            if (token.IsNullOrEmpty()) {
                throw new RepositoryException("Authorization Token is required.");
            }

            var guid = Guid.Parse(token);
            var query = GetQueryable();
            var result = query
                .Where(auth => auth.Token == guid)
                .FirstOrDefault();

            return Task.FromResult(result);
        }
    }
}
