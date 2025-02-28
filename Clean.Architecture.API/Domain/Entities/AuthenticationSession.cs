using Clean.Architecture.API.Domain.Abstractions;

namespace Clean.Architecture.API.Domain.Entities {
    public class AuthenticationSession : Entity {
        public required Guid Key { get; set; }
        public int ClientId { get; set; }

        // Navigation mapper
        public required Client Client { get; set; }
    }
}
