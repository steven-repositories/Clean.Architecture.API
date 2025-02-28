using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Infrastructure.Data.Queries {
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
