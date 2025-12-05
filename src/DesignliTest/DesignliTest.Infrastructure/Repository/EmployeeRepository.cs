using DesignliTest.Core.Domain;
using DesignliTest.Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace DesignliTest.Infrastructure.Repository
{
    /// <summary>
    /// Employee repository implementation using EF InMemory.
    /// </summary>
    /// <inheritdoc/>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Employee employee)
        {
            _dbContext.Set<Employee>().Remove(employee);
        }
        /// <inheritdoc/>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees
                                    .AsNoTracking()
                                    .ToListAsync();
        }
        /// <inheritdoc/>
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
