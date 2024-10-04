using Newtonsoft.Json;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Framework.Repositories;
using TAN_10042024.Utilities;

namespace TAN_10042024.Application.Services {
    public class FileUploadService : IFileUpload {
        private readonly ILogger<FileUploadService> _logger;
        private readonly PersonsRepository _personsRepo;

        public FileUploadService(ILogger<FileUploadService> logger, PersonsRepository personsRepo) {
            _logger = logger;
            _personsRepo = personsRepo;
        }

        public async Task<PersonList> Upload(IFormFile file) {
            var fileContent = await file.ReadFileContent();

            var persons = JsonConvert
                .DeserializeObject<PersonList>(fileContent);


            return default;
        }
    }
}
