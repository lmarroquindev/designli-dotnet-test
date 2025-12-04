using DesignliTest.Core.Domain;
using DesignliTest.Core.Interface.Repository;
using DesignliTest.Core.Interface.Service;

namespace DesignliTest.Application.Service
{
    /// <summary>
    /// Provides business logic implementation for managing employee records.
    /// </summary>
    /// <inheritdoc/>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
            return employee;
        }

        /// <inheritdoc/>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        /// <inheritdoc/>
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Employee employee)
        {
            Employee entity = await _repository.GetByIdAsync(employee.Id);
            entity = employee;
            await _repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            Employee entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("The employee doesnt exists");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
