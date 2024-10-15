using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Infrastructure.Data;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Application.Services {
    public class MigrationService : IMigration {
        private readonly ILogger<MigrationService> _logger;

        public MigrationService(ILogger<MigrationService> logger) {
            _logger = logger;
        }

        public void ExecuteMigrations(IHost host) {
            try {
                var serviceScope = host
                .Services
                .CreateScope();

                var dbContext = serviceScope
                    .ServiceProvider
                    .GetRequiredService<AppDbContext>()
                    .Database;

                _logger.LogInformation("Migrating all the migration files...");

                dbContext.Migrate();

                _logger.LogInformation("Migration complete!");
            } catch (MigrationException e) {
                _logger.LogError(e.Message);

                throw new MigrationException("Something went wrong during the execution of the migration files : {0}"
                    .FormatWith(e.Message), e);
            }
        }
    }
}
