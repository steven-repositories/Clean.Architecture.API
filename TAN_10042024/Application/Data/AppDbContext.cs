using Microsoft.EntityFrameworkCore;
using TAN_10042024.Domain.Entities;

namespace TAN_10042024.Application.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AuthorizationTokens> AuthTokens { get; set; }
    }
}
