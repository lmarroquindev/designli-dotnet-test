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
    }
}
