using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Queries {
    public interface IAuthenticationSessionQueryService {
        Task<AuthenticationSession?> GetAuthDetailsByKey(string key);
    }
}
