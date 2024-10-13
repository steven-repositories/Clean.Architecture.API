using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class FilesQueryService : IFilesQueryService {
        private readonly ILogger<FilesQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public FilesQueryService(ILogger<FilesQueryService> logger, AppDbContext dbContext) {
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
