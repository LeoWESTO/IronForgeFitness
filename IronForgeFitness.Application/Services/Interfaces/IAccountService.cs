using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Represents an interface for managing accounts.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Asynchronously retrieves a collection of accounts based on pagination.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>An asynchronous operation returning a collection of accounts.</returns>
    Task<IEnumerable<Account>> GetAccountsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves an account by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the account.</param>
    /// <returns>An asynchronous operation returning an account.</returns>
    Task<Account> GetAccountAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves an account by its email.
    /// </summary>
    /// <param name="email">The email associated with the account.</param>
    /// <returns>An asynchronous operation returning an account.</returns>
    Task<Account> GetByEmail(string email);

    /// <summary>
    /// Asynchronously signs up a new account.
    /// </summary>
    /// <param name="account">The account to sign up.</param>
    /// <returns>An asynchronous operation representing the sign-up process.</returns>
    Task SignUpAsync(Account account);

    /// <summary>
    /// Asynchronously updates an existing account.
    /// </summary>
    /// <param name="account">The account to update.</param>
    /// <returns>An asynchronous operation representing the update process.</returns>
    Task UpdateAccountAsync(Account account);

    /// <summary>
    /// Asynchronously deletes an account by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the account to delete.</param>
    /// <returns>An asynchronous operation representing the deletion process.</returns>
    Task DeleteAccountAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves the total count of accounts.
    /// </summary>
    /// <returns>An asynchronous operation returning the total count of accounts.</returns>
    Task<int> TotalCount();
}