namespace TAN_10042024.Domain.Entities {
    public class Persons : Entity {
        public required string Name { get; set; }
        public required string Team { get; set; }
        public int Score { get; set; }
    }
}
