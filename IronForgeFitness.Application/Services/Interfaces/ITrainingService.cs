using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents a service for training-related operations.
/// </summary>
public interface ITrainingService
{
    /// <summary>
    /// Asynchronously retrieves a collection of trainings based on pagination parameters.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation, returning a collection of trainings.</returns>
    Task<IEnumerable<Training>> GetTrainingsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves a training based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the training.</param>
    /// <returns>A task that represents the asynchronous operation, returning the requested training.</returns>
    Task<Training> GetTrainingAsync(Guid id);

    /// <summary>
    /// Asynchronously schedules a training.
    /// </summary>
    /// <param name="training">The training to be scheduled.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ScheduleTrainingAsync(Training training);

    /// <summary>
    /// Asynchronously updates a training.
    /// </summary>
    /// <param name="training">The updated training information.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateTrainingAsync(Training training);

    /// <summary>
    /// Asynchronously deletes a training based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the training to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteTrainingAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total count of trainings.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, returning the total count of trainings.</returns>
    Task<int> TotalCount();
}