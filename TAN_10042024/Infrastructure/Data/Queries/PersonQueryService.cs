using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class PersonQueryService : IPersonQueryService {
        private ILogger<PersonQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public PersonQueryService(ILogger<PersonQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<Person>> GetPersonsByTeam(string team) {
            return _dbContext
                .Set<Person>()
                .Where(person => person.Team == team)
                .ToListAsync();
        }
    }
}
