using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data.Queries {
    public class PersonsQueryService : IPersonsQueryService {
        private ILogger<PersonsQueryService> _logger;
        private readonly AppDbContext _dbContext;

        public PersonsQueryService(ILogger<PersonsQueryService> logger, AppDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<List<PersonSchema>> GetPersonsByTeam(string team) {
            return _dbContext
                .Set<PersonSchema>()
                .Where(person => person.Team == team)
                .ToListAsync();
        }
    }
}
