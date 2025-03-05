using Clean.Architecture.API.Domain.Builders;

namespace Clean.Architecture.API.Domain.Factories {
    public class FileBuilderFactory {
        private readonly ILogger<FileBuilder> _logger;

        public FileBuilderFactory(ILogger<FileBuilder> logger) {
            _logger = logger;
        }

        public FileBuilder CreateBuilder() {
            return new FileBuilder(_logger);
        }
    }
}
