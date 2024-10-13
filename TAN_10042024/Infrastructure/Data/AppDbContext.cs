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

            modelBuilder.Entity<AuthenticationSessionSchema>()
                .HasIndex(auth => auth.Key)
                .IsUnique();
        }
    }
}
