using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions.Queries;
using Clean.Architecture.API.Domain.Entities;

namespace Clean.Architecture.API.Infrastructure.Data.Queries {
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
