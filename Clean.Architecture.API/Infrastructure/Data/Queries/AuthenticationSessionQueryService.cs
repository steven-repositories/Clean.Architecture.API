using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Entities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Infrastructure.Data.Queries {
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

            var result = await _dbContext
                .Set<AuthenticationSession>()
                .Where(auth => auth.Key == guid)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
