using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync(int page, int itemsPerPage);
        Task<Account> GetAccountAsync(Guid id);
        Task SignUpAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(Guid id);
        Task<int> TotalCount();
    }
}
