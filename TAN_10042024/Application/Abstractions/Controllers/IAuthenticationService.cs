using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions.Controllers {
    public interface IAuthenticationService {
        Task<Guid> GenerateKey(string clientName);
        Task<AuthenticationSessions?> Authenticate(string key);
    }
}
