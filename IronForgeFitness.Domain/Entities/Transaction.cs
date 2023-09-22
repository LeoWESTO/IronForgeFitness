using IronForgeFitness.Domain.Abstractions;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents a transaction entity.
/// </summary>
public class Transaction : BaseEntity
{
    /// <summary>
    /// The type of the transaction.
    /// </summary>
    public TransactionType Type { get; set; } = TransactionType.None;

    /// <summary>
    /// The date and time of the transaction.
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// The amount of the transaction.
    /// </summary>
    public decimal Amount { get; set; } = decimal.Zero;

    /// <summary>
    /// The description of the transaction.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}