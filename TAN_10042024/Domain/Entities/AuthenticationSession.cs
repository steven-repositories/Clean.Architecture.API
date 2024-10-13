using System.ComponentModel.DataAnnotations.Schema;

namespace TAN_10042024.Domain.Entities {
    public class AuthenticationSession {
        public Guid? Key { get; private set; }
        public ClientSchema? Client { get; private set; }
    }
}
