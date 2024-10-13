namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IApiSessionsRepository {
        Task SaveApiSession(string method, string url);
    }
}
