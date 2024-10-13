using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IApiSessionRepository {
        Task SaveApiSession(ApiSession session);
    }
}
