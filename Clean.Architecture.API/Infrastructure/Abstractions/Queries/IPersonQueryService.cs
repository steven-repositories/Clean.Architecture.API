using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Application.Abstractions.Queries {
    public interface IPersonQueryService {
        Task<List<Person>> GetPersonsByTeam(string team);
    }
}
