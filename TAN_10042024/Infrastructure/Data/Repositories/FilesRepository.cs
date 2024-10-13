using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Infrastructure.Data.Repositories {
    public class FilesRepository : IFilesRepository {
        private readonly ILogger<FilesRepository> _logger;
        private readonly AppDbContext _dbContext;

        public FilesRepository(ILogger<FilesRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SaveFile(string fileName, string fileContent) {
            try {
                _logger.LogInformation("Saving to database the file {0}"
                    .FormatWith(fileName));

                var newFile = new FileSchema() {
                    FileName = fileName,
                    FileContent = fileContent
                };

                await _dbContext
                    .Set<FileSchema>()
                    .AddAsync(newFile);

                var fileId = await _dbContext.SaveChangesAsync();

                _logger.LogInformation("File {0} is saved to database with key of: {1}"
                    .FormatWith(fileName, fileId));
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving the file: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
