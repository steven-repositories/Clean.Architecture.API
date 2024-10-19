using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class Client : Entity {
        public required string Name { get; set; }

        // Navigation mapper
        public virtual ICollection<AuthenticationSession>? AuthenticationSessions { get; set; }
    }
}
