using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a training entity.
/// </summary>
public class Training : BaseEntity
{
    /// <summary>
    /// The date and time of the training.
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// The list of subscriptions associated with the training.
    /// </summary>
    public List<Subscription> Subscriptions { get; set; } = new();
}