using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSession : ISchema {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDateTime { get; private set; }

        // Navigation mapper
        public Client Client { get; set; }

        public AuthenticationSession() {
            CreatedDateTime = DateTime.Now;
        }
    }
}
