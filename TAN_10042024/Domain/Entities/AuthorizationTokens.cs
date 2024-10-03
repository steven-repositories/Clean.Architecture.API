using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Entities {
    public class AuthorizationTokens : Entity {
        public Guid Token { get; set; }
        [ForeignKey("Clients")]
        public int ClientId { get; set; }
    }
}
