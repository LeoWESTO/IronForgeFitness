using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Application.Services
{
    public class SubscriptionService : ISubsriptionService
    {
        private readonly IRepository<Subscription> _subsriptionRepository;
        private readonly ITransactionService _transactionService;

        public SubscriptionService(
            IRepository<Subscription> subsriptionRepository,
            ITransactionService transactionService)
        {
            _subsriptionRepository = subsriptionRepository;
            _transactionService = transactionService;
        }

        public async Task CloseSubscriptionAsync(Guid id)
        {
            await _subsriptionRepository.DeleteAsync(id);
        }

        public async Task<Subscription> GetSubscriptionAsync(Guid id)
        {
            return await _subsriptionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page, int itemsPerPage)
        {
            return await _subsriptionRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task OpenSubscriptionAsync(Subscription subscription)
        {
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                Amount = subscription.Service.Price,
                DateTime = DateTime.UtcNow,
                Type = TransactionType.Payment,
                Description = $"Оформлен абонемент на услугу {subscription.Service.Title}"
            };
            subscription.Transaction = transaction;

            await _transactionService.AddTransactionAsync(transaction);
            await _subsriptionRepository.AddAsync(subscription);
        }

        public async Task<int> TotalCount()
        {
            return await _subsriptionRepository.CountAsync();
        }

        public async Task UpdateSubscriptionAsync(Subscription subscription)
        {
            await _subsriptionRepository.UpdateAsync(subscription);
        }
    }
}
