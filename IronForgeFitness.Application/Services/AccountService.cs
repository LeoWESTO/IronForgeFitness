using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task<Account> GetAccountAsync(Guid id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync(int page, int itemsPerPage)
        {
            return await _accountRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task SignUpAsync(Account account)
        {
            await _accountRepository.AddAsync(account);
        }

        public async Task<int> TotalCount()
        {
            return await _accountRepository.CountAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAsync(account);
        }
    }
}
