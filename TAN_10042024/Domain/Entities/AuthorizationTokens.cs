namespace TAN_10042024.Domain.Entities {
    public class AuthorizationTokens : Entity {
        public Guid Token { get; set; }
        public int ClientId { get; set; }
    }
}
