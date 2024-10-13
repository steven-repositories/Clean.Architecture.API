using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSessionsSchema : Schema {
        public required Guid Key { get; set; }
        [ForeignKey("ClientId")]
        public required ClientsSchema Clients { get; set; }
    }
}
