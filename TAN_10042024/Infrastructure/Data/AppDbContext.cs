using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;
using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Infrastructure.Data {
    public class AppDbContext : DbContext {
        public DbSet<AuthenticationSession> AuthenticationSessions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ApiSession> ApiSessions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<File> Files { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthenticationSession>(schema => {
                schema
                    .Property(auth => auth.Key)
                    .IsRequired();

                schema
                    .HasIndex(auth => auth.Key)
                    .IsUnique();
            });

            modelBuilder.Entity<Client>()
                .Property(client => client.Name)
                .IsRequired();

            modelBuilder.Entity<ApiSession>(schema => {
                schema
                    .Property(apiSession => apiSession.Method)
                    .IsRequired();

                schema
                    .Property(apiSession => apiSession.URL)
                    .IsRequired();
            });

            modelBuilder.Entity<Person>(schema => {
                schema
                    .Property(person => person.Name)
                    .IsRequired();

                schema
                    .Property(person => person.Team)
                    .IsRequired();
            });

            modelBuilder.Entity<File>(schema => {
                schema
                    .Property(file => file.Name)
                    .IsRequired();

                schema
                    .Property(file => file.Content)
                    .IsRequired();
            });
        }
    }
}
