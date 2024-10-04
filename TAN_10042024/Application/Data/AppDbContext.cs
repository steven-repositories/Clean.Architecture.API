using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Data {
    public class AppDbContext : DbContext {
        public DbSet<AuthenticationSessions> AuthenticationSessions { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ApiSessions> ApiSessions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthenticationSessions>()
                .HasIndex(i => i.Key)
                .IsUnique();
        }
    }
}
