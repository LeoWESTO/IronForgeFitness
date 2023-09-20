using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents an item in the stock.
/// </summary>
public class Item : BaseEntity
{
    /// <summary>
    /// The title of the item.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The price of the item.
    /// </summary>
    public decimal Price { get; set; } = decimal.Zero;
}