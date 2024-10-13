namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IAuthenticationSessionRepository {
        Task SaveAuthKey(Guid key, string clientName);
    }
}
