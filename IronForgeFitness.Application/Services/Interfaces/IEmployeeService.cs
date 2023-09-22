using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Interface for managing employee-related operations.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Asynchronously retrieves a collection of employees based on pagination parameters.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation, yielding the collection of employees.</returns>
    Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves an employee by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the employee.</param>
    /// <returns>A task that represents the asynchronous operation, yielding the retrieved employee.</returns>
    Task<Employee> GetEmployeeAsync(Guid id);

    /// <summary>
    /// Asynchronously hires a new employee.
    /// </summary>
    /// <param name="employee">The employee to be hired.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task HireEmployeeAsync(Employee employee);

    /// <summary>
    /// Asynchronously updates an existing employee.
    /// </summary>
    /// <param name="employee">The updated employee information.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateEmployeeAsync(Employee employee);

    /// <summary>
    /// Asynchronously terminates an employee based on their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the employee to be terminated.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task FireEmployeeAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total count of employees.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, yielding the total employee count.</returns>
    Task<int> TotalCount();
}