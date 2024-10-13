using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Abstractions;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Domain.Builders {
    public class PersonBuilder : Builder<PersonBuilder, Person> {
        private string? _name;
        private string? _team;
        private int? _score;

        public PersonBuilder WithName(string name) {
            _name = name;
            return this;
        }

        public PersonBuilder WithTeam(string team) {
            _team = team;
            return this;
        }

        public PersonBuilder WithScore(int? score) {
            _score = score;
            return this;
        }

        public override Person Build() {
            base.Build();

            return new Person() {
                Name = _name!,
                Team = _team!,
                Score = _score
            };
        }

        protected override void SetupValidations() {
            if (_name!.IsNullOrEmpty()) {
                throw new BuilderException("Person Name is required and cannot be null or empty.");
            } else if (_team!.IsNullOrEmpty()) {
                throw new BuilderException("Person Team is required and cannot be null or empty.");
            } else if (_score == default) {
                throw new BuilderException("Person Score cannot be null.");
            }
        }
    }
}
