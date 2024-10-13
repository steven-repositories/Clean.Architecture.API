using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Builders;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Infrastructure.Data.Repositories
{
    public class ApiSessionRepository : IApiSessionRepository {
        private readonly ILogger<ApiSessionRepository> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionRepository(ILogger<ApiSessionRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SaveApiSession(string method, string url) {
            _logger.LogInformation("Saving to database the api session.");

            try {
                var newApiSession = ApiSessionBuilder
                    .Initialize()
                    .WithMethod(method)
                    .WithURL(url)
                    .Build();

                await _dbContext
                    .Set<ApiSession>()
                    .AddAsync(newApiSession);

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
