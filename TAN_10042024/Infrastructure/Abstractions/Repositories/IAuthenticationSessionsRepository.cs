namespace TAN_10042024.Application.Abstractions.Repositories {
    public interface IAuthenticationSessionsRepository {
        Task SaveAuthKey(Guid key, string clientName);
    }
}
