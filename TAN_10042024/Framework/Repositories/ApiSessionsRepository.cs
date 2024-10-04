using TAN_10042024.Application.Data;

namespace TAN_10042024.Framework.Repositories {
    public class ApiSessionsRepository {
        private readonly ILogger<ApiSessionsRepository> _logger;
        private AppDbContext _dbContext;

        public ApiSessionsRepository(ILogger<ApiSessionsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }


    }
}
