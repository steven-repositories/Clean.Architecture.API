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

            #region AuthenticationSession Entity
            modelBuilder.Entity<AuthenticationSession>()
                .Property(auth => auth.Key)
                .IsRequired();

            modelBuilder.Entity<AuthenticationSession>()
                .Property(auth => auth.Client)
                .IsRequired();

            modelBuilder.Entity<AuthenticationSession>()
                .HasIndex(auth => auth.Key)
                .IsUnique();

            modelBuilder.Entity<AuthenticationSession>()
                .HasOne(auth => auth.Client)
                .WithMany(client => client.AuthenticationSessions)
                .HasForeignKey(auth => auth.Client!.Id);
            #endregion

            #region Client Entity
            modelBuilder.Entity<Client>()
                .Property(client => client.Name)
                .IsRequired();
            #endregion

            #region ApiSession Entity
            modelBuilder.Entity<ApiSession>()
                .Property(apiSession => apiSession.Method)
                .IsRequired();

            modelBuilder.Entity<ApiSession>()
                .Property(apiSession => apiSession.URL)
                .IsRequired();
            #endregion

            #region Person Entity
            modelBuilder.Entity<Person>()
                .Property(person => person.Name)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(person => person.Team)
                .IsRequired();
            #endregion

            #region File Entity
            modelBuilder.Entity<File>()
                .Property(file => file.Name)
                .IsRequired();

            modelBuilder.Entity<File>()
                .Property(file => file.Content)
                .IsRequired();
            #endregion
        }
    }
}
