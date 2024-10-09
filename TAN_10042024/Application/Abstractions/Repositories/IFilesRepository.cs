namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IFilesRepository {
        Task SaveFile(string fileName, string fileContent);
    }
}
