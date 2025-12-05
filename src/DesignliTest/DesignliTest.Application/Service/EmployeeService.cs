using DesignliTest.Core.Domain;
using DesignliTest.Core.Dto.Input.Employee;
using DesignliTest.Core.Dto.Output.Employee;
using DesignliTest.Core.Interface.Repository;
using DesignliTest.Core.Interface.Service;
using Mapster;

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
        public async Task<EmployeeOutputDto> CreateAsync(EmployeeCreateDto employee)
        {
            Employee entity = employee.Adapt<Employee>();
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Adapt<EmployeeOutputDto>();
        }

        /// <inheritdoc/>
        public async Task<List<EmployeeOutputDto>> GetAllAsync()
        {
            List<Employee> employees = await _repository.GetAllAsync();
            return employees.Adapt<List<EmployeeOutputDto>>();
        }
        
        /// <inheritdoc/>
        public async Task<EmployeeOutputDto?> GetByIdAsync(int id)
        {
            Employee employee = await _repository.GetByIdAsync(id);
            return employee.Adapt<EmployeeOutputDto>();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(int id, EmployeeUpdateDto employee)
        {
            Employee entity = await _repository.GetByIdAsync(id);
            employee.Adapt(entity);
            await _repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            Employee entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
