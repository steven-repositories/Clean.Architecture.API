using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class Person : Entity {
        public required string Name { get; set; }
        public required string Team { get; set; }
        public int? Score { get; set; }
    }
}
