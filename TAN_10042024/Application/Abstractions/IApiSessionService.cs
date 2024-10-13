namespace TAN_10042024.Application.Abstractions {
    public interface IApiSessionService {
        Task SaveSession(string method, string url);
    }
}
