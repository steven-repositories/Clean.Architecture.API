using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Framework.Repositories;
using TAN_10042024.Utilities;

namespace TAN_10042024.Application.Services {
    public class FileUploadService : IFileUploadService {
        private readonly ILogger<FileUploadService> _logger;
        private readonly PersonsRepository _personsRepo;

        public FileUploadService(ILogger<FileUploadService> logger, PersonsRepository personsRepo) {
            _logger = logger;
            _personsRepo = personsRepo;
        }

        public void Upload(string fileContent) {
            _logger.LogInformation("Deserializing the json content...");

            var deserializedContent = JsonConvert
                .DeserializeObject<PersonList>(fileContent);

            if (deserializedContent != null) {
                var persons = deserializedContent.Persons;
                _personsRepo.SavePersons(persons);
            }
        }
    }
}
