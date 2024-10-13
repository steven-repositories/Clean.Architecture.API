using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Application.Abstractions.Queries {
    public interface IFilesQueryService {
        Task<List<File>> GetAll();
    }
}
