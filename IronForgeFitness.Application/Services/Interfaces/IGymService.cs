using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents a service for managing gym-related operations.
/// </summary>
public interface IGymService
{
    /// <summary>
    /// Asynchronously retrieves all gyms.
    /// </summary>
    /// <returns>An IEnumerable of Gym objects.</returns>
    Task<IEnumerable<Gym>> GetGymsAsync();

    /// <summary>
    /// Asynchronously retrieves a specific page of gyms with the specified number of items per page.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="itemsPerPage">The number of gyms to include per page.</param>
    /// <returns>An IEnumerable of Gym objects representing the requested page of gyms.</returns>
    Task<IEnumerable<Gym>> GetGymsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves a gym by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the gym to retrieve.</param>
    /// <returns>A Gym object representing the requested gym.</returns>
    Task<Gym> GetGymAsync(Guid id);

    /// <summary>
    /// Asynchronously opens a gym.
    /// </summary>
    /// <param name="gym">The Gym object to open.</param>
    Task OpenGymAsync(Gym gym);

    /// <summary>
    /// Asynchronously updates a gym.
    /// </summary>
    /// <param name="gym">The Gym object to update.</param>
    Task UpdateGymAsync(Gym gym);

    /// <summary>
    /// Asynchronously closes a gym by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the gym to close.</param>
    Task CloseGymAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total number of gyms.
    /// </summary>
    /// <returns>An integer representing the total number of gyms.</returns>
    Task<int> TotalCount();
}