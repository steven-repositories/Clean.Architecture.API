using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IFileRepository {
        Task SaveFile(File file);
    }
}
