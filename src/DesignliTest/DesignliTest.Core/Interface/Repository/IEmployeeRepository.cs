using DesignliTest.Core.Domain;

namespace DesignliTest.Core.Interface.Repository
{
    /// <summary>
    /// Defines the contract for employee data access operations.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/> entity to create.</param>
        /// <returns></returns>
        Task AddAsync(Employee employee);

        /// <summary>
        /// Retrieves all registered employees.
        /// </summary>
        /// <returns>A list of <see cref="Employee"/> entities.</returns>
        Task<List<Employee>> GetAllAsync();

        /// <summary>
        /// Retrieves an employee based on its unique identifier.
        /// </summary>
        /// <param name="id">The employee's Id.</param>
        /// <returns>
        /// The matching <see cref="Employee"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<Employee?> GetByIdAsync(int id);

        /// <summary>
        /// Deletes an employee based on its unique identifier.
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/> entity to remove.</param>
        /// <returns></returns>
        Task DeleteAsync(Employee employee);
        // <summary>
        /// Persists all pending changes in the data context.
        /// </summary>
        Task SaveChangesAsync();
    }
}
