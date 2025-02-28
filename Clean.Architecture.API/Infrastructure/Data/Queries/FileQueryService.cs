using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions.Queries;
using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Infrastructure.Data.Queries {
    public class FileQueryService : IFileQueryService {
        private readonly ILogger<FileQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public FileQueryService(ILogger<FileQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<File>> GetAll() {
            return _dbContext
                .Set<File>()
                .ToListAsync();
        }
    }
}
