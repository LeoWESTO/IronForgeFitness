using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents an employee, inheriting from the Person class.
/// </summary>
public class Employee : Person
{
    /// <summary>
    /// The account information for the employee.
    /// </summary>
    public Account? Account { get; set; }

    /// <summary>
    /// The salary of the employee.
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// The date when the employee was hired.
    /// </summary>
    public DateOnly DateOfHire { get; set; }
}