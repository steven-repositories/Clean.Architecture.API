using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Infrastructure.Data.Repositories;

namespace TAN_10042024.Application.Services {
    public class FileUploadService : IFileUploadService {
        private readonly ILogger<FileUploadService> _logger;
        private readonly PersonsRepository _personsRepo;
        private readonly FilesRepository _filesRepo;

        public FileUploadService(ILogger<FileUploadService> logger, PersonsRepository personsRepo, FilesRepository filesRepo) {
            _logger = logger;
            _personsRepo = personsRepo;
            _filesRepo = filesRepo;
        }

        public async Task Upload(string fileName, string fileContent) {
            _logger.LogInformation("Deserializing the json content...");

            var deserializedContent = JsonConvert
                .DeserializeObject<PersonList>(fileContent);

            if (deserializedContent != null) {
                var persons = deserializedContent.Persons;
                await _personsRepo.SavePersons(persons);
            }

            await _filesRepo.SaveFile(fileName, fileContent);
        }
    }
}
