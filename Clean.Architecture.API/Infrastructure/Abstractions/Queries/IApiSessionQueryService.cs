using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Queries {
    public interface IApiSessionQueryService {
        Task<List<ApiSession>> GetAll();
    }
}
