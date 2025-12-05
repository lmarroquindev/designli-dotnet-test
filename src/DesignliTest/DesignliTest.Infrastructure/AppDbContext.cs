using DesignliTest.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesignliTest.Infrastructure
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Employees table.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// UserApp table
        /// </summary>
        public DbSet<UserApp> UserApp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserApp>().HasKey(u => u.Username);
        }
    }
}
