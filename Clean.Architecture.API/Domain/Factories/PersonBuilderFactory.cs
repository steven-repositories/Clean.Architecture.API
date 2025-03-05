using Clean.Architecture.API.Domain.Builders;

namespace Clean.Architecture.API.Domain.Factories {
    public class PersonBuilderFactory {
        private readonly ILogger<PersonBuilder> _logger;

        public PersonBuilderFactory(ILogger<PersonBuilder> logger) {
            _logger = logger;
        }

        public PersonBuilder CreateBuilder() {
            return new PersonBuilder(_logger);
        }
    }
}
