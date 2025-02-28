using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Utilities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;
using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Infrastructure.Data.Repositories {
    public class FileRepository : IFileRepository {
        private readonly ILogger<FileRepository> _logger;
        private readonly AppDbContext _dbContext;

        public FileRepository(ILogger<FileRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SaveFile(File file) {
            try {
                _logger.LogInformation("Saving to database the file {0}"
                    .FormatWith(file.Name));

                await _dbContext
                    .Set<File>()
                    .AddAsync(file);

                var fileId = await _dbContext.SaveChangesAsync();

                _logger.LogInformation("File {0} is saved to database with key of: {1}"
                    .FormatWith(file.Name, fileId));
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving the file: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
