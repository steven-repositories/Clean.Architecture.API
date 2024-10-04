using TAN_10042024.Application.Data;
using static TAN_10042024.Utilities.Exceptions;
using TAN_10042024.Utilities;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Framework.Repositories {
    public class FilesRepository {
        private readonly ILogger<FilesRepository> _logger;
        private readonly AppDbContext _dbContext;

        public FilesRepository(ILogger<FilesRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<Files> GetAll() {
            return _dbContext
                .Set<Files>()
                .ToList();
        }

        public void SaveFile(string fileName, string fileContent) {
            try {
                _logger.LogInformation("Saving to database the file {0}"
                    .FormatWith(fileName));

                var newFile = new Files() {
                    FileName = fileName,
                    FileContent = fileContent
                };

                _dbContext
                    .Set<Files>()
                    .Add(newFile);

                _dbContext.SaveChanges();

                _logger.LogInformation("File {0} is saved to database!"
                    .FormatWith(fileName));
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving the file: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
