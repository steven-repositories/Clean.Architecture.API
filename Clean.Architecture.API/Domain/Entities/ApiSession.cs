using Clean.Architecture.API.Domain.Abstractions;

namespace Clean.Architecture.API.Domain.Entities {
    public class ApiSession : Entity {
        public required string Method { get; set; }
        public required string URL { get; set; }
    }
}
