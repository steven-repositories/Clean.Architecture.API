using Clean.Architecture.API.Application.Models;

namespace Clean.Architecture.API.Application.Abstractions {
    public interface IFileUpload {
        Task Upload(string fileName, string fileContent);
    }
}
