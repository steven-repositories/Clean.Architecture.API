using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions {
    public interface IAuthentication {
        Task<Guid> GenerateKey(string clientName);
        Task<AuthenticationSession?> Authenticate(string key);
    }
}
