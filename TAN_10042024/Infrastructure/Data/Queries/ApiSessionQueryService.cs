using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class ApiSessionQueryService : IApiSessionQueryService {
        private readonly ILogger<ApiSessionQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public ApiSessionQueryService(ILogger<ApiSessionQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<ApiSession>> GetAll() {
            return _dbContext
                .Set<ApiSession>()
                .ToListAsync();
        }
    }
}
