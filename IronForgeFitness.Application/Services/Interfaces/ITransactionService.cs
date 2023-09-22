using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents a service for handling transactions.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Retrieves a paginated list of transactions asynchronously.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>An asynchronous task that returns a collection of transactions.</returns>
    Task<IEnumerable<Transaction>> GetTransactionsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Retrieves a transaction by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the transaction.</param>
    /// <returns>An asynchronous task that returns the transaction.</returns>
    Task<Transaction> GetTransactionAsync(Guid id);

    /// <summary>
    /// Adds a new transaction asynchronously.
    /// </summary>
    /// <param name="transaction">The transaction to add.</param>
    /// <returns>An asynchronous task.</returns>
    Task AddTransactionAsync(Transaction transaction);

    /// <summary>
    /// Updates an existing transaction asynchronously.
    /// </summary>
    /// <param name="transaction">The transaction to update.</param>
    /// <returns>An asynchronous task.</returns>
    Task UpdateTransactionAsync(Transaction transaction);

    /// <summary>
    /// Deletes a transaction by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the transaction to delete.</param>
    /// <returns>An asynchronous task.</returns>
    Task DeleteTransactionAsync(Guid id);

    /// <summary>
    /// Retrieves the total count of transactions asynchronously.
    /// </summary>
    /// <returns>An asynchronous task that returns the total count of transactions.</returns>
    Task<int> TotalCount();
}