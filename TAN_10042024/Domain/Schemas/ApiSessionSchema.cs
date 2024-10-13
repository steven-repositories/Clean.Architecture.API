namespace TAN_10042024.Domain.Entities {
    public class ApiSessionSchema : Schema {
        public required string Method { get; set; }
        public required string URL { get; set; }
    }
}
