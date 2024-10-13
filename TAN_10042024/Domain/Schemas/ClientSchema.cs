using System.Runtime.Serialization;

namespace TAN_10042024.Domain.Entities {
    public class ClientSchema : Schema {
        public required string Name { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<AuthenticationSessionSchema> AuthenticationSessions { get; set; }
    }
}
