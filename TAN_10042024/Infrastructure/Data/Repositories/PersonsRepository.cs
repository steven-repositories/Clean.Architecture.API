using TAN_10042024.Application.Abstractions.Repositories;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Infrastructure.Data.Repositories {
    public class PersonsRepository : IPersonsRepository {
        private readonly ILogger<PersonsRepository> _logger;
        private readonly AppDbContext _dbContext;

        public PersonsRepository(ILogger<PersonsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SavePersons(List<Person> persons) {
            foreach (var person in persons) {
                try {
                    _logger.LogInformation("Adding person {0} details to the database..."
                        .FormatWith(person.Name!));

                    var newPerson = new Person()
                        .WithName(person.Name!)
                        .WithTeam(person.Team!)
                        .WithScore(person.Score!);

                    await _dbContext
                        .Set<Person>()
                        .AddAsync(newPerson);

                    var personId = await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("Person {0} details is saved to the database with key of: {1}"
                       .FormatWith(newPerson.Name!, personId));
                } catch (Exception e) {
                    var errorMessage = "Error encountered when saving persons: {0}"
                        .FormatWith(e.Message);

                    _logger.LogError(errorMessage);
                    throw new RepositoryException(errorMessage, e);
                }
            }
        }
    }
}
