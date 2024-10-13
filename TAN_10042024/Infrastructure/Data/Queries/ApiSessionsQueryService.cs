using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class ApiSessionsQueryService : IApiSessionsQueryService {
        private readonly ILogger<ApiSessionsQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionsQueryService(ILogger<ApiSessionsQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<ApiSessionsSchema>> GetAll() {
            return _dbContext
                .Set<ApiSessionsSchema>()
                .ToListAsync();
        }
    }
}
