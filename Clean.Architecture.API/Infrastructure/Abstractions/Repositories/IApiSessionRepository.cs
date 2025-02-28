using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Repositories {
    public interface IApiSessionRepository {
        Task SaveApiSession(ApiSession session);
    }
}
