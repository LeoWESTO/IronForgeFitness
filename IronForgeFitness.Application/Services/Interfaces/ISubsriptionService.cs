using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents a subscription service interface.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Asynchronously retrieves subscriptions based on the specified page and items per page.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>An asynchronous task that returns an enumerable of subscriptions.</returns>
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves a subscription by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription.</param>
    /// <returns>An asynchronous task that returns the subscription.</returns>
    Task<Subscription> GetSubscriptionAsync(Guid id);

    /// <summary>
    /// Asynchronously opens a subscription.
    /// </summary>
    /// <param name="subscription">The subscription to be opened.</param>
    /// <returns>An asynchronous task.</returns>
    Task OpenSubscriptionAsync(Subscription subscription);

    /// <summary>
    /// Asynchronously updates a subscription.
    /// </summary>
    /// <param name="subscription">The subscription to be updated.</param>
    /// <returns>An asynchronous task.</returns>
    Task UpdateSubscriptionAsync(Subscription subscription);

    /// <summary>
    /// Asynchronously closes a subscription by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription to be closed.</param>
    /// <returns>An asynchronous task.</returns>
    Task CloseSubscriptionAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total count of subscriptions.
    /// </summary>
    /// <returns>An asynchronous task that returns the total count.</returns>
    Task<int> TotalCount();
}