using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class AuthenticationSessionQueryService : IAuthenticationSessionQueryService {
        private readonly ILogger<AuthenticationSessionQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public AuthenticationSessionQueryService(ILogger<AuthenticationSessionQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<AuthenticationSession?> GetAuthDetailsByKey(string key) {
            if (key.IsNullOrEmpty()) {
                throw new RepositoryException(Constants.ERR_MESSAGE_401);
            }

            var guid = Guid.Parse(key);

            var result = _dbContext
                .Set<AuthenticationSession>()
                .Where(auth => auth.Key == guid)
                .FirstOrDefaultAsync();

            return await result;
        }
    }
}
