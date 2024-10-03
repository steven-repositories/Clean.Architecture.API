namespace TAN_10042024.Framework.Repositories {
    public class AuthorizationTokensRepository {
        private readonly ILogger<AuthorizationTokensRepository> _logger;

        public AuthorizationTokensRepository(ILogger<AuthorizationTokensRepository> logger) {
            _logger = logger;
        }


    }
}
