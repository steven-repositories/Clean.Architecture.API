using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSession : IEntity {
        public int Id { get; private set; }
        public Guid Key { get; private set; }
        public Client? Client { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public AuthenticationSession WithKey(Guid key) {
            Key = key;
            return this;
        }

        public AuthenticationSession WithClient(Client? client) {
            Client = client;
            return this;
        }
    }
}
