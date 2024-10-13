using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Infrastructure.Data {
    public class AppDbContext : DbContext {
        public DbSet<AuthenticationSessionsSchema> AuthenticationSessions { get; set; }
        public DbSet<ClientsSchema> Clients { get; set; }
        public DbSet<ApiSessionsSchema> ApiSessions { get; set; }
        public DbSet<PersonsSchema> Persons { get; set; }
        public DbSet<FilesSchema> Files { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthenticationSessionsSchema>()
                .HasIndex(i => i.Key)
                .IsUnique();
        }
    }
}
