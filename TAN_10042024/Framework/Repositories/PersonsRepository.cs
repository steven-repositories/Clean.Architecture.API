using Microsoft.EntityFrameworkCore;
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

        public Task<List<Persons>> GetPersonsByTeam(string team) {
            return _dbContext
                .Set<Persons>()
                .Where(person => person.Team == team)
                .ToListAsync();
        }

        public async Task SavePersons(List<Person> persons) {
            foreach (var person in persons) {
                try {
                    var newPerson = new Persons() {
                        Name = person.Name,
                        Team = person.Team,
                        Score = person.Score ?? default
                    };

                    _logger.LogInformation("Adding person {0} details to the database..."
                        .FormatWith(person.Name));

                    await _dbContext
                        .Set<Persons>()
                        .AddAsync(newPerson);

                    var personId = await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("Person {0} details is saved to the database with key of: {1}"
                       .FormatWith(person.Name, personId));
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
