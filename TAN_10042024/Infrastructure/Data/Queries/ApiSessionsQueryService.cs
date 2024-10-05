using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class ApiSessionsQueryService {
        private readonly ILogger<ApiSessionsQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionsQueryService(ILogger<ApiSessionsQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<ApiSessions>> GetAll() {
            return _dbContext
                .Set<ApiSessions>()
                .ToListAsync();
        }
    }
}
