using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Models;
using Clean.Architecture.API.Domain.Factories;
using Newtonsoft.Json;

namespace Clean.Architecture.API.Application.Services {
    public class FileUploadService : IFileUpload {
        private readonly ILogger<FileUploadService> _logger;
        private readonly IPersonRepository _personRepo;
        private readonly IFileRepository _fileRepo;
        private readonly FileBuilderFactory _fileBuilderFactory;
        private readonly PersonBuilderFactory _personBuilderFactory;

        public FileUploadService(ILogger<FileUploadService> logger, IPersonRepository personRepo, IFileRepository fileRepo, 
            FileBuilderFactory fileBuilderFactory, PersonBuilderFactory personBuilderFactory) {
            _logger = logger;
            _personRepo = personRepo;
            _fileRepo = fileRepo;
            _fileBuilderFactory = fileBuilderFactory;
            _personBuilderFactory = personBuilderFactory;
        }

        public async Task Upload(string fileName, string fileContent) {
            _logger.LogInformation("Deserializing the json content...");

            var deserializedContent = JsonConvert
                .DeserializeObject<PersonList>(fileContent);

            if (deserializedContent != null) {
                var persons = deserializedContent.Persons;

                foreach (var person in persons) {
                    var personBuilder = _personBuilderFactory
                        .CreateBuilder();

                    var newPerson = personBuilder
                        .WithName(person.Name!)
                        .WithTeam(person.Team!)
                        .WithScore(person.Score!)
                        .Build();

                    await _personRepo.SavePerson(newPerson);
                }
            }

            var fileBuilder = _fileBuilderFactory
                .CreateBuilder();

            var newFile = fileBuilder
                .WithName(fileName)
                .WithContent(fileContent)
                .Build();

            await _fileRepo.SaveFile(newFile);
        }
    }
}
