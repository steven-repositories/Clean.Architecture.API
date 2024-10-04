namespace TAN_10042024.Domain.Entities {
    public class ApiSessions : Entity {
        public required string Method { get; set; }
        public required string URL { get; set; }
    }
}
