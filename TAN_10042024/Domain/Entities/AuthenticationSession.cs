using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSession : Entity {
        public required Guid Key { get; set; }
        public int ClientId { get; set; }

        // Navigation mapper
        public required Client Client { get; set; }
    }
}
