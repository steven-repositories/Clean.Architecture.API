using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Services
{
    public class FileUploadService : IFileUploadService {
        private readonly ILogger<FileUploadService> _logger;
        private readonly IPersonsRepository _personsRepo;
        private readonly IFilesRepository _filesRepo;

        public FileUploadService(ILogger<FileUploadService> logger, IPersonsRepository personsRepo, IFilesRepository filesRepo) {
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
