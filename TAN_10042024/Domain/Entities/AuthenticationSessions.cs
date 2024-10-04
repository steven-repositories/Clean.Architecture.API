using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSessions : Entity {
        public Guid Key { get; set; }
        [ForeignKey("ClientId")]
        public required Clients Clients { get; set; }
    }
}
