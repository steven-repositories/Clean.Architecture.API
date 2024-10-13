using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Application.Builders {
    public class AuthenticationSessionBuilder : Builder<AuthenticationSessionBuilder, AuthenticationSession> {
        private Guid _key;
        private Client? _client;

        public AuthenticationSessionBuilder WithKey(Guid key) {
            _key = key;
            return this;
        }

        public AuthenticationSessionBuilder WithClient(Client client) {
            _client = client;
            return this;
        }

        public override AuthenticationSession Build() {
            base.Build();

            return new AuthenticationSession();
        }

        protected override void SetupValidations() {
            if (_key == default) {
                throw new BuilderException("AuthenticationSession Key is required and cannot be null or empty.");
            } else if (_client == null) {
                throw new BuilderException("AuthenticationSession Client is required and cannot be null.");
            }
        }
    }
}
