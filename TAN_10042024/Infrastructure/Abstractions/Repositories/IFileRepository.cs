namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IFileRepository {
        Task SaveFile(string fileName, string fileContent);
    }
}
