namespace DesignliTest.Core.Domain
{
    /// <summary>
    /// Represents an employee entity. Contains basic personal information.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Unique identifier of the employee.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The full name of the employee.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The date of birth of the employee.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The employee’s official identification number.
        /// </summary>
        public string IdentityNumber { get; set; } = string.Empty;
    }
}
