using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces;

/// <summary>
/// Interface for managing items.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Asynchronously retrieves a paginated list of items.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="itemsPerPage">The number of items per page.</param>
    /// <returns>A collection of items.</returns>
    Task<IEnumerable<Item>> GetItemsAsync(int page, int itemsPerPage);

    /// <summary>
    /// Asynchronously retrieves an item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item.</param>
    /// <returns>The item.</returns>
    Task<Item> GetItemAsync(Guid id);

    /// <summary>
    /// Asynchronously purchases an item.
    /// </summary>
    /// <param name="item">The item to be purchased.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    Task BuyItemAsync(Item item);

    /// <summary>
    /// Asynchronously updates an item.
    /// </summary>
    /// <param name="item">The item to be updated.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    Task UpdateItemAsync(Item item);

    /// <summary>
    /// Asynchronously sells an item at a specified price.
    /// </summary>
    /// <param name="id">The ID of the item to be sold.</param>
    /// <param name="price">The selling price of the item.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    Task SellItemAsync(Guid id, decimal price);

    /// <summary>
    /// Asynchronously retrieves the total count of items.
    /// </summary>
    /// <returns>The total count of items.</returns>
    Task<int> TotalCount();
}