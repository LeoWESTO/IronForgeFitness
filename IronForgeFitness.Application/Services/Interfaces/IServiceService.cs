using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Interface for managing services.
/// </summary>
public interface IServiceService
{
    /// <summary>
    /// Gets a collection of services asynchronously with pagination.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation, returning a collection of services.</returns>
    Task<IEnumerable<Service>> GetServicesAsync(int page, int itemsPerPage);

    /// <summary>
    /// Gets a service by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the service to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, returning the requested service.</returns>
    Task<Service> GetServiceAsync(Guid id);

    /// <summary>
    /// Adds a new service asynchronously.
    /// </summary>
    /// <param name="service">The service to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddServiceAsync(Service service);

    /// <summary>
    /// Updates an existing service asynchronously.
    /// </summary>
    /// <param name="service">The service to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateServiceAsync(Service service);

    /// <summary>
    /// Deletes a service by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the service to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteServiceAsync(Guid id);

    /// <summary>
    /// Gets the total count of services.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, returning the total count of services.</returns>
    Task<int> TotalCount();
}