namespace DesignliTest.Core.Dto.Input.Employee
{
    /// <summary>
    /// DTO used to update an <see cref="Domain.Employee"/>.
    /// </summary>
    public class EmployeeUpdateDto
    {
        /// <summary>
        /// The full name of the <see cref="Domain.Employee"/>.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The date of birth of the <see cref="Domain.Employee"/>.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The <see cref="Domain.Employee"/>’s official identification number.
        /// </summary>
        public string IdentityNumber { get; set; } = string.Empty;
    }
}
