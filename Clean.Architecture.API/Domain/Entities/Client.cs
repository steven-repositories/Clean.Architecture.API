using Clean.Architecture.API.Domain.Abstractions;

namespace Clean.Architecture.API.Domain.Entities {
    public class Client : Entity {
        public required string Name { get; set; }

        // Navigation mapper
        public virtual ICollection<AuthenticationSession>? AuthenticationSessions { get; set; }
    }
}
