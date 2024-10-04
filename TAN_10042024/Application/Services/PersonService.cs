﻿using TAN_10042024.Application.Abstractions;
using TAN_10042024.Framework.Repositories;

namespace TAN_10042024.Application.Services {
    public class PersonService : IPersonService {
        private readonly ILogger<PersonService> _logger;
        private readonly PersonsRepository _personsRepo;

        public PersonService(ILogger<PersonService> logger, PersonsRepository personsRepo) {
            _logger = logger;
            _personsRepo = personsRepo;
        }

        public int GetMaxScoreByTeam(string team) {
            var persons = _personsRepo.GetPersonsByTeam(team);

            return persons.Max(person => person.Score);
        }

        public int GetSecondToLeastScoreByTeam(string team) {
            var persons = _personsRepo.GetPersonsByTeam(team);

            var secondToLeastScore = persons
                .OrderBy(person => person.Score)
                .Skip(1)
                .Select(person => person.Score)
                .FirstOrDefault();

            return secondToLeastScore;
        }

        public string UnionizePersonNamesByTeam(string team) {
            var persons = _personsRepo.GetPersonsByTeam(team);
            var personNames = persons
                .Select(person => person.Name)
                .ToList();

            return string.Join(",", personNames);
        }
    }
}
