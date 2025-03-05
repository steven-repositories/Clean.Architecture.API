using Clean.Architecture.API.Domain.Builders;

namespace Clean.Architecture.API.Domain.Factories {
    public class ApiSessionBuilderFactory {
        private readonly ILogger<ApiSessionBuilder> _logger;

        public ApiSessionBuilderFactory(ILogger<ApiSessionBuilder> logger)
        {
            _logger = logger;
        }

        public ApiSessionBuilder CreateBuilder() {
            return new ApiSessionBuilder(_logger);
        }
    }
}
