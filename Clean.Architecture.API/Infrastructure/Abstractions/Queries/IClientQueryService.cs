using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Queries {
    public interface IClientQueryService {
        Task<Client?> GetClientByName(string clientName);
    }
}
