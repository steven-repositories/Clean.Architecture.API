using Microsoft.EntityFrameworkCore;

namespace TAN_10042024.Application.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
