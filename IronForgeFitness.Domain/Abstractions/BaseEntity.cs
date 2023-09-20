namespace IronForgeFitness.Domain.Abstractions;

/// <summary>
/// Base class for all entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// The unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }
}