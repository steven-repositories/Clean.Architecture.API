using Clean.Architecture.API.Application.Abstractions.Repositories;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Entities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Infrastructure.Data.Repositories {
    public class PersonRepository : IPersonRepository {
        private readonly ILogger<PersonRepository> _logger;
        private readonly AppDbContext _dbContext;

        public PersonRepository(ILogger<PersonRepository> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SavePerson(Person person) {
            try {
                _logger.LogInformation("Adding person {0} details to the database..."
                    .FormatWith(person.Name!));

                await _dbContext
                    .Set<Person>()
                    .AddAsync(person);

                var personId = await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Person {0} details is saved to the database with key of: {1}"
                   .FormatWith(person.Name!, personId));
            } catch (Exception e) {
                var errorMessage = "Error encountered when saving persons: {0}"
                    .FormatWith(e.Message);

                _logger.LogError(errorMessage);
                throw new RepositoryException(errorMessage, e);
            }
        }
    }
}
