using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a customer, inheriting from the Person class.
/// </summary>
public class Customer : Person
{
    /// <summary>
    /// The account associated with the customer.
    /// </summary>
    public Account? Account { get; set; }

    /// <summary>
    /// A list of subscriptions for the customer.
    /// </summary>
    public List<Subscription> Subscriptions { get; set; } = new();
}