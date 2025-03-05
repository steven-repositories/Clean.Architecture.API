using Clean.Architecture.API.Domain.Abstractions;
using Clean.Architecture.API.Domain.Entities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Domain.Builders {
    public class AuthenticationSessionBuilder : Builder<AuthenticationSession> {
        private readonly ILogger<AuthenticationSessionBuilder> _logger;

        private Guid _key;
        private Client? _client;

        public AuthenticationSessionBuilder(ILogger<AuthenticationSessionBuilder> logger) {
            _logger = logger;
        }

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

            return new AuthenticationSession() {
                Key = _key,
                Client = _client!
            };
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
