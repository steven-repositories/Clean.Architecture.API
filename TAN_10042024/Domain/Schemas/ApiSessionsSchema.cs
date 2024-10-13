namespace TAN_10042024.Domain.Entities {
    public class ApiSessionsSchema : Schema {
        public required string Method { get; set; }
        public required string URL { get; set; }
    }
}
