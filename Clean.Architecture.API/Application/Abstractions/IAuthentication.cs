using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions {
    public interface IAuthentication {
        Task<Guid> GenerateKey(string clientName);
        Task<AuthenticationSession?> Authenticate(string key);
    }
}
