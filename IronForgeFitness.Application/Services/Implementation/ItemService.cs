using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Application.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly ITransactionService _transactionService;

        public ItemService(
            IRepository<Item> itemRepository,
            ITransactionService transactionService)
        {
            _itemRepository = itemRepository;
            _transactionService = transactionService;
        }

        public async Task BuyItemAsync(Item item)
        {

            var transaction = new Transaction()
            {
                Amount = item.Price,
                DateTime = DateTime.UtcNow,
                Type = TransactionType.Purchase,
                Description = $"Покупка {item.Title} на склад"
            };

            await _transactionService.AddTransactionAsync(transaction);
            await _itemRepository.AddAsync(item);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(int page, int itemsPerPage)
        {
            return await _itemRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task SellItemAsync(Guid id, decimal price)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            var transaction = new Transaction()
            {
                Amount = -price,
                DateTime = DateTime.UtcNow,
                Type = TransactionType.Sale,
                Description = $"Продажа {item.Title} со склада"
            };

            await _transactionService.AddTransactionAsync(transaction);
            await _itemRepository.DeleteAsync(id);
        }

        public async Task<int> TotalCount()
        {
            return await _itemRepository.CountAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            await _itemRepository.UpdateAsync(item);
        }
    }
}
