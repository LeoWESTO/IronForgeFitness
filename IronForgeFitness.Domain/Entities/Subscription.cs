using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a subscription of the customer.
/// </summary>
public class Subscription : BaseEntity
{
    /// <summary>
    /// The transaction associated with the subscription.
    /// </summary>
    public Transaction? Transaction { get; set; }

    /// <summary>
    /// The service associated with the subscription.
    /// </summary>
    public Service? Service { get; set; }

    /// <summary>
    /// The expiration date of the subscription.
    /// </summary>
    public DateOnly ExpirationDate { get; set; }
}