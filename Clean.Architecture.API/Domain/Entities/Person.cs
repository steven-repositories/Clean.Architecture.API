using Clean.Architecture.API.Domain.Abstractions;

namespace Clean.Architecture.API.Domain.Entities {
    public class Person : Entity {
        public required string Name { get; set; }
        public required string Team { get; set; }
        public int? Score { get; set; }
    }
}
