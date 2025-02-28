using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Application.Abstractions.Queries {
    public interface IFileQueryService {
        Task<List<File>> GetAll();
    }
}
