using DesignliTest.Core.Domain;

namespace DesignliTest.Core.Interface.Service
{
    /// <summary>
    /// Defines business logic for managing employee records.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Create a new employee record.
        /// </summary>
        /// <param name="employee">The employee entity to create.</param>
        Task<Employee> CreateAsync(Employee employee);

        /// <summary>
        /// Get all employees.
        /// </summary>
        Task<List<Employee>> GetAllAsync();

        /// <summary>
        /// Get an employee by its identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        Task<Employee?> GetByIdAsync(int id);

        /// <summary>
        /// Update an existing employee.
        /// </summary>
        /// <param name="employee">The employee entity to update.</param>
        Task UpdateAsync(Employee employee);

        /// <summary>
        /// Delete an employee by its identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        Task DeleteAsync(int id);
    }
}
