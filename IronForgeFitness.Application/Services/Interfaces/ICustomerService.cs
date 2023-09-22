using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents a service for managing customers.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Asynchronously retrieves a collection of customers for a specific page.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>A collection of customers for the specified page.</returns>
    Task<IEnumerable<Customer>> GetCustomersAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer associated with the provided identifier.</returns>
    Task<Customer> GetCustomerAsync(Guid id);

    /// <summary>
    /// Asynchronously adds a new customer.
    /// </summary>
    /// <param name="customer">The customer to be added.</param>
    Task AddCustomerAsync(Customer customer);

    /// <summary>
    /// Asynchronously updates an existing customer.
    /// </summary>
    /// <param name="customer">The updated customer information.</param>
    Task UpdateCustomerAsync(Customer customer);

    /// <summary>
    /// Asynchronously deletes a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to be deleted.</param>
    Task DeleteCustomerAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total count of customers.
    /// </summary>
    /// <returns>The total count of customers.</returns>
    Task<int> TotalCount();
}