using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;

namespace TAN_10042024.Application.Services {
    public class PersonService : IPerson {
        private readonly ILogger<PersonService> _logger;
        private readonly IPersonRepository _personRepo;
        private readonly IPersonQueryService _personQueryService;

        public PersonService(ILogger<PersonService> logger, IPersonRepository personRepo, IPersonQueryService personQueryService) {
            _logger = logger;
            _personRepo = personRepo;
            _personQueryService = personQueryService;
        }

        public async Task<int?> GetMaxScoreByTeam(string team) {
            var persons = await _personQueryService.GetPersonsByTeam(team);

            return persons.Max(person => person.Score);
        }

        public async Task<int?> GetSecondToLeastScoreByTeam(string team) {
            var persons = await _personQueryService.GetPersonsByTeam(team);

            var secondToLeastScore = persons
                .OrderBy(person => person.Score)
                .Skip(1)
                .Select(person => person.Score)
                .FirstOrDefault();

            return secondToLeastScore;
        }

        public async Task<string> UnionizePersonNamesByTeam(string team) {
            var persons = await _personQueryService.GetPersonsByTeam(team);
            var personNames = persons
                .Select(person => person.Name)
                .ToList();

            return string.Join(", ", personNames);
        }
    }
}
