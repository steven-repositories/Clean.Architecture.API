using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions.Queries {
    public interface IClientsQueryService {
        Task<Clients?> GetClientByName(string clientName);
    }
}
