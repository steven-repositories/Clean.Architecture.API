using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Repositories {
    public interface IAuthenticationSessionRepository {
        Task SaveAuthKey(AuthenticationSession authSession);
    }
}
