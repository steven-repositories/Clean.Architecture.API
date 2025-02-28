using Microsoft.EntityFrameworkCore;
using Clean.Architecture.API.Domain.Entities;
using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Infrastructure.Data {
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

                schema
                    .HasOne(auth => auth.Client)
                    .WithMany(client => client.AuthenticationSessions)
                    .HasForeignKey(auth => auth.ClientId);
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
