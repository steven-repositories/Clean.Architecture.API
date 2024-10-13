using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Application.Abstractions.Queries {
    public interface IFileQueryService {
        Task<List<File>> GetAll();
    }
}
