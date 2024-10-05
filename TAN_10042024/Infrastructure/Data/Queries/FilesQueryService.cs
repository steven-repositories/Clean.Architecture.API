using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class FilesQueryService {
        private readonly ILogger<FilesQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public FilesQueryService(ILogger<FilesQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<Files>> GetAll() {
            return _dbContext
                .Set<Files>()
                .ToListAsync();
        }
    }
}
