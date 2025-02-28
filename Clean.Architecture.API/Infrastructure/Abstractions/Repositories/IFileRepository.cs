using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Application.Abstractions.Repositories {
    public interface IFileRepository {
        Task SaveFile(File file);
    }
}
