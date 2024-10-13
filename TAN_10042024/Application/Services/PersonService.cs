using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Abstractions.Queries;
using TAN_10042024.Application.Abstractions.Repositories;

namespace TAN_10042024.Application.Services {
    public class PersonService : IPersonService {
        private readonly ILogger<PersonService> _logger;
        private readonly IPersonsRepository _personsRepo;
        private readonly IPersonsQueryService _personsQueryService;

        public PersonService(ILogger<PersonService> logger, IPersonsRepository personsRepo, IPersonsQueryService personsQueryService) {
            _logger = logger;
            _personsRepo = personsRepo;
            _personsQueryService = personsQueryService;
        }

        public async Task<int?> GetMaxScoreByTeam(string team) {
            var persons = await _personsQueryService.GetPersonsByTeam(team);

            return persons.Max(person => person.Score);
        }

        public async Task<int?> GetSecondToLeastScoreByTeam(string team) {
            var persons = await _personsQueryService.GetPersonsByTeam(team);

            var secondToLeastScore = persons
                .OrderBy(person => person.Score)
                .Skip(1)
                .Select(person => person.Score)
                .FirstOrDefault();

            return secondToLeastScore;
        }

        public async Task<string> UnionizePersonNamesByTeam(string team) {
            var persons = await _personsQueryService.GetPersonsByTeam(team);
            var personNames = persons
                .Select(person => person.Name)
                .ToList();

            return string.Join(", ", personNames);
        }
    }
}
