using Clean.Architecture.API.Domain.Builders;

namespace Clean.Architecture.API.Domain.Factories {
    public class AuthenticationSessionBuilderFactory {
        private readonly ILogger<AuthenticationSessionBuilder> _logger;

        public AuthenticationSessionBuilderFactory(ILogger<AuthenticationSessionBuilder> logger) {
            _logger = logger;
        }

        public AuthenticationSessionBuilder CreateBuilder() {
            return new AuthenticationSessionBuilder(_logger);
        }
    }
}
