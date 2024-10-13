using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class Person : ISchema {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Team { get; private set; }
        public int? Score { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public Person WithName(string name) {
            Name = name;
            return this;
        }

        public Person WithTeam(string team) {
            Team = team;
            return this;
        }

        public Person WithScore(int? score) {
            Score = score; 
            return this;
        }
    }
}
