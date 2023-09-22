using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a Gym entity with its address.
/// </summary>
public class Gym : BaseEntity
{
    /// <summary>
    /// The address of the gym.
    /// </summary>
    public string Address { get; set; } = string.Empty;
}