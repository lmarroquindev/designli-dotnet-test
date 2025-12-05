using DesignliTest.Core.Domain;
using DesignliTest.Core.Dto.Input.Employee;
using DesignliTest.Core.Dto.Output.Employee;

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
        Task<EmployeeOutputDto> CreateAsync(EmployeeCreateDto employee);

        /// <summary>
        /// Get all employees.
        /// </summary>
        Task<List<EmployeeOutputDto>> GetAllAsync();

        /// <summary>
        /// Get an employee by its identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        Task<EmployeeOutputDto?> GetByIdAsync(int id);

        /// <summary>
        /// Update an existing employee.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        /// <param name="employee">The employee entity to update.</param>
        Task UpdateAsync(int id, EmployeeUpdateDto employee);

        /// <summary>
        /// Delete an employee by its identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        Task DeleteAsync(int id);
    }
}
