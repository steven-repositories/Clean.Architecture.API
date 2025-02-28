using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Abstractions.Repositories
{
    public interface IPersonRepository {
        Task SavePerson(Person person);
    }
}
