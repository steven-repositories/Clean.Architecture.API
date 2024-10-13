using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSessionSchema : Schema {
        public required Guid Key { get; set; }
        [ForeignKey("ClientId")]
        public required virtual ClientSchema Client { get; set; }
    }
}
