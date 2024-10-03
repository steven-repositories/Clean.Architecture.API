using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions {
    public interface IAuthenticationService {
        Guid GenerateToken();
        Task<AuthorizationTokens?> Authenticate(string token);
    }
}
