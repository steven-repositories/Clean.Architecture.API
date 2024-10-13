using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions.Queries {
    public interface IPersonQueryService {
        Task<List<Person>> GetPersonsByTeam(string team);
    }
}
