using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a service of the gym.
/// </summary>
public class Service : BaseEntity
{
    /// <summary>
    /// The title of the service.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The description of the service.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The price of the service.
    /// </summary>
    public decimal Price { get; set; } = decimal.Zero;
}