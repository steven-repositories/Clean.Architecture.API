namespace Clean.Architecture.API.Application.Abstractions {
    public interface IApiSession {
        Task SaveSession(string method, string url);
    }
}
