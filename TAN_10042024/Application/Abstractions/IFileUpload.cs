using TAN_10042024.Application.Models;

namespace TAN_10042024.Application.Abstractions {
    public interface IFileUpload {
        Task Upload(string fileName, string fileContent);
    }
}
