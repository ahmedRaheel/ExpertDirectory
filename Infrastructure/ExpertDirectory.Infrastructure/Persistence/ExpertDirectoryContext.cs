using ExpertDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertDirectory.Infrastructure.Persistence
{
    public class ExpertDirectoryContext : DbContext
    {
        #region Entities 
        public DbSet<User> User { get; set; }
        public DbSet<UserConnection> UserConnection { get; set; }
        public DbSet<UserHeadings> UserHeadings { get; set; }
        #endregion

        #region Construction
        public ExpertDirectoryContext(DbContextOptions<ExpertDirectoryContext> dbContextOptions)
           : base(dbContextOptions)
        {

        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserConnection>()
                            .HasOne(e => e.Connection)
                            .WithMany(e => e.FriendConnections)
                            .HasForeignKey(e => e.ConnectionId)
                            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
