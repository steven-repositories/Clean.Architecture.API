namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IApiSessionRepository {
        Task SaveApiSession(string method, string url);
    }
}
