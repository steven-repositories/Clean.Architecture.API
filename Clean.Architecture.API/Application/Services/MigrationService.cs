using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Infrastructure.Data;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Application.Services {
    public class MigrationService : IMigration {
        public void ExecuteMigrations(IHost host) {
            try {
                var serviceScope = host
                .Services
                .CreateScope();

                var dbContext = serviceScope
                    .ServiceProvider
                    .GetRequiredService<AppDbContext>()
                    .Database;

                dbContext.Migrate();
            } catch (MigrationException e) {
                throw new MigrationException("Something went wrong during the execution of the migration files : {0}"
                    .FormatWith(e.Message), e);
            }
        }
    }
}
