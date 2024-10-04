using TAN_10042024.Application.Data;
using TAN_10042024.Application.Models;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Utilities;
using static TAN_10042024.Utilities.Exceptions;

namespace TAN_10042024.Framework.Repositories {
    public class ApiSessionsRepository {
        private readonly ILogger<ApiSessionsRepository> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionsRepository(ILogger<ApiSessionsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<ApiSessions> GetAll() {
            return _dbContext
                .Set<ApiSessions>()
                .ToList();
        }

        public void SaveApiSession(string method, string url) {
            _logger.LogInformation("Saving to database the api session.");

            try {
                var apiSession = new ApiSessions() {
                    Method = method,
                    URL = url
                };

                _dbContext
                    .Set<ApiSessions>()
                    .Add(apiSession);

                _dbContext.SaveChanges();

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
