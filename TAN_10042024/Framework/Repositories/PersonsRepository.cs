using TAN_10042024.Application.Data;
using TAN_10042024.Application.Models;
using TAN_10042024.Domain.Entities;
using TAN_10042024.Utilities;
using static TAN_10042024.Utilities.Exceptions;

namespace TAN_10042024.Framework.Repositories {
    public class PersonsRepository {
        private readonly ILogger<PersonsRepository> _logger;
        private readonly AppDbContext _dbContext;

        public PersonsRepository(ILogger<PersonsRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void SavePersons(List<Person> persons) {
            persons.ForEach((person) => {
                try {
                    var newPerson = new Persons() {
                        Name = person.Name,
                        Team = person.Team,
                        Score = person.Score ?? default
                    };

                    _logger.LogInformation("Adding person {0} details to the database..."
                        .FormatWith(person.Name));

                    _dbContext
                        .Set<Persons>()
                        .Add(newPerson);

                    _dbContext.SaveChanges();

                    _logger.LogInformation("Person {0} details is saved to the database!"
                       .FormatWith(person.Name));
                } catch (Exception e) {
                    var errorMessage = "Error encountered when saving persons: {0}"
                        .FormatWith(e.Message);

                    _logger.LogError(errorMessage);
                    throw new RepositoryException(errorMessage, e);
                }
            });
        }
    }
}
