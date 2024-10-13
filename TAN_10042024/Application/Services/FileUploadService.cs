using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Models;
using TAN_10042024.Domain.Builders;

namespace TAN_10042024.Application.Services {
    public class FileUploadService : IFileUploadService {
        private readonly ILogger<FileUploadService> _logger;
        private readonly IPersonRepository _personsRepo;
        private readonly IFileRepository _filesRepo;

        public FileUploadService(ILogger<FileUploadService> logger, IPersonRepository personsRepo, IFileRepository filesRepo) {
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

                foreach (var person in persons) {
                    var newPerson = PersonBuilder
                        .Initialize()
                        .WithName(person.Name!)
                        .WithTeam(person.Team!)
                        .WithScore(person.Score!)
                        .Build();

                    await _personsRepo.SavePerson(newPerson);
                }
            }

            var newFile = FileBuilder
                .Initialize()
                .WithName(fileName)
                .WithContent(fileContent)
                .Build();

            await _filesRepo.SaveFile(newFile);
        }
    }
}
