namespace TAN_10042024.Application.Abstractions {
    public interface IApiSession {
        Task SaveSession(string method, string url);
    }
}
