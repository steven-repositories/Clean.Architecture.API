namespace TAN_10042024.Domain.Entities {
    public class PersonsSchema : Schema {
        public required string Name { get; set; }
        public required string Team { get; set; }
        public int Score { get; set; }
    }
}
