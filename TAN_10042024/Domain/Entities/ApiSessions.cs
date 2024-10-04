namespace TAN_10042024.Domain.Entities {
    public class ApiSessions : Entity {
        public required string Method { get; set; }
        public required string URL { get; set; }
        public required string FileName { get; set; }
        public required string FileContent { get; set; }
    }
}
