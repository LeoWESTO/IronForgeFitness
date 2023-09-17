using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync(int page, int itemsPerPage);
        Task<Item> GetItemAsync(Guid id);
        Task BuyItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task SellItemAsync(Guid id, decimal price);
        Task<int> TotalCount();
    }
}
