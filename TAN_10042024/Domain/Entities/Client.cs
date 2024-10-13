using System.Runtime.Serialization;
using TAN_10042024.Domain.Abstractions;

namespace TAN_10042024.Domain.Entities {
    public class Client : ISchema {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        // Navigation mapper
        public virtual ICollection<AuthenticationSession>? AuthenticationSessions { get; set; }

        public Client WithName(string name) {
            Name = name;
            return this;
        }
    }
}
