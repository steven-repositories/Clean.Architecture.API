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

            #region AuthenticationSession Schema
            modelBuilder.Entity<AuthenticationSessionSchema>()
                .Property(auth => auth.Key)
                .IsRequired();
            #endregion

            #region Client Schema
            modelBuilder.Entity<ClientSchema>()
                .Property(client => client.Name)
                .IsRequired();
            #endregion

            #region ApiSession Schema
            modelBuilder.Entity<ApiSessionSchema>()
                .Property(apiSession => apiSession.Method)
                .IsRequired();

            modelBuilder.Entity<ApiSessionSchema>()
                .Property(apiSession => apiSession.URL)
                .IsRequired();
            #endregion

            #region Person Schema
            modelBuilder.Entity<PersonSchema>()
                .Property(person => person.Name)
                .IsRequired();

            modelBuilder.Entity<PersonSchema>()
                .Property(person => person.Team)
                .IsRequired();
            #endregion

            #region File Schema
            modelBuilder.Entity<FileSchema>()
                .Property(file => file.Name)
                .IsRequired();

            modelBuilder.Entity<FileSchema>()
                .Property(file => file.Content)
                .IsRequired();
            #endregion
        }
    }
}
