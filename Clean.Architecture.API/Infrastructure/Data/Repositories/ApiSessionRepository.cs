using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Entities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Infrastructure.Data.Repositories {
    public class ApiSessionRepository : IApiSessionRepository {
        private readonly ILogger<ApiSessionRepository> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionRepository(ILogger<ApiSessionRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SaveApiSession(ApiSession session) {
            _logger.LogInformation("Saving to database the api session.");

            try {
                await _dbContext
                    .Set<ApiSession>()
                    .AddAsync(session);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Api Session is saved to database!");
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving api session: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
