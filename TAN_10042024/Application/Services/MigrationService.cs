using Microsoft.EntityFrameworkCore;
using TAN_10042024.Application.Abstractions;
using TAN_10042024.Application.Utilities;
using TAN_10042024.Infrastructure.Data;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Application.Services {
    public class MigrationService : IMigration {
        public void ExecuteMigrations(IHost host) {
            var serviceScope = host
                .Services
                .CreateScope();

            var dbContext = serviceScope
                .ServiceProvider
                .GetRequiredService<AppDbContext>()
                .Database;

            try {
                dbContext.Migrate();
            } catch (MigrationException e) {
                throw new MigrationException("Something went wrong during the execution of the migration files : {0}"
                    .FormatWith(e.Message), e);
            }
        }
    }
}
