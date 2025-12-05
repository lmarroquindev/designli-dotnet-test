using DesignliTest.Core.Domain;
using DesignliTest.Core.Dto.Input.Employee;
using DesignliTest.Core.Dto.Output.Employee;
using DesignliTest.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesignliTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employeeCreateDto">Employee data for creation.</param>
        /// <returns>Returns the newly created employee.</returns>
        /// <response code="201">Returns the created employee.</response>
        /// <response code="400">If the provided data is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeOutputDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            var created = await _employeeService.CreateAsync(employeeCreateDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>List of all employees in the system.</returns>
        /// <response code="200">Returns the list of employees.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeOutputDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var list = await _employeeService.GetAllAsync();
            return Ok(list);
        }

        /// <summary>
        /// Gets a specific employee by identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the employee.</param>
        /// <returns>Employee details.</returns>
        /// <response code="200">Employee was found.</response>
        /// <response code="404">Employee not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EmployeeOutputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            EmployeeOutputDto employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">Employee ID to update.</param>
        /// <param name="dto">New employee data.</param>
        /// <returns>No content on success.</returns>
        /// <response code="204">Employee successfully updated.</response>
        /// <response code="404">Employee not found.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var exists = await _employeeService.GetByIdAsync(id);

            if (exists is null)
                return NotFound();

            await _employeeService.UpdateAsync(id, employeeUpdateDto);

            return NoContent();
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">Employee ID to delete.</param>
        /// <returns>No content on success.</returns>
        /// <response code="204">Employee deleted.</response>
        /// <response code="404">Employee not found.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var exists = await _employeeService.GetByIdAsync(id);
            if (exists is null)
                return NotFound();

            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
