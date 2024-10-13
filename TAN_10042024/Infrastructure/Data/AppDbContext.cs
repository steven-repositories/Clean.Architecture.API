using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data {
    public class AppDbContext : DbContext {
        public DbSet<AuthenticationSessionSchema> AuthenticationSessions { get; set; }
        public DbSet<ClientSchema> Clients { get; set; }
        public DbSet<ApiSessionSchema> ApiSessions { get; set; }
        public DbSet<PersonSchema> Persons { get; set; }
        public DbSet<FileSchema> Files { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthenticationSessionSchema>(schema => {
                schema
                    .Property(auth => auth.Key)
                    .IsRequired();

                schema
                    .HasIndex(auth => auth.Key)
                    .IsUnique();
            });

            modelBuilder.Entity<ClientSchema>()
                .Property(client => client.Name)
                .IsRequired();

            modelBuilder.Entity<ApiSessionSchema>(schema => {
                schema
                    .Property(apiSession => apiSession.Method)
                    .IsRequired();

                schema
                    .Property(apiSession => apiSession.URL)
                    .IsRequired();
            });

            modelBuilder.Entity<PersonSchema>(schema => {
                schema
                    .Property(person => person.Name)
                    .IsRequired();

                schema
                    .Property(person => person.Team)
                    .IsRequired();
            });

            modelBuilder.Entity<FileSchema>(schema => {
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
