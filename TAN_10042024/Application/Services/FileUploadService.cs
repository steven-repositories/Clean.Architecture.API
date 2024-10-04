using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Models;
using TAN_10042024.Utilities;

namespace TAN_10042024.Application.Services {
    public class FileUploadService : IFileUpload {
        public async Task<PersonList> Upload(IFormFile file) {
            var fileContent = await file.ReadFileContent();
            return default;
        }
    }
}
