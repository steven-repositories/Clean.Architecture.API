using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class ApiSession : Entity {
        public required string Method { get; set; }
        public required string URL { get; set; }
    }
}
