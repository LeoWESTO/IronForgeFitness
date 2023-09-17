using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(int page, int itemsPerPage);
        Task<Transaction> GetTransactionAsync(Guid id);
        Task AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(Guid id);
        Task<int> TotalCount();
    }
}
